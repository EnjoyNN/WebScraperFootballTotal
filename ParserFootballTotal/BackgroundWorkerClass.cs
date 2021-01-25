﻿using System;
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
        private static object locker;
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
                int a = 5;


                //пока просто пробую парсить дату здесь, потом перенесу в другой класс либо функцию

                var threads = new List<Thread>();
                for (var i = 0; i < formDataList.Count; i++)
                {
                    var thread = new Thread(() =>
                    {



                    });
                    threads.Add(thread);
                }

                foreach (var thread in threads) thread.Start();
                foreach (var thread in threads) thread.Join();












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
