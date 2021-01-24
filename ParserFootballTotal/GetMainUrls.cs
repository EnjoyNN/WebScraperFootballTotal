using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using ParserFootballTotal.Properties;
using GetRequest;

namespace ParserFootballTotal
{
    class GetMainUrls
    {
        private List<Thread> threads = new List<Thread>();
        private static object lockFormData = new object();
        private List<DataContainerMatches> getUrls(MainWindow mainWindow)
        {
            var mainUrls = new List<DataContainerMatches>();

            mainWindow.Dispatcher.Invoke(() =>
            {
                

            
            if (mainWindow.cbAllMatchInAllTotalUnder05.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 0,5 Матч Всего", "/football/top_streaks/under/",
                    Settings.Default.settingAllMatchInAllTotalUnder05, 2, 2, 2);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[2]/div[2]/div[2]/table/tbody/tr[2]
            }

            
            if (mainWindow.cbAllMatchInHomeTotalUnder05.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 0,5 Матч Дома", "/football/top_streaks/under/",
                    Settings.Default.settingAllMatchInHomeTotalUnder05, 2, 3, 2);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[2]/div[3]/div[2]/table/tbody/tr[2]
            }

            
            if (mainWindow.cbAllMatchInAwayTotalUnder05.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 0,5 Матч Гости", "/football/top_streaks/under/",
                    Settings.Default.settingAllMatchInAwayTotalUnder05, 2, 4, 2);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[2]/div[4]/div[2]/table/tbody/tr[2]
            }

            
            if (mainWindow.cbAllMatchInAllTotalUnder25.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 2,5 Матч Всего", "/football/top_streaks/under/",
                    Settings.Default.settingAllMatchInAllTotalUnder25, 2, 2, 4);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[2]/div[2]/div[4]/table/tbody/tr[2]
            }

            
            if (mainWindow.cbAllMatchInHomeTotalUnder25.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 2,5 Матч Дома", "/football/top_streaks/under/",
                    Settings.Default.settingAllMatchInHomeTotalUnder25, 2, 3, 4);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[2]/div[3]/div[4]/table/tbody/tr[2]
            }

            
            if (mainWindow.cbAllMatchInAwayTotalUnder25.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 2,5 Матч Гости", "/football/top_streaks/under/",
                    Settings.Default.settingAllMatchInAwayTotalUnder25, 2, 4, 4);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[2]/div[4]/div[4]/table/tbody/tr[2]
            }

            
            if (mainWindow.cbAllMatchInAllFailedToScore.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("Не забив Матч Всего", "/football/top_streaks/failed_to_score/",
                    Settings.Default.settingAllMatchInAllFailedToScore, 2, 2);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[2]/div[2]/div/table/tbody/tr[2]
            }

            
            if (mainWindow.cbAllMatchInHomeFailedToScore.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("Не забив Матч Дома", "/football/top_streaks/failed_to_score/",
                    Settings.Default.settingAllMatchInHomeFailedToScore, 2, 3);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[2]/div[3]/div/table/tbody/tr[2]
            }

            
            if (mainWindow.cbAllMatchInAwayFailedToScore.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("Не забив Матч Гости", "/football/top_streaks/failed_to_score/",
                    Settings.Default.settingAllMatchInAwayFailedToScore, 2, 4);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[2]/div[4]/div/table/tbody/tr[2]
            }

            

            if (mainWindow.cbFirstTimeInAllTotalUnder05.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 0,5 1-й Тайм Всего", "/football/top_streaks/under/",
                    Settings.Default.settingFirstTimeInAllTotalUnder05, 4, 2, 2);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[4]/div[2]/div[2]/table/tbody/tr[2]
            }

            
            if (mainWindow.cbFirstTimeInHomeTotalUnder05.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 0,5 1-й Тайм Дома", "/football/top_streaks/under/",
                    Settings.Default.settingFirstTimeInHomeTotalUnder05, 4, 3, 2);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[4]/div[3]/div[2]/table/tbody/tr[3]
            }

            
            if (mainWindow.cbFirstTimeInAwayTotalUnder05.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 0,5 1-й Тайм Гости", "/football/top_streaks/under/",
                    Settings.Default.settingFirstTimeInAwayTotalUnder05, 4, 4, 2);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[4]/div[4]/div[2]/table/tbody/tr[2]
            }

            
            if (mainWindow.cbFirstTimeInAllTotalUnder25.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 2,5 1-й Тайм Всего", "/football/top_streaks/under/",
                    Settings.Default.settingFirstTimeInAllTotalUnder25, 4, 2, 4);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[4]/div[2]/div[4]/table/tbody/tr[2]
            }

            
            if (mainWindow.cbFirstTimeInHomeTotalUnder25.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 2,5 1-й Тайм Дома", "/football/top_streaks/under/",
                    Settings.Default.settingFirstTimeInHomeTotalUnder25, 4, 3, 4);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[4]/div[3]/div[4]/table/tbody/tr[2]
            }

            
            if (mainWindow.cbFirstTimeInAwayTotalUnder25.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 2,5 1-й Тайм Гости", "/football/top_streaks/under/",
                    Settings.Default.settingFirstTimeInAwayTotalUnder25, 4, 4, 4);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[4]/div[4]/div[4]/table/tbody/tr[2]
            }

            
            if (mainWindow.cbFirstTimeInAllFailedToScore.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("Не забив 1-й Тайм Всего", "/football/top_streaks/failed_to_score/",
                    Settings.Default.settingFirstTimeInAllFailedToScore, 3, 2);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[3]/div[2]/div/table/tbody/tr[2]
            }

            
            if (mainWindow.cbFirstTimeInHomeFailedToScore.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("Не забив 1-й Тайм Дома", "/football/top_streaks/failed_to_score/",
                    Settings.Default.settingFirstTimeInHomeFailedToScore, 3, 3);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[3]/div[3]/div/table/tbody/tr[2]
            }

            
            if (mainWindow.cbFirstTimeInAwayFailedToScore.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("Не забив 1-й Тайм Гости", "/football/top_streaks/failed_to_score/",
                    Settings.Default.settingFirstTimeInAwayFailedToScore, 3, 4);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[3]/div[4]/div/table/tbody/tr[2]
            }

            

            if (mainWindow.cbSecondTimeInAllTotalUnder05.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 0,5 2-й Тайм Всего", "/football/top_streaks/under/",
                    Settings.Default.settingSecondTimeInAllTotalUnder05, 5, 2, 2);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[5]/div[2]/div[2]/table/tbody/tr[2]
            }

            
            if (mainWindow.cbSecondTimeInHomeTotalUnder05.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 0,5 2-й Тайм Дома", "/football/top_streaks/under/",
                    Settings.Default.settingSecondTimeInHomeTotalUnder05, 5, 3, 2);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[5]/div[3]/div[2]/table/tbody/tr[2]
            }

            
            if (mainWindow.cbSecondTimeInAwayTotalUnder05.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 0,5 2-й Тайм Гости", "/football/top_streaks/under/",
                    Settings.Default.settingSecondTimeInAwayTotalUnder05, 5, 4, 2);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[5]/div[4]/div[2]/table/tbody/tr[2]
            }

            
            if (mainWindow.cbSecondTimeInAllTotalUnder25.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 2,5 2-й Тайм Всего", "/football/top_streaks/under/",
                    Settings.Default.settingSecondTimeInAllTotalUnder25, 5, 2, 4);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[5]/div[2]/div[4]/table/tbody/tr[2]
            }

            
            if (mainWindow.cbSecondTimeInHomeTotalUnder25.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 2,5 2-й Тайм Дома", "/football/top_streaks/under/",
                    Settings.Default.settingSecondTimeInHomeTotalUnder25, 5, 3, 4);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[5]/div[3]/div[4]/table/tbody/tr[2]
            }


            if (mainWindow.cbSecondTimeInAwayTotalUnder25.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 2,5 2-й Тайм Гости", "/football/top_streaks/under/",
                    Settings.Default.settingSecondTimeInAwayTotalUnder25, 5, 4, 4);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[5]/div[4]/div[4]/table/tbody/tr[2]
            }



            if (mainWindow.cbSecondTimeInAllFailedToScore.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("Не забив 2-й Тайм Всего", "/football/top_streaks/failed_to_score/",
                    Settings.Default.settingSecondTimeInAllFailedToScore, 4, 2);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[4]/div[2]/div/table/tbody/tr[2]
            }


            if (mainWindow.cbSecondTimeInHomeFailedToScore.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("Не забив 2-й Тайм Дома", "/football/top_streaks/failed_to_score/",
                    Settings.Default.settingSecondTimeInHomeFailedToScore, 4, 3);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[4]/div[3]/div/table/tbody/tr[2]
            }



            if (mainWindow.cbSecondTimeInAwayFailedToScore.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("Не забив 2-й Тайм Гости", "/football/top_streaks/failed_to_score/",
                    Settings.Default.settingSecondTimeInAwayFailedToScore, 4, 4);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[4]/div[4]/div/table/tbody/tr[2]
            }



            if (mainWindow.cbAllMatchInAllTotalUnder15.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 1,5 Матч Всего", "/football/top_streaks/under/",
                    Settings.Default.settingAllMatchInAllTotalUnder15, 2, 2, 3);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[2]/div[2]/div[3]/table/tbody/tr[2]
            }


            if (mainWindow.cbAllMatchInHomeTotalUnder15.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 1,5 Матч Дома", "/football/top_streaks/under/",
                    Settings.Default.settingAllMatchInHomeTotalUnder15, 2, 3, 3);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[2]/div[3]/div[3]/table/tbody/tr[2]
            }


            if (mainWindow.cbAllMatchInAwayTotalUnder15.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 1,5 Матч Гости", "/football/top_streaks/under/",
                    Settings.Default.settingAllMatchInAwayTotalUnder15, 2, 4, 3);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[2]/div[4]/div[3]/table/tbody/tr[2]
            }

 

            if (mainWindow.cbAllMatchInAllCleanSheets.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("Не проп Матч Всего", "/football/top_streaks/clean_sheets/",
                    Settings.Default.settingAllMatchInAllCleanSheets, 2, 2);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[2]/div[2]/div/table/tbody/tr[2]
            }



            if (mainWindow.cbAllMatchInHomeCleanSheets.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("Не проп Матч Дома", "/football/top_streaks/clean_sheets/",
                    Settings.Default.settingAllMatchInHomeCleanSheets, 2, 3);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[2]/div[3]/div/table/tbody/tr[2]
            }


            if (mainWindow.cbAllMatchInAwayCleanSheets.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("Не проп Матч Гости", "/football/top_streaks/clean_sheets/",
                    Settings.Default.settingAllMatchInAwayCleanSheets, 2, 4);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[2]/div[4]/div/table/tbody/tr[2]
            }


            if (mainWindow.cbAllMatchInAllBothFailedToScore.IsChecked == true)
            {
              //  var mainUrl = new DataContainerMatches("", Settings.Default.settingAllMatchInAllBothFailedToScore);

            }

            //Content = "Не забивали Оба Матч" IsChecked = "True" / >

            if (mainWindow.cbAllMatchInHomeBothFailedToScore.IsChecked == true)
            {
             //   var mainUrl = new DataContainerMatches("", Settings.Default.settingAllMatchInHomeBothFailedToScore);


            }

            //Content = "Не забивали Оба Дома" IsChecked = "True" / >

            if (mainWindow.cbAllMatchInAwayBothFailedToScore.IsChecked == true)
            {
              //  var mainUrl = new DataContainerMatches("", Settings.Default.settingAllMatchInAwayBothFailedToScore);


            }

            //Content = "Не забивали Оба Гости" IsChecked = "True" / >


            if (mainWindow.cbFirstTimeInAllTotalUnder15.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 1,5 1-й Тайм Всего", "/football/top_streaks/under/",
                    Settings.Default.settingFirstTimeInAllTotalUnder15, 4, 2, 3);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[4]/div[2]/div[3]/table/tbody/tr[2]
            }


            if (mainWindow.cbFirstTimeInHomeTotalUnder15.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 1,5 1-й Тайм Дома", "/football/top_streaks/under/",
                    Settings.Default.settingFirstTimeInHomeTotalUnder15, 4, 3, 3);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[4]/div[3]/div[3]/table/tbody/tr[2]
            }



            if (mainWindow.cbFirstTimeInAwayTotalUnder15.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 1,5 1-й Тайм Гости", "/football/top_streaks/under/",
                    Settings.Default.settingFirstTimeInAwayTotalUnder15, 4, 4, 3);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[4]/div[4]/div[3]/table/tbody/tr[2]
            }



            if (mainWindow.cbFirstTimeInAllCleanSheets.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("Не проп 1-й Тайм Всего", "/football/top_streaks/clean_sheets/",
                    Settings.Default.settingFirstTimeInAllCleanSheets, 3, 2);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[3]/div[2]/div/table/tbody/tr[2]
            }



            if (mainWindow.cbFirstTimeInHomeCleanSheets.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("Не проп 1-й Тайм Дома","/football/top_streaks/clean_sheets/",
                    Settings.Default.settingFirstTimeInHomeCleanSheets, 3, 3);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[3]/div[3]/div/table/tbody/tr[2]
            }



            if (mainWindow.cbFirstTimeInAwayCleanSheets.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("Не проп 1-й Тайм Гости", "/football/top_streaks/clean_sheets/",
                    Settings.Default.settingFirstTimeInAwayCleanSheets, 3, 4);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[3]/div[4]/div/table/tbody/tr[2]
            }


            if (mainWindow.cbFirstTimeInAllBothFailedToScore.IsChecked == true)
            {
               // var mainUrl = new DataContainerMatches("", Settings.Default.settingFirstTimeInAllBothFailedToScore);


            }

            //Content = "Не забив Оба 1-й Тайм" IsChecked = "True" / >

            if (mainWindow.cbFirstTimeInHomeBothFailedToScore.IsChecked == true)
            {
                //var mainUrl = new DataContainerMatches("", Settings.Default.settingFirstTimeInHomeBothFailedToScore);


            }

            //Content = "Не заб Оба 1-й Т Дома" IsChecked = "True" / >

            if (mainWindow.cbFirstTimeInAwayBothFailedToScore.IsChecked == true)
            {
              //  var mainUrl = new DataContainerMatches("", Settings.Default.settingFirstTimeInAwayBothFailedToScore);


            }

            //Content = "Не заб Оба 1-й Т Гости" IsChecked = "True" / >


            if (mainWindow.cbSecondTimeInAllTotalUnder15.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 1,5 2-й Тайм Всего", "/football/top_streaks/under/",
                    Settings.Default.settingSecondTimeInAllTotalUnder15, 5, 2, 3);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[5]/div[2]/div[3]/table/tbody/tr[2]
            }


            if (mainWindow.cbSecondTimeInHomeTotalUnder15.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 1,5 2-й Тайм Дома", "/football/top_streaks/under/",
                    Settings.Default.settingSecondTimeInHomeTotalUnder15, 5, 3, 3);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[5]/div[3]/div[3]/table/tbody/tr[2]
            }



            if (mainWindow.cbSecondTimeInAwayTotalUnder15.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("&lt; 1,5 2-й Тайм Гости", "/football/top_streaks/under/",
                    Settings.Default.settingSecondTimeInAwayTotalUnder15, 5, 4, 3);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[5]/div[4]/div[3]/table/tbody/tr[2]
            }


            if (mainWindow.cbSecondTimeInAllCleanSheets.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("Не проп 2-й Тайм Всего", "/football/top_streaks/clean_sheets/",
                    Settings.Default.settingSecondTimeInAllCleanSheets, 4, 2);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[4]/div[2]/div/table/tbody/tr[2]
            }


            if (mainWindow.cbSecondTimeInHomeCleanSheets.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("Не проп 2-й Тайм Дома", "/football/top_streaks/clean_sheets/",
                    Settings.Default.settingSecondTimeInHomeCleanSheets, 4, 3);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[4]/div[3]/div/table/tbody/tr[2]
            }



            if (mainWindow.cbSecondTimeInAwayCleanSheets.IsChecked == true)
            {
                var mainUrl = new DataContainerMatches("Не проп 2-й Тайм Гости", "/football/top_streaks/clean_sheets/",
                    Settings.Default.settingSecondTimeInAwayCleanSheets, 4, 4);
                mainUrls.Add(mainUrl);
                //*[@id="data_container"]/div[4]/div[4]/div/table/tbody/tr[2]
            }


            if (mainWindow.cbSecondTimeInAllBothFailedToScore.IsChecked == true)
            {
              //  var mainUrl = new DataContainerMatches("", Settings.Default.settingSecondTimeInAllBothFailedToScore);


            }

            //Content = "Не забив Оба 2-й Тайм" IsChecked = "True" / >

            if (mainWindow.cbSecondTimeInHomeBothFailedToScore.IsChecked == true)
            {
              //  var mainUrl = new DataContainerMatches("", Settings.Default.settingSecondTimeInHomeBothFailedToScore);


            }

            //Content = "Не заб Оба 2-й Т Дома" IsChecked = "True" / >

            if (mainWindow.cbSecondTimeInAwayBothFailedToScore.IsChecked == true)
            {
              //  var mainUrl = new DataContainerMatches("", Settings.Default.settingSecondTimeInAwayBothFailedToScore);


            }
            });


            //Content = "Не заб Оба 2-й Т Гости" IsChecked = "True" / >
            return mainUrls;
        }

        public void getFormDataMatches(MainWindow mainWindow)
        {
            var forDataList = new List<FormDataMatches>();
            var mainUrls = new List<DataContainerMatches>();
            mainUrls = getUrls(mainWindow);




            for (var i = 0; i < mainUrls.Count - 1; i++)
            {

                Thread thread = new Thread(() =>
                {
                    try
                    {
                        var browser = new GetRequestt();
                        //возможно лочить придется с начала обращения к list mainUrl
                        browser.Get("https://24score.pro" + mainUrls[i].url);

                        //сервер дает инфу для js скрипта по гет запросу и ключу, который он сам генерит при обращении.
                        //поэтому просто подключаемся к странице забираем ключ и делаем запрос с ключом, получаем то, что нужно
                        string key = browser.Document.Substring("data: {\"data_key\" : \"", "\"}");
                        browser.Get("https://24score.pro/backend/load_page_data.php?data_key=" + key);

                        //получаем конкретный лист с матчами нужной серии
                       // string DataContainer = ExtractHTML.ExtractTag(browser.Document, "div", "id=\"data_container\"");
                       //нужно поменять цифры и вычесть двойки из всего что есть выше в ифах. чтобы не вычитать это здесь. логически это странный мув
                        string divAllMatchOrHalf = ExtractHTML.ExtractTagsCollection(browser.Document, "div", "class=\"data-tab data-level1")[mainUrls[i].divAllMatchOrHalf-2];
                        string mainDiv = ExtractHTML.ExtractTagsCollection(divAllMatchOrHalf, "div", "class=\"data-tab data-level2")[mainUrls[i].divAllHomeAway - 2];
                        if (mainUrls[i].divTotals != 0)
                            mainDiv = ExtractHTML.ExtractTagsCollection(mainDiv, "div", "class=\"data-tab data-level3")[mainUrls[i].divTotals - 2];
                        string dataTable =
                            ExtractHTML.ExtractTagInnerHTML(mainDiv, "table", "class=\"datatable evenodd\"");

                        //начинаем каждый матч подходящий под серию заносить в общую таблицу
                        lock (lockFormData)
                        {
                            var trMatches = new List<string>();
                            trMatches.AddRange(ExtractHTML.ExtractTagsCollection(dataTable, "tr"));
                            
                            //начинаем с единицы потому что первый tr это хидер на сайте
                            for (var j = 1; j < trMatches.Count; j++)
                            {
                                var tdMatch = new List<string>();
                                tdMatch.AddRange(ExtractHTML.ExtractTagsCollection(trMatches[j], "td"));
                                string nameCommand = ExtractHTML.ExtractTagInnerHTML(tdMatch[0], "a").Trim();
                                string nameLeague = ExtractHTML.ExtractTagInnerHTML(tdMatch[1], "a").Trim();
                                string url = ExtractHTML.ExtractAttributeValue(tdMatch[0], "href");

                                string nextDate = ExtractHTML.ExtractTagInnerHTML(tdMatch[2], "td");
                                if (nextDate.Contains("<span"))
                                    nextDate = nextDate.Remove(nextDate.IndexOf(" <span")).Trim();

                                string countSerie = ExtractHTML.ExtractTagInnerHTML(tdMatch[3], "td").Trim();
                               // if ()

                               // var formMatch = new FormDataMatches();
                            }
                            
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception in thread, parsing DataContainerMatches: " + ex);
                    }

                });
                threads.Add(thread);
            }

            foreach (var thread in threads) thread.Start();
            foreach (var thread in threads) thread.Join();
        }
    }
}
