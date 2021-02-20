using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows;
using GetRequest;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Style.XmlAccess;
using ParserFootballTotal.Properties;

namespace ParserFootballTotal
{
    class BackgroundWorkerClass
    {
        private DateTime todayDate;
        private string whatIsDay;
        private BackgroundWorker backWorker;
        private MainWindow mainWindow;
        private GetRequestt Browser;
        private ExcelPackage package;
        private ExcelWorksheet worksheet1, worksheet2, worksheetTemp;
        private static object locker = new object();
        private int numberInRowSecondListExcel = 2;
        //переменная для каждой строчки каждого потока не нужна здесь, все будет грузится в один конгломерат, и только потом уже сортироваться по надобности.

        public void Start(string whatIsDay, MainWindow mainWindow)
        {
            this.whatIsDay = whatIsDay;
            this.mainWindow = mainWindow;



            backWorker = new BackgroundWorker();
            backWorker.WorkerSupportsCancellation = true;
            backWorker.WorkerReportsProgress = true;
            backWorker.DoWork += backWorker_DoWork;
            backWorker.ProgressChanged += backWorker_ProgressChanged;
            backWorker.RunWorkerCompleted += backWorker_RunWorkerCompleted;


            backWorker.RunWorkerAsync();
        }

        private void backWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Browser = new GetRequestt();

            try
            {
                Browser.Get("https://24score.pro/");

                string currentDate = ExtractHTML.ExtractTagInnerHTML(Browser.Document, "div", "class=\"current_date\"");
                if (currentDate.Remove(currentDate.IndexOf(" ")).Length == 1)
                    currentDate = "0" + currentDate;
                todayDate = DateTime.ParseExact(currentDate, "dd MMMM yyyy",
                    CultureInfo.CreateSpecificCulture("ru-RU"));

                var currentDateTimes = new List<DateTime>();
                if (whatIsDay == "сегодня")
                    currentDateTimes.Add(todayDate);
                else if (whatIsDay == "сегодня, завтра, послезавтра")
                {
                    currentDateTimes.Add(todayDate);
                    currentDateTimes.Add(todayDate.AddDays(1));
                    currentDateTimes.Add(todayDate.AddDays(2));
                }

                DateTime dateTime = DateTime.Now;
                string fileName = "Тотал на " + whatIsDay + " " + String.Format("{0:dd.MM.yyyy HH-mm-ss}", dateTime) +
                                  ".xlsx";
                File.Copy("Шаблон_ParserTotal.xlsx", fileName);

                package = new ExcelPackage(new FileInfo(fileName));
                worksheet1 = package.Workbook.Worksheets[1];
                worksheet2 = package.Workbook.Worksheets[2];
                worksheetTemp = package.Workbook.Worksheets.Add("TempSheet");

                ExcelNamedStyleXml mainStyle = package.Workbook.Styles.CreateNamedStyle("mainStyle");
                mainStyle = ExcelWork.getExcelStyle("Arial", 11, "", mainStyle);

                //вызываем функцию парса матчей по двум логикам, и получаем лист с матчами
                var getMainUrls = new GetFormData();
                var formDataList = new List<FormDataMatches>();
                formDataList.AddRange(getMainUrls.getFormDataMatches(mainWindow, currentDateTimes));

                var scores = new List<string>();
                var redGreenBlue = new List<string>();

                //счетчик на количество строк excel. равен тому от какого числа выполняется цикл, с единицы, т.к. первая строка хидер в экселе
                int numberInRow = 2;
                //счетчик для progressbar'а. просто i использовать не получится, потому что потоки выполняются параллельно и i может прыгать. единица потому что первая строка экселя хидер заказчика
                int endThread = 1;

                //пока просто пробую парсить дату здесь, потом перенесу в другой класс либо функцию
                var threads = new List<Thread>();
                for (var i = 0; i < formDataList.Count; i++)
                {
                    //делим потоки по 50, так как покгда все открываются сразу, после 200-300 уже сильные провисания времени
                    //поэтому 
                    if (threads.Count == 50)
                    {
                        foreach (var tthread in threads) tthread.Start();
                        foreach (var tthread in threads) tthread.Join();
                        threads.Clear();
                    }

                    int normali = i;
                    var thread = new Thread(() =>
                    {
                        try
                        {
                            var browser = new GetRequestt();
                            browser.Get("https://24score.pro" + formDataList[normali].urlCommand);
                            reconnectBrowser(browser, "https://24score.pro" + formDataList[normali].urlCommand);

                            //ищем нужный раздел(всего, дома, гости)
                            string mainDiv = "";
                            if (formDataList[normali].nameSerie.Contains("Всего"))
                                mainDiv =
                                    ExtractHTML.ExtractTagInnerHTML(browser.Document, "div", "id=\"all0\"");
                            else if (formDataList[normali].nameSerie.Contains("Дома"))
                                mainDiv =
                                    ExtractHTML.ExtractTagInnerHTML(browser.Document, "div", "id=\"home0\"");
                            else if (formDataList[normali].nameSerie.Contains("Гости"))
                                mainDiv =
                                    ExtractHTML.ExtractTagInnerHTML(browser.Document, "div", "id=\"away0\"");

                            //ищем нужную лигу
                            string tableLeague = "";
                            List<string> tablesLeague =
                                ExtractHTML.ExtractTagsCollection(mainDiv, "table", "class=\"t1 evenodd\"");
                            for (int j = 0; j < tablesLeague.Count; j++)
                            {
                                string tr = ExtractHTML.ExtractTagsCollection(tablesLeague[j], "tr")[0];
                                string th = ExtractHTML.ExtractTagsCollection(tr, "th")[0];
                                string nameTable = ExtractHTML.ExtractTagInnerHTML(th, "a");
                                if (nameTable.Contains(formDataList[normali].nameLeague))
                                {
                                    tableLeague = tablesLeague[j];
                                    break;
                                }
                            }

                            //делаем проверку если нашел лигу с которой тянем матчи. возможно такие матчи можно тоже только выгружать (без самих счетов), но это нужно у заказчика уточнять
                            if (tableLeague != "")
                            {
                                //парсим все матчи из лиги и потом выкидваем пустые, и берем только те, что подходят под количество серии
                                List<string> trMatches =
                                    ExtractHTML.ExtractTagsCollection(tableLeague, "tr");
                                //первый это хидер
                                trMatches.RemoveAt(0);
                                for (int j = 0; j < trMatches.Count; j++)
                                {
                                    //делаем проверку содержит ли две черточки (это еще не сыгранный матч), так же удаляем отложенные матчи из списка(возможно их нужно оставить)
                                    string td = ExtractHTML.ExtractTagsCollection(trMatches[j], "td")[2];
                                    if (td.Contains("— —") || td.Contains("Отложен"))
                                    {
                                        trMatches.RemoveAt(j);
                                        j--;
                                    }
                                }

                                //теперь заполняем два листа счетами и В П Н
                                //var scores = new List<string>();
                                //var redGreenBlue = new List<string>();

                                //высчитываем сколькосчетов будем выводить, если вдруг серия больше чем есть счетов
                                int countSerie = formDataList[normali].countSerie;
                                if (countSerie > trMatches.Count)
                                    countSerie = trMatches.Count;

                                lock (locker)
                                {
                                    for (int j = 0; j < countSerie; j++)
                                {
                                    string td = ExtractHTML.ExtractTagsCollection(trMatches[j], "td")[2];

                                    string mainScore =
                                        ExtractHTML.ExtractTagInnerHTML(ExtractHTML.ExtractTagInnerHTML(td, "a"), "b");

                                    string firstTimeScore = ExtractHTML.ExtractTagInnerHTML(td, "td");
                                    if (firstTimeScore.Contains("</a>"))
                                        firstTimeScore = firstTimeScore.Substring("</a>");
                                    if (firstTimeScore.Contains("<span"))
                                        firstTimeScore = firstTimeScore.Remove(firstTimeScore.IndexOf("<span"));
                                    firstTimeScore = firstTimeScore.Substring("(", ")");

                                    string redGreenBlue1 = ExtractHTML.ExtractTagInnerHTML(td, "span");


                                        scores.Add(mainScore + "(" + firstTimeScore + ")");
                                        redGreenBlue.Add(redGreenBlue1);

                                        //выгружаем в excel (потом это можно выкинуть в отдельную функцию)
                                        worksheet1.Cells[numberInRow, 1].Value = formDataList[normali].nameLeague;
                                        worksheet1.Cells[numberInRow, 2].Value =
                                            formDataList[normali].nextTime + " " + formDataList[normali].nextDate +
                                            " " + formDataList[normali].nextMatch;
                                        worksheet1.Cells[numberInRow, 3].Value = formDataList[normali].nameCommand;
                                        worksheet1.Cells[numberInRow, 4].Value = formDataList[normali].nameSerie;
                                        worksheet1.Cells[numberInRow, 5].Value = formDataList[normali].countSerie;

                                        worksheet1.Cells[numberInRow, j + 6].Value =
                                            mainScore + "(" + firstTimeScore + ")";
                                        if (redGreenBlue1 == "В")
                                            worksheet1.Cells[numberInRow, j + 6].Style.Font.Color
                                                .SetColor(Color.Green);
                                        else if (redGreenBlue1 == "П")
                                            worksheet1.Cells[numberInRow, j + 6].Style.Font.Color
                                                .SetColor(Color.Red);
                                        else if (redGreenBlue1 == "Н")
                                            worksheet1.Cells[numberInRow, j + 6].Style.Font.Color
                                                .SetColor(Color.Blue);
                                    
                                }
                                    //функция для отметки желтым и выгрузки на второй лист этого добра
                                    yellowFill(numberInRow, countSerie);

                                    numberInRow++;
                                }
                            }
                            backWorker.ReportProgress(0, (endThread++) + " " + formDataList.Count);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Exception in threads while parsing formdata + " + ex);
                        }
                    });
                    threads.Add(thread);
                }

                foreach (var thread in threads) thread.Start();
                foreach (var thread in threads) thread.Join();

                sortWorksheetToDate(worksheet1);
                sortWorksheetToDate(worksheet2);
                package.Workbook.Worksheets.Delete(worksheetTemp);

                backWorker.ReportProgress(100);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void reconnectBrowser(GetRequestt browser, string url)
        {
            int countConnect = 0;
            while (browser.Document == "")
            {
                if (countConnect == 10)
                {
                    break;
                }
                browser.Get(url);
                countConnect++;
            }
        }

        //проходится от начала по всем счетам и заливает 0-0 желтым. если какой-то счет находит другой выходит из цикла
        //так же выгружает сразу во второй лист серию
        private void yellowFill(int numberInRow, int countColumns)
        {
            bool isFind = false;
            for (int i = 0; i < countColumns; i++)
            {
                string firstTimeScore = worksheet1.Cells[numberInRow, i + 6].Value.ToString()
                    .Substring("(", ")");
                if (firstTimeScore == "0:0")
                {
                    //работает так, что елси находит первую колонку 0-0, помечает isFind, находит вторую, то только тогда уже 
                    if (i == 0)
                        isFind = true;
                    else
                    {
                        worksheet1.Cells[numberInRow, i + 6].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet1.Cells[numberInRow, i + 6].Style.Fill.BackgroundColor
                            .SetColor(ColorTranslator.FromHtml("#FFFF00"));

                        worksheet1.Cells[numberInRow, i + 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet1.Cells[numberInRow, i + 5].Style.Fill.BackgroundColor
                            .SetColor(ColorTranslator.FromHtml("#FFFF00"));
                    }

                    //делаем проверку на то, если последний элемент помечен желтым, то else не выполнится, но нам нужно выгрузить, поэтмоу выгружаем здесь
                    //так же проверяем на то, не является ли просто массив счетов одним счетом нулевым, тогда нам его один не нужно помечать и выгружать во второй лист
                    if ((i + 1) == countColumns && i != 0)
                    {
                        worksheet1.Cells[numberInRow, 1, numberInRow, i + 6].Copy(worksheet2.Cells[numberInRowSecondListExcel, 1]);
                        numberInRowSecondListExcel++;
                    }
                }

                else
                {
                    //i здесь не равно единице потому что если true и i=1 значит она нашел только первую колонку 0-0, а вторая не равна 0-0. поэтому такое не заливается и не копируется на второй лист 
                    if (isFind == true && i != 1)
                    {
                        worksheet1.Cells[numberInRow, 1, numberInRow, i + 5].Copy(worksheet2.Cells[numberInRowSecondListExcel, 1]); 
                        numberInRowSecondListExcel++;
                    }
                    break;
                }

            }
        }
        private void DeleteEmptyRows(ExcelWorksheet worksheet)
        {
            for (int i = worksheet.Dimension.End.Row; i > 0; i--)
            {
                if (worksheet.Cells[i, 1].Value == null)
                    worksheet.DeleteRow(i);
                else
                    break;
            }

            //удаляем пустые строки, они просто почему-то есть в некоторые дни. их пара штук
            for (int i = 1; i < worksheet.Dimension.End.Row + 1; i++)
            {
                if ((worksheet.Cells[i, 1].Value == null) &&
                    (worksheet.Cells[i, 2].Value == null) &&
                    (worksheet.Cells[i, 3].Value == null) &&
                    (worksheet.Cells[i, 4].Value == null))
                {
                    worksheet.DeleteRow(i);
                    i--;
                }
            }
        }

        private void sortWorksheetToDate(ExcelWorksheet worksheet)
        {
            DeleteEmptyRows(worksheet);

            worksheet.Cells[1, 1, worksheet.Dimension.End.Row, worksheet.Dimension.End.Column].Copy(worksheetTemp.Cells[1, 1]);
            worksheet.Cells[2, 1, worksheet.Dimension.End.Row, worksheet.Dimension.End.Column].Clear();

            //создаем лист со всеми строками(либо кластерами строк, как в третьем листе), и заполняем его этими кластерами\строками в цикле
            List<ExcelRange> rangeList = new List<ExcelRange>();
            for (int i = 2; i < worksheetTemp.Dimension.End.Row + 1; i++)
            {
                rangeList.Add(worksheetTemp.Cells[i, 1, i, worksheetTemp.Dimension.End.Column]);
                }

            //делаем пузырьковую сортировку листа по времени матча
            for (int p = 0; p < rangeList.Count - 1; p++)
            {
                for (int t = 0; t < rangeList.Count - p - 1; t++)
                {
                    DateTime t1 = DateTime.ParseExact(worksheetTemp.Cells[rangeList[t].Start.Row, 2].Value.ToString().Substring(0, 16), "HH:mm dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    DateTime t2 = DateTime.ParseExact(worksheetTemp.Cells[rangeList[t + 1].Start.Row, 2].Value.ToString().Substring(0, 16), "HH:mm dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    if (t1 > t2)
                    {
                        ExcelRange temp = rangeList[t];
                        rangeList.RemoveAt(t);
                        rangeList.Insert(t + 1, temp);
                    }
                }
            }

            for (int i = 0; i < rangeList.Count; i++)
            {
                ExcelRange cell = rangeList[i];
                cell.Copy(worksheet.Cells[i + 2, 1]);

            }

            for (int i = 2; i < worksheet.Dimension.End.Row + 1; i++)
            {
                worksheet.Row(i).Height = 18;
            }

            worksheetTemp.Cells[1, 1, worksheetTemp.Dimension.End.Row, worksheetTemp.Dimension.End.Column].Clear();
        }


        private void backWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                mainWindow.Dispatcher.Invoke(() =>
                {
                    mainWindow.progressBarMain.Maximum = Convert.ToInt32(e.UserState.ToString().Substring(" "));
                    mainWindow.progressBarMain.Value = Convert.ToInt32(e.UserState.ToString().Remove(
                        e.UserState.ToString().IndexOf(" ")));
                });
            }
        }

        private void backWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            //супер долгая сортировка по 5000 элементов в массиве,примерно 20 секунд, но пока пускай так
            //save может тормозить работу

            package.Save();
            mainWindow.CompletedWork();
            MessageBox.Show("Выгрузка успешно завершена!");
            }
    }
}
