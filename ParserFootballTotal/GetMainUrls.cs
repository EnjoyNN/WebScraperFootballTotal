using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using ParserFootballTotal.Properties;

namespace ParserFootballTotal
{
    class GetMainUrls
    {
        private void getUrls(MainWindow mainWindow)
        {
            var mainUrls = new List<MainUrl>();


            if (mainWindow.cbAllMatchInAllTotalUnder05.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingAllMatchInAllTotalUnder05);
                //*[@id="data_container"]/div[2]/div[2]/div[2]/table/tbody/tr[2]
            }

            //Content = "&lt; 0,5 Матч Всего" IsChecked = "True" / >

            if (mainWindow.cbAllMatchInHomeTotalUnder05.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingAllMatchInHomeTotalUnder05);
                //*[@id="data_container"]/div[2]/div[3]/div[2]/table/tbody/tr[2]
            }

            //Content = "&lt; 0,5 Матч Дома" IsChecked = "True" / >

            if (mainWindow.cbAllMatchInAwayTotalUnder05.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingAllMatchInAwayTotalUnder05);
                //*[@id="data_container"]/div[2]/div[4]/div[2]/table/tbody/tr[2]
            }

            //Content = "&lt; 0,5 Матч Гости" IsChecked = "True" / >

            if (mainWindow.cbAllMatchInAllTotalUnder25.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingAllMatchInAllTotalUnder25);
                //*[@id="data_container"]/div[2]/div[2]/div[4]/table/tbody/tr[2]
            }

            //Content = "&lt; 2,5 Матч Всего" IsChecked = "True" / >

            if (mainWindow.cbAllMatchInHomeTotalUnder25.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingAllMatchInHomeTotalUnder25);
                //*[@id="data_container"]/div[2]/div[3]/div[4]/table/tbody/tr[2]
            }

            //Content = "&lt; 2,5 Матч Дома" IsChecked = "True" / >

            if (mainWindow.cbAllMatchInAwayTotalUnder25.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingAllMatchInAwayTotalUnder25);
                //*[@id="data_container"]/div[2]/div[4]/div[4]/table/tbody/tr[2]
            }

            //Content = "&lt; 2,5 Матч Гости" IsChecked = "True" / >

            if (mainWindow.cbAllMatchInAllFailedToScore.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/failed_to_score/",
                    Settings.Default.settingAllMatchInAllFailedToScore);
                //*[@id="data_container"]/div[2]/div[2]/div/table/tbody/tr[2]
            }

            //Content = "Не забив Матч Всего" IsChecked = "True" / >

            if (mainWindow.cbAllMatchInHomeFailedToScore.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/failed_to_score/",
                    Settings.Default.settingAllMatchInHomeFailedToScore);
                //*[@id="data_container"]/div[2]/div[3]/div/table/tbody/tr[2]
            }

            //Content = "Не забив Матч Дома" IsChecked = "True" / >

            if (mainWindow.cbAllMatchInAwayFailedToScore.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/failed_to_score/",
                    Settings.Default.settingAllMatchInAwayFailedToScore);
                //*[@id="data_container"]/div[2]/div[4]/div/table/tbody/tr[2]
            }

            //Content = "Не забив Матч Гости" IsChecked = "True" / >


            if (mainWindow.cbFirstTimeInAllTotalUnder05.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingFirstTimeInAllTotalUnder05);
                //*[@id="data_container"]/div[4]/div[2]/div[2]/table/tbody/tr[2]
            }

            //Content = "&lt; 0,5 1-й Тайм Всего" IsChecked = "True" / >

            if (mainWindow.cbFirstTimeInHomeTotalUnder05.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingFirstTimeInHomeTotalUnder05);
                //*[@id="data_container"]/div[4]/div[3]/div[2]/table/tbody/tr[3]
            }

            //Content = "&lt; 0,5 1-й Тайм Дома" IsChecked = "True" / >

            if (mainWindow.cbFirstTimeInAwayTotalUnder05.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingFirstTimeInAwayTotalUnder05);
                //*[@id="data_container"]/div[4]/div[4]/div[2]/table/tbody/tr[2]
            }

            //Content = "&lt; 0,5 1-й Тайм Гости" IsChecked = "True" / >

            if (mainWindow.cbFirstTimeInAllTotalUnder25.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingFirstTimeInAllTotalUnder25);
                //*[@id="data_container"]/div[4]/div[2]/div[4]/table/tbody/tr[2]
            }

            //Content = "&lt; 2,5 1-й Тайм Всего" IsChecked = "True" / >

            if (mainWindow.cbFirstTimeInHomeTotalUnder25.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingFirstTimeInHomeTotalUnder25);
                //*[@id="data_container"]/div[4]/div[3]/div[4]/table/tbody/tr[2]
            }

            //Content = "&lt; 2,5 1-й Тайм Дома" IsChecked = "True" / >

            if (mainWindow.cbFirstTimeInAwayTotalUnder25.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingFirstTimeInAwayTotalUnder25);
                //*[@id="data_container"]/div[4]/div[4]/div[4]/table/tbody/tr[2]
            }

            //Content = "&lt; 2,5 1-й Тайм Гости" IsChecked = "True" / >

            if (mainWindow.cbFirstTimeInAllFailedToScore.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/failed_to_score/",
                    Settings.Default.settingFirstTimeInAllFailedToScore);
                //*[@id="data_container"]/div[3]/div[2]/div/table/tbody/tr[2]
            }

            //Content = "Не забив 1-й Тайм Всего" IsChecked = "True" / >

            if (mainWindow.cbFirstTimeInHomeFailedToScore.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/failed_to_score/",
                    Settings.Default.settingFirstTimeInHomeFailedToScore);
                //*[@id="data_container"]/div[3]/div[3]/div/table/tbody/tr[2]
            }

            //Content = "Не забив 1-й Тайм Дома" IsChecked = "True" / >

            if (mainWindow.cbFirstTimeInAwayFailedToScore.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/failed_to_score/",
                    Settings.Default.settingFirstTimeInAwayFailedToScore);
                //*[@id="data_container"]/div[3]/div[4]/div/table/tbody/tr[2]
            }

            //Content = "Не забив 1-й Тайм Гости" IsChecked = "True" / >


            if (mainWindow.cbSecondTimeInAllTotalUnder05.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingSecondTimeInAllTotalUnder05);
                //*[@id="data_container"]/div[5]/div[2]/div[2]/table/tbody/tr[2]
            }

            //Content = "&lt; 0,5 2-й Тайм Всего" IsChecked = "True" / >

            if (mainWindow.cbSecondTimeInHomeTotalUnder05.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingSecondTimeInHomeTotalUnder05);
                //*[@id="data_container"]/div[5]/div[3]/div[2]/table/tbody/tr[2]
            }

            //Content = "&lt; 0,5 2-й Тайм Дома" IsChecked = "True" / >

            if (mainWindow.cbSecondTimeInAwayTotalUnder05.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingSecondTimeInAwayTotalUnder05);
                //*[@id="data_container"]/div[5]/div[4]/div[2]/table/tbody/tr[2]
            }

            //Content = "&lt; 0,5 2-й Тайм Гости" IsChecked = "True" / >

            if (mainWindow.cbSecondTimeInAllTotalUnder25.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingSecondTimeInAllTotalUnder25);
                //*[@id="data_container"]/div[5]/div[2]/div[4]/table/tbody/tr[2]
            }

            //Content = "&lt; 2,5 2-й Тайм Всего" IsChecked = "True" / >

            if (mainWindow.cbSecondTimeInHomeTotalUnder25.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingSecondTimeInHomeTotalUnder25);
                //*[@id="data_container"]/div[5]/div[3]/div[4]/table/tbody/tr[2]
            }

            //Content = "&lt; 2,5 2-й Тайм Дома" IsChecked = "True" / >

            if (mainWindow.cbSecondTimeInAwayTotalUnder25.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingSecondTimeInAwayTotalUnder25);
                //*[@id="data_container"]/div[5]/div[4]/div[4]/table/tbody/tr[2]
            }

            //Content = "&lt; 2,5 2-й Тайм Гости" IsChecked = "True" / >

            if (mainWindow.cbSecondTimeInAllFailedToScore.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/failed_to_score/",
                    Settings.Default.settingSecondTimeInAllFailedToScore);
                //*[@id="data_container"]/div[4]/div[2]/div/table/tbody/tr[2]
            }

            //Content = "Не забив 2-й Тайм Всего" IsChecked = "True" / >

            if (mainWindow.cbSecondTimeInHomeFailedToScore.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/failed_to_score/",
                    Settings.Default.settingSecondTimeInHomeFailedToScore);
                //*[@id="data_container"]/div[4]/div[3]/div/table/tbody/tr[2]
            }

            //Content = "Не забив 2-й Тайм Дома" IsChecked = "True" / >

            if (mainWindow.cbSecondTimeInAwayFailedToScore.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/failed_to_score/",
                    Settings.Default.settingSecondTimeInAwayFailedToScore);
                //*[@id="data_container"]/div[4]/div[4]/div/table/tbody/tr[2]
            }

            //Content = "Не забив 2-й Тайм Гости" IsChecked = "True" / >


            if (mainWindow.cbAllMatchInAllTotalUnder15.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingAllMatchInAllTotalUnder15);
                //*[@id="data_container"]/div[2]/div[2]/div[3]/table/tbody/tr[2]
            }

            //Content = "&lt; 1,5 Матч Всего" IsChecked = "True" / >

            if (mainWindow.cbAllMatchInHomeTotalUnder15.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingAllMatchInHomeTotalUnder15);
                //*[@id="data_container"]/div[2]/div[3]/div[3]/table/tbody/tr[2]
            }

            //Content = "&lt; 1,5 Матч Дома" IsChecked = "True" / >

            if (mainWindow.cbAllMatchInAwayTotalUnder15.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingAllMatchInAwayTotalUnder15);
                //*[@id="data_container"]/div[2]/div[4]/div[3]/table/tbody/tr[2]
            }

            //Content = "&lt; 1,5 Матч Гости" IsChecked = "True" / >

            if (mainWindow.cbAllMatchInAllCleanSheets.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/clean_sheets/",
                    Settings.Default.settingAllMatchInAllCleanSheets);
                //*[@id="data_container"]/div[2]/div[2]/div/table/tbody/tr[2]
            }

            //Content = "Не проп Матч Всего" IsChecked = "True" / >

            if (mainWindow.cbAllMatchInHomeCleanSheets.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/clean_sheets/",
                    Settings.Default.settingAllMatchInHomeCleanSheets);
                //*[@id="data_container"]/div[2]/div[3]/div/table/tbody/tr[2]
            }

            //Content = "Не проп Матч Дома" IsChecked = "True" / >

            if (mainWindow.cbAllMatchInAwayCleanSheets.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/clean_sheets/",
                    Settings.Default.settingAllMatchInAwayCleanSheets);
                //*[@id="data_container"]/div[2]/div[4]/div/table/tbody/tr[2]
            }

            //Content = "Не проп Матч Гости" IsChecked = "True" / >

            if (mainWindow.cbAllMatchInAllBothFailedToScore.IsChecked == true)
            {
                var mainUrl = new MainUrl("", Settings.Default.settingAllMatchInAllBothFailedToScore);
            }

            //Content = "Не забивали Оба Матч" IsChecked = "True" / >

            if (mainWindow.cbAllMatchInHomeBothFailedToScore.IsChecked == true)
            {
                var mainUrl = new MainUrl("", Settings.Default.settingAllMatchInHomeBothFailedToScore);

            }

            //Content = "Не забивали Оба Дома" IsChecked = "True" / >

            if (mainWindow.cbAllMatchInAwayBothFailedToScore.IsChecked == true)
            {
                var mainUrl = new MainUrl("", Settings.Default.settingAllMatchInAwayBothFailedToScore);

            }

            //Content = "Не забивали Оба Гости" IsChecked = "True" / >


            if (mainWindow.cbFirstTimeInAllTotalUnder15.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingFirstTimeInAllTotalUnder15);
                //*[@id="data_container"]/div[4]/div[2]/div[3]/table/tbody/tr[2]
            }

            //Content = "&lt; 1,5 1-й Тайм Всего" IsChecked = "True" / >

            if (mainWindow.cbFirstTimeInHomeTotalUnder15.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingFirstTimeInHomeTotalUnder15);
                //*[@id="data_container"]/div[4]/div[3]/div[3]/table/tbody/tr[2]
            }

            //Content = "&lt; 1,5 1-й Тайм Дома" IsChecked = "True" / >

            if (mainWindow.cbFirstTimeInAwayTotalUnder15.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingFirstTimeInAwayTotalUnder15);
                //*[@id="data_container"]/div[4]/div[4]/div[3]/table/tbody/tr[2]
            }

            //Content = "&lt; 1,5 1-й Тайм Гости" IsChecked = "True" / >

            if (mainWindow.cbFirstTimeInAllCleanSheets.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/clean_sheets/",
                    Settings.Default.settingFirstTimeInAllCleanSheets);
                //*[@id="data_container"]/div[3]/div[2]/div/table/tbody/tr[2]
            }

            //Content = "Не проп 1-й Тайм Всего" IsChecked = "True" / >

            if (mainWindow.cbFirstTimeInHomeCleanSheets.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/clean_sheets/",
                    Settings.Default.settingFirstTimeInHomeCleanSheets);
                //*[@id="data_container"]/div[3]/div[3]/div/table/tbody/tr[2]
            }

            //Content = "Не проп 1-й Тайм Дома" IsChecked = "True" / >

            if (mainWindow.cbFirstTimeInAwayCleanSheets.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/clean_sheets/",
                    Settings.Default.settingFirstTimeInAwayCleanSheets);
                //*[@id="data_container"]/div[3]/div[4]/div/table/tbody/tr[2]
            }

            //Content = "Не проп 1-й Тайм Гости" IsChecked = "True" / >

            if (mainWindow.cbFirstTimeInAllBothFailedToScore.IsChecked == true)
            {
                var mainUrl = new MainUrl("", Settings.Default.settingFirstTimeInAllBothFailedToScore);

            }

            //Content = "Не забив Оба 1-й Тайм" IsChecked = "True" / >

            if (mainWindow.cbFirstTimeInHomeBothFailedToScore.IsChecked == true)
            {
                var mainUrl = new MainUrl("", Settings.Default.settingFirstTimeInHomeBothFailedToScore);

            }

            //Content = "Не заб Оба 1-й Т Дома" IsChecked = "True" / >

            if (mainWindow.cbFirstTimeInAwayBothFailedToScore.IsChecked == true)
            {
                var mainUrl = new MainUrl("", Settings.Default.settingFirstTimeInAwayBothFailedToScore);

            }

            //Content = "Не заб Оба 1-й Т Гости" IsChecked = "True" / >


            if (mainWindow.cbSecondTimeInAllTotalUnder15.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingSecondTimeInAllTotalUnder15);
                //*[@id="data_container"]/div[5]/div[2]/div[3]/table/tbody/tr[2]
            }

            //Content = "&lt; 1,5 2-й Тайм Всего" IsChecked = "True" / >

            if (mainWindow.cbSecondTimeInHomeTotalUnder15.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingSecondTimeInHomeTotalUnder15);
                //*[@id="data_container"]/div[5]/div[3]/div[3]/table/tbody/tr[2]
            }

            //Content = "&lt; 1,5 2-й Тайм Дома" IsChecked = "True" / >

            if (mainWindow.cbSecondTimeInAwayTotalUnder15.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/under/",
                    Settings.Default.settingSecondTimeInAwayTotalUnder15);
                //*[@id="data_container"]/div[5]/div[4]/div[3]/table/tbody/tr[2]
            }

            //Content = "&lt; 1,5 2-й Тайм Гости" IsChecked = "True" / >

            if (mainWindow.cbSecondTimeInAllCleanSheets.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/clean_sheets/",
                    Settings.Default.settingSecondTimeInAllCleanSheets);
                //*[@id="data_container"]/div[4]/div[2]/div/table/tbody/tr[2]
            }

            //Content = "Не проп 2-й Тайм Всего" IsChecked = "True" / >

            if (mainWindow.cbSecondTimeInHomeCleanSheets.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/clean_sheets/",
                    Settings.Default.settingSecondTimeInHomeCleanSheets);
                //*[@id="data_container"]/div[4]/div[3]/div/table/tbody/tr[2]
            }

            //Content = "Не проп 2-й Тайм Дома" IsChecked = "True" / >

            if (mainWindow.cbSecondTimeInAwayCleanSheets.IsChecked == true)
            {
                var mainUrl = new MainUrl("/football/top_streaks/clean_sheets/",
                    Settings.Default.settingSecondTimeInAwayCleanSheets);
                //*[@id="data_container"]/div[4]/div[4]/div/table/tbody/tr[2]
            }

            //Content = "Не проп 2-й Тайм Гости" IsChecked = "True" / >

            if (mainWindow.cbSecondTimeInAllBothFailedToScore.IsChecked == true)
            {
                var mainUrl = new MainUrl("", Settings.Default.settingSecondTimeInAllBothFailedToScore);

            }

            //Content = "Не забив Оба 2-й Тайм" IsChecked = "True" / >

            if (mainWindow.cbSecondTimeInHomeBothFailedToScore.IsChecked == true)
            {
                var mainUrl = new MainUrl("", Settings.Default.settingSecondTimeInHomeBothFailedToScore);

            }

            //Content = "Не заб Оба 2-й Т Дома" IsChecked = "True" / >

            if (mainWindow.cbSecondTimeInAwayBothFailedToScore.IsChecked == true)
            {
                var mainUrl = new MainUrl("", Settings.Default.settingSecondTimeInAwayBothFailedToScore);

            }

            //Content = "Не заб Оба 2-й Т Гости" IsChecked = "True" / >
        }
    }
}
