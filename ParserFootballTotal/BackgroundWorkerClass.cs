using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        private List<Thread> threads = new List<Thread>();
        private int maxThreads;
        private static object locker = new object();
        //переменная для каждой строчки каждого потока не нужна здесь, все будет грузится в один конгломерат, и только потом уже сортироваться по надобности.

        public void Start(string whatIsDay, MainWindow mainWindow)
        {
            this.whatIsDay = whatIsDay;
            this.mainWindow = mainWindow;

            backWorker = new BackgroundWorker
            {
                WorkerSupportsCancellation = true,
                WorkerReportsProgress = true
            };
            backWorker.DoWork += backworker_DoWork;
            backWorker.ProgressChanged += backworker_ProgressChanged;
            backWorker.RunWorkerCompleted += backworker_RunWorkerCompleted;

            backWorker.RunWorkerAsync();
        }



        private void backworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        { }

        private void backworker_DoWork(object sender, DoWorkEventArgs e)
        {
            Browser = new GetRequestt();

            try
            {
                Browser.Get("https://24score.pro/");

                string currentDate = ExtractHTML.ExtractTagInnerHTML(Browser.Document, "div", "class=\"current_date\"");
                todayDate = DateTime.ParseExact(currentDate, "dd MMMM yyyy",
                    CultureInfo.CreateSpecificCulture("ru-RU"));

                var currentDateTimes = new List<DateTime>();
                if (whatIsDay == "today")
                    currentDateTimes.Add(todayDate);
                else if (whatIsDay == "today, tomorrow, day_after_tomorrow")
                {
                    currentDateTimes.Add(todayDate);
                    currentDateTimes.Add(todayDate.AddDays(1));
                    currentDateTimes.Add(todayDate.AddDays(2));
                }

                DateTime dateTime = DateTime.Now;
                string fileName = "Выгрузка PFT на " + whatIsDay + " " + String.Format("{0:dd.MM.yyyy HH-mm-ss}", dateTime) +
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

                //пока просто пробую парсить дату здесь, потом перенесу в другой класс либо функцию
                var threads = new List<Thread>();
                for (var i = 0; i < formDataList.Count; i++)
                {
                    int normali = i;
                    var thread = new Thread(() =>
                    {
                        try
                        {
                            var browser = new GetRequestt();
                            browser.Get("https://24score.pro" + formDataList[normali].urlCommand);
                            reconnectBrowser(browser, "https://24score.pro" + formDataList[normali].nameCommand);

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

                            //теперь заполянем два листа счетами и В П Н
                            //var scores = new List<string>();
                            //var redGreenBlue = new List<string>();

                            //высчитываем сколькосчетов будем выводить, если вдруг серия больше чем есть счетов
                            int countSerie = formDataList[normali].countSerie;
                            if (countSerie > trMatches.Count)
                                countSerie = trMatches.Count;

                            for (int j = 0; j < countSerie; j++)
                            {
                                string td = ExtractHTML.ExtractTagsCollection(trMatches[j], "td")[2];

                                string mainScore = ExtractHTML.ExtractTagInnerHTML(ExtractHTML.ExtractTagInnerHTML(td, "a"), "b");

                                string firstTimeScore = ExtractHTML.ExtractTagInnerHTML(td, "td");
                                if (firstTimeScore.Contains("</a>"))
                                    firstTimeScore = firstTimeScore.Substring("</a>");
                                if (firstTimeScore.Contains("<span"))
                                    firstTimeScore = firstTimeScore.Remove(firstTimeScore.IndexOf("<span"));
                                firstTimeScore = firstTimeScore.Substring("(", ")");
                                
                                string redGreenBlue1 = ExtractHTML.ExtractTagInnerHTML(td, "span");

                                lock (locker)
                                {
                                    scores.Add(mainScore + "(" + firstTimeScore + ")");
                                    redGreenBlue.Add(redGreenBlue1);
                                }
                            }
                            }
                        catch(Exception ex)
                        {
                            Console.WriteLine("Exception in threads while parsing formdata + " + ex);
                        }
                    });
                    threads.Add(thread);
                }

                foreach (var thread in threads) thread.Start();
                foreach (var thread in threads) thread.Join();

                int a = 0;










                /*  string allMatches = ExtractHTML.ExtractTag(Browser.Document, "table", "class=\"daymatches\"");
  
                  List<string> allLeague = new List<string>();
                  allLeague.AddRange(ExtractHTML.ExtractTagsCollection(allMatches, "tbody"));
  
                  List<string> match = new List<string>();
  
                  //тут мы парсим лиги
  
                  for (int i = 0; i < allLeague.Count; i++)
                  {
                      ParsLeague(allLeague[i]);
                  }
  
                  foreach (var thread in threads) thread.Start();
                  foreach (var thread in threads) thread.Join();
  
                  package.Workbook.Worksheets.Delete(worksheetTemp);
  
                  backWorker.ReportProgress(100, fileName);*/
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
                if (countConnect == 5)
                {
                    break;
                }
                browser.Get(url);
                countConnect++;
            }
        }

        void backworker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                //mainWindow.ProgressBarChanged(e);
            }

            if (e.ProgressPercentage == 100)
            {
               // mainWindow.CompletedWork();

                //save может тормозить работу
               // package.Save();
               // MessageBox.Show("Выгрузка успешно завершена!");
                //backworker.CancelAsync();
            }
        }
    }
}
