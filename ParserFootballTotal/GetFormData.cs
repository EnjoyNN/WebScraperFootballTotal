using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using ParserFootballTotal.Properties;
using GetRequest;

namespace ParserFootballTotal
{
    class GetFormData
    {
        //краткое описание работы класса
        //одна открытая (public) функция - получение контейнеров класса FormDataMatches
        //при запуске этой паблик функции она вызывает: функцию получения матчей по логике из страницы Серий сайта, и эта функцию так же вызывает функцию получения чекбоксов
        //                                              функцию получения матчей по логике обе не забьют, то есть проходится по всем лигам в каждый конкретный день, так же вызывается функцию проверки своих чекбоксов
        //затем результаты двух функций этих двух логик суммируются в один лист и выдаются.

        //private static object lockFormData = new object();

        private List<DataContainer> getTotalsAndFailedCleanSheetsUrls(MainWindow mainWindow)
        {
            var mainUrls = new List<DataContainer>();

            mainWindow.Dispatcher.Invoke(() =>
            {

                if (Settings.Default.cbAllMatchInAllTotalUnder05 == true)
                {
                    var mainUrl = new DataContainer("< 0,5 Матч Всего", "/football/top_streaks/under/",
                        Settings.Default.settingAllMatchInAllTotalUnder05, 0, 0, 0);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbAllMatchInHomeTotalUnder05 == true)
                { 
                    var mainUrl = new DataContainer("< 0,5 Матч Дома", "/football/top_streaks/under/",
                        Settings.Default.settingAllMatchInHomeTotalUnder05, 0, 1, 0);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbAllMatchInAwayTotalUnder05 == true)
                {
                    var mainUrl = new DataContainer("< 0,5 Матч Гости", "/football/top_streaks/under/",
                        Settings.Default.settingAllMatchInAwayTotalUnder05, 0, 2, 0);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbAllMatchInAllTotalUnder25 == true)
                {
                    var mainUrl = new DataContainer("< 2,5 Матч Всего", "/football/top_streaks/under/",
                        Settings.Default.settingAllMatchInAllTotalUnder25, 0, 0, 2);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbAllMatchInHomeTotalUnder25 == true)
                {
                    var mainUrl = new DataContainer("< 2,5 Матч Дома", "/football/top_streaks/under/",
                        Settings.Default.settingAllMatchInHomeTotalUnder25, 0, 1, 2);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbAllMatchInAwayTotalUnder25 == true)
                {
                    var mainUrl = new DataContainer("< 2,5 Матч Гости", "/football/top_streaks/under/",
                        Settings.Default.settingAllMatchInAwayTotalUnder25, 0, 2, 2);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbAllMatchInAllFailedToScore == true)
                {
                    var mainUrl = new DataContainer("Не забив Матч Всего",
                        "/football/top_streaks/failed_to_score/",
                        Settings.Default.settingAllMatchInAllFailedToScore, 0, 0);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbAllMatchInHomeFailedToScore == true)
                {
                    var mainUrl = new DataContainer("Не забив Матч Дома",
                        "/football/top_streaks/failed_to_score/",
                        Settings.Default.settingAllMatchInHomeFailedToScore, 0, 1);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbAllMatchInAwayFailedToScore == true)
                {
                    var mainUrl = new DataContainer("Не забив Матч Гости",
                        "/football/top_streaks/failed_to_score/",
                        Settings.Default.settingAllMatchInAwayFailedToScore, 0, 2);
                    mainUrls.Add(mainUrl);
                }



                if (Settings.Default.cbAllMatchInAllTotalOver15 == true)
                {
                    var mainUrl = new DataContainer("> 1,5 Матч Всего",
                        "/football/top_streaks/over/",
                        Settings.Default.settingAllMatchInAllTotalOver15, 0, 0, 1);
                    mainUrls.Add(mainUrl);
                }

                if (Settings.Default.cbAllMatchInHomeTotalOver15 == true)
                {
                    var mainUrl = new DataContainer("> 1,5 Матч Дома",
                        "/football/top_streaks/over/",
                        Settings.Default.settingAllMatchInHomeTotalOver15, 0, 1, 1);
                    mainUrls.Add(mainUrl);
                }

                if (Settings.Default.cbAllMatchInAwayTotalOver15 == true)
                {
                    var mainUrl = new DataContainer("> 1,5 Матч Гости",
                        "/football/top_streaks/over/",
                        Settings.Default.settingAllMatchInAwayTotalOver15, 0, 2, 1);
                    mainUrls.Add(mainUrl);
                }



                if (Settings.Default.cbFirstTimeInAllTotalUnder05 == true)
                {
                    var mainUrl = new DataContainer("< 0,5 1-й Тайм Всего", "/football/top_streaks/under/",
                        Settings.Default.settingFirstTimeInAllTotalUnder05, 2, 0, 0);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbFirstTimeInHomeTotalUnder05 == true)
                {
                    var mainUrl = new DataContainer("< 0,5 1-й Тайм Дома", "/football/top_streaks/under/",
                        Settings.Default.settingFirstTimeInHomeTotalUnder05, 2, 1, 0);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbFirstTimeInAwayTotalUnder05 == true)
                {
                    var mainUrl = new DataContainer("< 0,5 1-й Тайм Гости", "/football/top_streaks/under/",
                        Settings.Default.settingFirstTimeInAwayTotalUnder05, 2, 2, 0);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbFirstTimeInAllTotalUnder25 == true)
                {
                    var mainUrl = new DataContainer("< 2,5 1-й Тайм Всего", "/football/top_streaks/under/",
                        Settings.Default.settingFirstTimeInAllTotalUnder25, 2, 0, 2);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbFirstTimeInHomeTotalUnder25 == true)
                {
                    var mainUrl = new DataContainer("< 2,5 1-й Тайм Дома", "/football/top_streaks/under/",
                        Settings.Default.settingFirstTimeInHomeTotalUnder25, 2, 1, 2);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbFirstTimeInAwayTotalUnder25 == true)
                {
                    var mainUrl = new DataContainer("< 2,5 1-й Тайм Гости", "/football/top_streaks/under/",
                        Settings.Default.settingFirstTimeInAwayTotalUnder25, 2, 2, 2);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbFirstTimeInAllFailedToScore == true)
                {
                    var mainUrl = new DataContainer("Не забив 1-й Тайм Всего",
                        "/football/top_streaks/failed_to_score/",
                        Settings.Default.settingFirstTimeInAllFailedToScore, 1, 0);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbFirstTimeInHomeFailedToScore == true)
                {
                    var mainUrl = new DataContainer("Не забив 1-й Тайм Дома",
                        "/football/top_streaks/failed_to_score/",
                        Settings.Default.settingFirstTimeInHomeFailedToScore, 1, 1);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbFirstTimeInAwayFailedToScore == true)
                {
                    var mainUrl = new DataContainer("Не забив 1-й Тайм Гости",
                        "/football/top_streaks/failed_to_score/",
                        Settings.Default.settingFirstTimeInAwayFailedToScore, 1, 2);
                    mainUrls.Add(mainUrl);
                }



                if (Settings.Default.cbFirstTimeInAllTotalOver15 == true)
                {
                    var mainUrl = new DataContainer("> 1,5 1-й Тайм Всего",
                        "/football/top_streaks/over/",
                        Settings.Default.settingFirstTimeInAllTotalOver15, 2, 0, 1);
                    mainUrls.Add(mainUrl);
                }

                if (Settings.Default.cbFirstTimeInHomeTotalOver15 == true)
                {
                    var mainUrl = new DataContainer("> 1,5 1-й Тайм Дома",
                        "/football/top_streaks/over/",
                        Settings.Default.settingFirstTimeInHomeTotalOver15, 2, 1, 1);
                    mainUrls.Add(mainUrl);
                }

                if (Settings.Default.cbFirstTimeInAwayTotalOver15 == true)
                {
                    var mainUrl = new DataContainer("> 1,5 1-й Тайм Гости",
                        "/football/top_streaks/over/",
                        Settings.Default.settingFirstTimeInAwayTotalOver15, 2, 2, 1);
                    mainUrls.Add(mainUrl);
                }




                if (Settings.Default.cbSecondTimeInAllTotalUnder05 == true)
                {
                    var mainUrl = new DataContainer("< 0,5 2-й Тайм Всего", "/football/top_streaks/under/",
                        Settings.Default.settingSecondTimeInAllTotalUnder05, 3, 0, 0);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbSecondTimeInHomeTotalUnder05 == true)
                {
                    var mainUrl = new DataContainer("< 0,5 2-й Тайм Дома", "/football/top_streaks/under/",
                        Settings.Default.settingSecondTimeInHomeTotalUnder05, 3, 1, 0);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbSecondTimeInAwayTotalUnder05 == true)
                {
                    var mainUrl = new DataContainer("< 0,5 2-й Тайм Гости", "/football/top_streaks/under/",
                        Settings.Default.settingSecondTimeInAwayTotalUnder05, 3, 2, 0);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbSecondTimeInAllTotalUnder25 == true)
                {
                    var mainUrl = new DataContainer("< 2,5 2-й Тайм Всего", "/football/top_streaks/under/",
                        Settings.Default.settingSecondTimeInAllTotalUnder25, 3, 0, 2);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbSecondTimeInHomeTotalUnder25 == true)
                {
                    var mainUrl = new DataContainer("< 2,5 2-й Тайм Дома", "/football/top_streaks/under/",
                        Settings.Default.settingSecondTimeInHomeTotalUnder25, 3, 1, 2);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbSecondTimeInAwayTotalUnder25 == true)
                {
                    var mainUrl = new DataContainer("< 2,5 2-й Тайм Гости", "/football/top_streaks/under/",
                        Settings.Default.settingSecondTimeInAwayTotalUnder25, 3, 2, 2);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbSecondTimeInAllFailedToScore == true)
                {
                    var mainUrl = new DataContainer("Не забив 2-й Тайм Всего",
                        "/football/top_streaks/failed_to_score/",
                        Settings.Default.settingSecondTimeInAllFailedToScore, 2, 0);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbSecondTimeInHomeFailedToScore == true)
                {
                    var mainUrl = new DataContainer("Не забив 2-й Тайм Дома",
                        "/football/top_streaks/failed_to_score/",
                        Settings.Default.settingSecondTimeInHomeFailedToScore, 2, 1);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbSecondTimeInAwayFailedToScore == true)
                {
                    var mainUrl = new DataContainer("Не забив 2-й Тайм Гости",
                        "/football/top_streaks/failed_to_score/",
                        Settings.Default.settingSecondTimeInAwayFailedToScore, 2, 2);
                    mainUrls.Add(mainUrl);
                }



                if (Settings.Default.cbSecondTimeInAllTotalOver15 == true)
                {
                    var mainUrl = new DataContainer("> 1,5 2-й Тайм Всего",
                        "/football/top_streaks/over/",
                        Settings.Default.settingSecondTimeInAllTotalOver15, 3, 0, 1);
                    mainUrls.Add(mainUrl);
                }

                if (Settings.Default.cbSecondTimeInHomeTotalOver15 == true)
                {
                    var mainUrl = new DataContainer("> 1,5 2-й Тайм Дома",
                        "/football/top_streaks/over/",
                        Settings.Default.settingSecondTimeInHomeTotalOver15, 3, 1, 1);
                    mainUrls.Add(mainUrl);
                }

                if (Settings.Default.cbSecondTimeInAwayTotalOver15 == true)
                {
                    var mainUrl = new DataContainer("> 1,5 2-й Тайм Гости",
                        "/football/top_streaks/over/",
                        Settings.Default.settingSecondTimeInAwayTotalOver15, 3, 2, 1);
                    mainUrls.Add(mainUrl);
                }




                if (Settings.Default.cbAllMatchInAllTotalUnder15 == true)
                {
                    var mainUrl = new DataContainer("< 1,5 Матч Всего", "/football/top_streaks/under/",
                        Settings.Default.settingAllMatchInAllTotalUnder15, 0, 0, 1);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbAllMatchInHomeTotalUnder15 == true)
                {
                    var mainUrl = new DataContainer("< 1,5 Матч Дома", "/football/top_streaks/under/",
                        Settings.Default.settingAllMatchInHomeTotalUnder15, 0, 1, 1);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbAllMatchInAwayTotalUnder15 == true)
                {
                    var mainUrl = new DataContainer("< 1,5 Матч Гости", "/football/top_streaks/under/",
                        Settings.Default.settingAllMatchInAwayTotalUnder15, 0, 2, 1);
                    mainUrls.Add(mainUrl);
                }

                if (Settings.Default.cbAllMatchInAllCleanSheets == true)
                {
                    var mainUrl = new DataContainer("Не проп Матч Всего", "/football/top_streaks/clean_sheets/",
                        Settings.Default.settingAllMatchInAllCleanSheets, 0, 0);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbAllMatchInHomeCleanSheets == true)
                {
                    var mainUrl = new DataContainer("Не проп Матч Дома", "/football/top_streaks/clean_sheets/",
                        Settings.Default.settingAllMatchInHomeCleanSheets, 0, 1);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbAllMatchInAwayCleanSheets == true)
                {
                    var mainUrl = new DataContainer("Не проп Матч Гости", "/football/top_streaks/clean_sheets/",
                        Settings.Default.settingAllMatchInAwayCleanSheets, 0, 2);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbFirstTimeInAllTotalUnder15 == true)
                {
                    var mainUrl = new DataContainer("< 1,5 1-й Тайм Всего", "/football/top_streaks/under/",
                        Settings.Default.settingFirstTimeInAllTotalUnder15, 2, 0, 1);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbFirstTimeInHomeTotalUnder15 == true)
                {
                    var mainUrl = new DataContainer("< 1,5 1-й Тайм Дома", "/football/top_streaks/under/",
                        Settings.Default.settingFirstTimeInHomeTotalUnder15, 2, 1, 1);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbFirstTimeInAwayTotalUnder15 == true)
                {
                    var mainUrl = new DataContainer("< 1,5 1-й Тайм Гости", "/football/top_streaks/under/",
                        Settings.Default.settingFirstTimeInAwayTotalUnder15, 2, 2, 1);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbFirstTimeInAllCleanSheets == true)
                {
                    var mainUrl = new DataContainer("Не проп 1-й Тайм Всего",
                        "/football/top_streaks/clean_sheets/",
                        Settings.Default.settingFirstTimeInAllCleanSheets, 1, 0);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbFirstTimeInHomeCleanSheets == true)
                {
                    var mainUrl = new DataContainer("Не проп 1-й Тайм Дома",
                        "/football/top_streaks/clean_sheets/",
                        Settings.Default.settingFirstTimeInHomeCleanSheets, 1, 1);
                    mainUrls.Add(mainUrl);
                }

                if (Settings.Default.cbFirstTimeInAwayCleanSheets == true)
                {
                    var mainUrl = new DataContainer("Не проп 1-й Тайм Гости",
                        "/football/top_streaks/clean_sheets/",
                        Settings.Default.settingFirstTimeInAwayCleanSheets, 1, 2);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbSecondTimeInAllTotalUnder15 == true)
                {
                    var mainUrl = new DataContainer("< 1,5 2-й Тайм Всего", "/football/top_streaks/under/",
                        Settings.Default.settingSecondTimeInAllTotalUnder15, 3, 0, 1);
                    mainUrls.Add(mainUrl);
                }


                if (Settings.Default.cbSecondTimeInHomeTotalUnder15 == true)
                {
                    var mainUrl = new DataContainer("< 1,5 2-й Тайм Дома", "/football/top_streaks/under/",
                        Settings.Default.settingSecondTimeInHomeTotalUnder15, 3, 1, 1);
                    mainUrls.Add(mainUrl);
                }

                if (Settings.Default.cbSecondTimeInAwayTotalUnder15 == true)
                {
                    var mainUrl = new DataContainer("< 1,5 2-й Тайм Гости", "/football/top_streaks/under/",
                        Settings.Default.settingSecondTimeInAwayTotalUnder15, 3, 2, 1);
                    mainUrls.Add(mainUrl);
                }
                
                if (Settings.Default.cbSecondTimeInAllCleanSheets == true)
                {
                    var mainUrl = new DataContainer("Не проп 2-й Тайм Всего",
                        "/football/top_streaks/clean_sheets/",
                        Settings.Default.settingSecondTimeInAllCleanSheets, 2, 0);
                    mainUrls.Add(mainUrl);
                }

                if (Settings.Default.cbSecondTimeInHomeCleanSheets == true)
                {
                    var mainUrl = new DataContainer("Не проп 2-й Тайм Дома",
                        "/football/top_streaks/clean_sheets/",
                        Settings.Default.settingSecondTimeInHomeCleanSheets, 2, 1);
                    mainUrls.Add(mainUrl);
                }

                if (Settings.Default.cbSecondTimeInAwayCleanSheets == true)
                {
                    var mainUrl = new DataContainer("Не проп 2-й Тайм Гости",
                        "/football/top_streaks/clean_sheets/",
                        Settings.Default.settingSecondTimeInAwayCleanSheets, 2, 2);
                    mainUrls.Add(mainUrl);
                }

            });


            
            return mainUrls;
        }

        private List<DataContainer> getBothFailedToScoreUrls(MainWindow mainWindow)
        {
        var mainUrls = new List<DataContainer>();

            mainWindow.Dispatcher.Invoke(() =>
            {
                if (Settings.Default.cbAllMatchInAllBothFailedToScore == true)
                {
                    var mainUrl = new DataContainer("Не забивали Оба Всего",
                        Settings.Default.settingAllMatchInAllBothFailedToScore, 0, 0);
                    mainUrls.Add(mainUrl);
                }

                if (Settings.Default.cbAllMatchInHomeBothFailedToScore == true)
                {
                    var mainUrl = new DataContainer("Не забивали Оба Дома",
                        Settings.Default.settingAllMatchInHomeBothFailedToScore, 0, 1);
                    mainUrls.Add(mainUrl);
                }

                if (Settings.Default.cbAllMatchInAwayBothFailedToScore == true)
                {
                    var mainUrl = new DataContainer("Не забивали Оба Гости",
                        Settings.Default.settingAllMatchInAwayBothFailedToScore, 0, 2);
                    mainUrls.Add(mainUrl);
                }

                if (Settings.Default.cbFirstTimeInAllBothFailedToScore == true)
                {
                    var mainUrl = new DataContainer("Не заб Оба 1-й Т Всего",
                        Settings.Default.settingFirstTimeInAllBothFailedToScore, 1, 0);
                    mainUrls.Add(mainUrl);
                }

                if (Settings.Default.cbFirstTimeInHomeBothFailedToScore == true)
                {
                    var mainUrl = new DataContainer("Не заб Оба 1-й Т Дома",
                        Settings.Default.settingFirstTimeInHomeBothFailedToScore, 1, 1);
                    mainUrls.Add(mainUrl);
                }

                if (Settings.Default.cbFirstTimeInAwayBothFailedToScore == true)
                {
                    var mainUrl = new DataContainer("Не заб Оба 1-й Т Гости",
                        Settings.Default.settingFirstTimeInAwayBothFailedToScore, 1, 2);
                    mainUrls.Add(mainUrl);
                }

                if (Settings.Default.cbSecondTimeInAllBothFailedToScore == true)
                {
                    var mainUrl = new DataContainer("Не заб Оба 2-й Т Всего",
                        Settings.Default.settingSecondTimeInAllBothFailedToScore, 2, 0);
                    mainUrls.Add(mainUrl);
                }

                if (Settings.Default.cbSecondTimeInHomeBothFailedToScore == true)
                {
                    var mainUrl = new DataContainer("Не заб Оба 2-й Т Дома",
                        Settings.Default.settingSecondTimeInHomeBothFailedToScore, 2, 1);
                    mainUrls.Add(mainUrl);
                }

                if (Settings.Default.cbSecondTimeInAwayBothFailedToScore == true)
                {
                    var mainUrl = new DataContainer("Не заб Оба 2-й Т Гости",
                        Settings.Default.settingSecondTimeInAwayBothFailedToScore, 2, 2);
                    mainUrls.Add(mainUrl);
                }
            });
            return mainUrls;
        }

        private List<FormDataMatches> getFormDataMatchesBothFailedToScore(MainWindow mainWindow,
            List<DateTime> currentDateTimes)
        {
        var formDataList = new List<FormDataMatches>();

            //делаем еще один цикл for на каждый день(если не только сегодня, но еще завтра и послезавтра)
            for (int day = 0; day < currentDateTimes.Count; day++)
            {
                List<Thread> threads = new List<Thread>();
                object lockFormData = new object();

                //потом это все нужно либо в другую функцию либо как то инкапсулировать попробовать 
                GetRequestt browMain = new GetRequestt();
                browMain.Get("https://24score.pro/?date=" + String.Format("{0:yyyy-MM-dd}", currentDateTimes[day]));

                string tagDayMatches = ExtractHTML.ExtractTag(browMain.Document, "table", "class=\"daymatches\"");

                List<string> allLeague = new List<string>();
                allLeague.AddRange(ExtractHTML.ExtractTagsCollection(tagDayMatches, "tbody"));

                //сначала проходимя по всем лигам в for i
                //затем в for j парсим каждый матч в лиге, заносим эти данные в листы ниже, на каждую пару команд своя строка в каждом листе 
                //далее в новом потоке открываем ссылку лиги, в for j проходимся по каждой нужной серии из чекбоксов отмеченных пользователем в мейн форме  
                //в for k уже получив нужную форму проходимся по всем командам в таблице
                //в for l проверяем не одна ли это из наших команд
                for (int i = 0; i < allLeague.Count; i++)
                {
                    try
                    {
                        List<string> matchesInLeague = new List<string>();
                        matchesInLeague.AddRange(ExtractHTML.ExtractTagsCollection(allLeague[i], "tr"));

                        string nameLeague =
                            ExtractHTML.ExtractTagInnerHTML(
                                ExtractHTML.ExtractTagInnerHTML(matchesInLeague[0], "th"), "a");
                        string urlLeague =
                            ExtractHTML.ExtractAttributeValue(
                                ExtractHTML.ExtractTagInnerHTML(matchesInLeague[0], "th"),
                                "a href");

                        var nameCommands1 = new List<string>();
                        var nameCommands2 = new List<string>();
                        var timeMatches = new List<string>();
                        var dateMatches = new List<string>();

                        //парсим от единицы потому что первый номер это хидер, а не пара матчей
                        for (int j = 1; j < matchesInLeague.Count; j++)
                        {
                            if (ExtractHTML.ExtractAttributeValue(matchesInLeague[j], "class") == "even" ||
                                ExtractHTML.ExtractAttributeValue(matchesInLeague[j], "class") == "odd")
                            {
                                nameCommands1.Add(ExtractHTML.ExtractTagInnerHTML(
                                    ExtractHTML.ExtractTagInnerHTML(matchesInLeague[j], "td", "class=\"team tm1\""),
                                    "a"));

                                nameCommands2.Add(ExtractHTML.ExtractTagInnerHTML(
                                    ExtractHTML.ExtractTagInnerHTML(matchesInLeague[j], "td", "class=\"team tm2\""),
                                    "a"));

                                string timeMatch = ExtractHTML
                                    .ExtractTagInnerHTML(matchesInLeague[j], "td", "class=\"time\"").Trim();
                                if (timeMatch.Contains("<span"))
                                    timeMatch = ExtractHTML
                                        .ExtractTagInnerHTML(matchesInLeague[j], "td", "class=\"time\"")
                                        .Remove(
                                            ExtractHTML.ExtractTagInnerHTML(matchesInLeague[j], "td",
                                                    "class=\"time\"")
                                                .IndexOf("<span")).Trim();
                                timeMatches.Add(timeMatch);

                                string currentDate = ExtractHTML.ExtractTagInnerHTML(browMain.Document, "div",
                                    "class=\"current_date\"");
                                if (currentDate.Remove(currentDate.IndexOf(" ")).Length == 1)
                                    currentDate = "0" + currentDate;
                                currentDate = String.Format("{0:dd.MM.yyyy}",
                                    DateTime.ParseExact(currentDate, "dd MMMM yyyy",
                                        CultureInfo.CreateSpecificCulture("ru-RU")));

                                dateMatches.Add(currentDate);
                            }
                        }

                        //получаем контейнеры, котоыре отмечены чекбоксом, и получаим их номера в таблицах для дальнейшего парса
                        var containersBothFailedToScore = new List<DataContainer>();
                        containersBothFailedToScore = getBothFailedToScoreUrls(mainWindow);

                        //делаем проверку на наличие standings в url, у лиг, вроде кубков, такого нет и они нам соответственно не нужны
                        if (urlLeague.Contains("standings/"))
                        {
                            //поток скорее всего будет использовать разные данные, которые выше, их нужно будет передать в него сначала.
                            Thread thread = new Thread(() =>
                            {
                                try
                                {
                                    var browser = new GetRequestt();

                                    //так же здесь парсим ключ, так как нужна информация подгружается js скриптом
                                    browser.Get("https://24score.pro" +
                                                urlLeague.Replace("standings/", "both_teams_scored/"));
                                    reconnectBrowser(browser, "https://24score.pro" +
                                                              urlLeague.Replace("standings/", "both_teams_scored/"));
                                    string key = browser.Document.Substring("data: {\"data_key\" : \"", "\"}");
                                    browser.Get("https://24score.pro/backend/load_page_data.php?data_key=" + key);
                                    reconnectBrowser(browser, "https://24score.pro/backend/load_page_data.php?data_key=" + key);

                                    for (int j = 0; j < containersBothFailedToScore.Count; j++)
                                    {
                                        string divAllMatchOrHalf = ExtractHTML.ExtractTagInnerHTML(
                                            ExtractHTML.ExtractTagsCollection(browser.Document, "div",
                                                "class=\"data-tab data_times")[
                                                containersBothFailedToScore[j].divAllMatchOrHalf], "div",
                                            "class=\"data-tab");
                                        string mainDiv =
                                            ExtractHTML.ExtractTagsCollection(divAllMatchOrHalf, "div",
                                                "class=\"data-tab")[
                                                containersBothFailedToScore[j].divAllHomeAway];
                                        string dataTable =
                                            ExtractHTML.ExtractTagInnerHTML(mainDiv, "table",
                                                "class=\"t4 evenodd sort\"");

                                        lock (lockFormData)
                                        {
                                            var trMatches = new List<string>();
                                            trMatches.AddRange(ExtractHTML.ExtractTagsCollection(dataTable, "tr"));

                                            //от 1 и до -1, потому что первый и послудний элементы это хидер и футер
                                            for (var k = 1; k < trMatches.Count - 1; k++)
                                            {

                                                var tdMatch = new List<string>();
                                                tdMatch.AddRange(ExtractHTML.ExtractTagsCollection(trMatches[k], "td"));

                                                string nameCommand =
                                                    ExtractHTML.ExtractTagInnerHTML(tdMatch[0], "a").Trim();
                                                string url = ExtractHTML.ExtractAttributeValue(tdMatch[0], "href");
                                                string countSerie = ExtractHTML.ExtractTagInnerHTML(tdMatch[5], "td")
                                                    .Trim();

                                                //проверяем минусовая ли серия, и сравниваем подходит ли под количество серий
                                                if ((Convert.ToInt32(countSerie) < 0) &&
                                                    ((Convert.ToInt32(countSerie.Replace("-", "")) >=
                                                      containersBothFailedToScore[j].countSerie)))
                                                {
                                                    //теперь проверяем одна ли это из наших команд или нет
                                                    for (var l = 0; l < nameCommands1.Count; l++)
                                                    {
                                                        try
                                                        {
                                                            if (nameCommands1[l] == nameCommand)
                                                            {
                                                                var formMatch = new FormDataMatches(nameLeague,
                                                                    nameCommands1[l] + " - " + nameCommands2[l],
                                                                    timeMatches[l], dateMatches[l], nameCommands1[l],
                                                                    containersBothFailedToScore[j].nameSerie,
                                                                    Convert.ToInt32(countSerie.Replace("-", "")), url);
                                                                formDataList.Add(formMatch);
                                                            }
                                                            else if (nameCommands2[l] == nameCommand)
                                                            {
                                                                var formMatch = new FormDataMatches(nameLeague,
                                                                    nameCommands1[l] + " - " + nameCommands2[l],
                                                                    timeMatches[l], dateMatches[l], nameCommands2[l],
                                                                    containersBothFailedToScore[j].nameSerie,
                                                                    Convert.ToInt32(countSerie.Replace("-", "")), url);
                                                                formDataList.Add(formMatch);
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Console.WriteLine("Exception in search matches in " + ex);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Exception in thread, parsing DataContainer: " + ex);
                                }

                            });
                            threads.Add(thread);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception with scrab leagues in man page: " + ex);
                    }
                }
                foreach (var thread in threads) thread.Start();
                foreach (var thread in threads) thread.Join();
            }
            return formDataList;
        }


        public List<FormDataMatches> getFormDataMatches(MainWindow mainWindow, List<DateTime> currentDateTimes)
        {
            var formDataList = new List<FormDataMatches>();

            formDataList.AddRange(getFormDataMatchesTotalsAndFailedCleanSheets(mainWindow, currentDateTimes));
            formDataList.AddRange(getFormDataMatchesBothFailedToScore(mainWindow, currentDateTimes));

            return formDataList;
        }

        private List<FormDataMatches> getFormDataMatchesTotalsAndFailedCleanSheets(MainWindow mainWindow, List<DateTime> currentDateTimes)
        {
            List<Thread> threads = new List<Thread>();
            object lockFormData = new object();

            var formDataList = new List<FormDataMatches>();
            var containersTotalsAndFailedCleanSheets = new List<DataContainer>();
            containersTotalsAndFailedCleanSheets = getTotalsAndFailedCleanSheetsUrls(mainWindow);

            for (int i = 0; i < containersTotalsAndFailedCleanSheets.Count; i++)
            {
                // когда делаем цикл в том же методе, в котором и делаем потоки, то переменная i всегда будет одного значения, последнего.
                // чтобы нам в каждом потоке использовать свое значение i ее нужно было передать в переменную локальную, которая создается для каждого потока
                int normali = i;
                Thread thread = new Thread(() =>
                {
                    try
                    {
                        var browser = new GetRequestt();
                        //возможно лочить придется с начала обращения к list mainUrl
                        browser.Get("https://24score.pro" + containersTotalsAndFailedCleanSheets[normali].url);
                        reconnectBrowser(browser, "https://24score.pro" + containersTotalsAndFailedCleanSheets[normali].url);

                        //сервер дает инфу для js скрипта по гет запросу и ключу, который он сам генерит при обращении.
                        //поэтому просто подключаемся к странице забираем ключ и делаем запрос с ключом, получаем то, что нужно
                        string key = browser.Document.Substring("data: {\"data_key\" : \"", "\"}");
                        browser.Get("https://24score.pro/backend/load_page_data.php?data_key=" + key);
                        reconnectBrowser(browser, "https://24score.pro/backend/load_page_data.php?data_key=" + key);

                        //получаем конкретный лист с матчами нужной серии
                        // string DataContainer = ExtractHTML.ExtractTag(browser.Document, "div", "id=\"data_container\"");
                        string divAllMatchOrHalf =
                            ExtractHTML.ExtractTagsCollection(browser.Document, "div", "class=\"data-tab data-level1")[
                                containersTotalsAndFailedCleanSheets[normali].divAllMatchOrHalf];
                        string mainDiv =
                            ExtractHTML.ExtractTagsCollection(divAllMatchOrHalf, "div", "class=\"data-tab data-level2")[
                                containersTotalsAndFailedCleanSheets[normali].divAllHomeAway];
                        if (containersTotalsAndFailedCleanSheets[normali].divTotals != 0)
                            mainDiv = ExtractHTML.ExtractTagsCollection(mainDiv, "div", "class=\"data-tab data-level3")[
                                containersTotalsAndFailedCleanSheets[normali].divTotals];
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
                                DateTime nextDateTime = DateTime.ParseExact(nextDate, "dd.MM.yyyy",
                                    System.Globalization.CultureInfo.InvariantCulture);
                                string nextTime = ExtractHTML.ExtractTagInnerHTML(tdMatch[2], "span").Trim();

                                string nextMatch = tdMatch[2].Substring("/span>", "</td>");
                                nextMatch = nextMatch.Replace("&nbsp;", "");
                                nextMatch = nextMatch.Trim();
                                string countSerie = ExtractHTML.ExtractTagInnerHTML(tdMatch[3], "td").Trim();

                                //делаем проверку на нужное количество серий и на ту ли дату следующий матч(сегодня или сегодня, завтра, послезавтра)
                                if (Convert.ToInt32(countSerie) >=
                                    containersTotalsAndFailedCleanSheets[normali].countSerie)
                                {
                                    foreach (var date in currentDateTimes)
                                    {
                                        if (date.Date == nextDateTime.Date)
                                        {
                                            var formMatch = new FormDataMatches(nameLeague, nextMatch, nextTime,
                                                nextDate, nameCommand,
                                                containersTotalsAndFailedCleanSheets[normali].nameSerie,
                                                Convert.ToInt32(countSerie), url);
                                            formDataList.Add(formMatch);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception in thread, parsing DataContainer: " + ex);
                    }

                });
                threads.Add(thread);
            }
            foreach (var thread in threads) thread.Start();
            foreach (var thread in threads) thread.Join();

            return formDataList;
        }

        //при большом количестве потоков браузер может не загружать некторые страницы, и нужно делать несколько (зачастую еще одну) попытку
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
    }
}
