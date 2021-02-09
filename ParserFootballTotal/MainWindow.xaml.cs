using Microsoft.Win32;
using ParserFootballTotal.Properties;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Serialization;

namespace ParserFootballTotal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorkerClass backWorker = new BackgroundWorkerClass();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        public void CompletedWork()
        {
            labelStatus.Content = "Статус: Не работает";
            SaveSettings.IsEnabled = true;
            LoadSettings.IsEnabled = true;
            buttonStartThreeDays.IsEnabled = true;
            buttonStartToday.IsEnabled = true;
            gridCheckBoxes.IsEnabled = true;
            progressBarMain.Value = 0;
        }

        private void DisableFormAndRefreshVariables()
        {
            labelStatus.Content = "Статус: Поиск матчей";
            SaveSettings.IsEnabled = false;
            LoadSettings.IsEnabled = false;
            buttonStartThreeDays.IsEnabled = false;
            buttonStartToday.IsEnabled = false;
            gridCheckBoxes.IsEnabled = false;
        }

        private void buttonMin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void buttonX_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void buttonStartToday_Click(object sender, RoutedEventArgs e)
        {
            DisableFormAndRefreshVariables();
            AcceptSettings();
            backWorker.Start("сегодня", this);
        }

        private void buttonStartThreeDays_Click(object sender, RoutedEventArgs e)
        {
            DisableFormAndRefreshVariables();
            AcceptSettings();
            backWorker.Start("сегодня, завтра, послезавтра", this);
        }

        //дальше то, что перенес с setting'сов


        private void AcceptSettings()
        {
            Settings.Default.settingAllMatchInAllTotalUnder05 = Convert.ToInt32(tbAllMatchInAllTotalUnder05.Text);
            Settings.Default.settingAllMatchInHomeTotalUnder05 = Convert.ToInt32(tbAllMatchInHomeTotalUnder05.Text);
            Settings.Default.settingAllMatchInAwayTotalUnder05 = Convert.ToInt32(tbAllMatchInAwayTotalUnder05.Text);
            Settings.Default.settingAllMatchInAllTotalUnder25 = Convert.ToInt32(tbAllMatchInAllTotalUnder25.Text);
            Settings.Default.settingAllMatchInHomeTotalUnder25 = Convert.ToInt32(tbAllMatchInHomeTotalUnder25.Text);
            Settings.Default.settingAllMatchInAwayTotalUnder25 = Convert.ToInt32(tbAllMatchInAwayTotalUnder25.Text);
            Settings.Default.settingAllMatchInAllFailedToScore = Convert.ToInt32(tbAllMatchInAllFailedToScore.Text);
            Settings.Default.settingAllMatchInHomeFailedToScore = Convert.ToInt32(tbAllMatchInHomeFailedToScore.Text);
            Settings.Default.settingAllMatchInAwayFailedToScore = Convert.ToInt32(tbAllMatchInAwayFailedToScore.Text);
            Settings.Default.settingFirstTimeInAllTotalUnder05 = Convert.ToInt32(tbFirstTimeInAllTotalUnder05.Text);
            Settings.Default.settingFirstTimeInHomeTotalUnder05 = Convert.ToInt32(tbFirstTimeInHomeTotalUnder05.Text);
            Settings.Default.settingFirstTimeInAwayTotalUnder05 = Convert.ToInt32(tbFirstTimeInAwayTotalUnder05.Text);
            Settings.Default.settingFirstTimeInAllTotalUnder25 = Convert.ToInt32(tbFirstTimeInAllTotalUnder25.Text);
            Settings.Default.settingFirstTimeInHomeTotalUnder25 = Convert.ToInt32(tbFirstTimeInHomeTotalUnder25.Text);
            Settings.Default.settingFirstTimeInAwayTotalUnder25 = Convert.ToInt32(tbFirstTimeInAwayTotalUnder25.Text);
            Settings.Default.settingFirstTimeInAllFailedToScore = Convert.ToInt32(tbFirstTimeInAllFailedToScore.Text);
            Settings.Default.settingFirstTimeInHomeFailedToScore = Convert.ToInt32(tbFirstTimeInHomeFailedToScore.Text);
            Settings.Default.settingFirstTimeInAwayFailedToScore = Convert.ToInt32(tbFirstTimeInAwayFailedToScore.Text);
            Settings.Default.settingSecondTimeInAllTotalUnder05 = Convert.ToInt32(tbSecondTimeInAllTotalUnder05.Text);
            Settings.Default.settingSecondTimeInHomeTotalUnder05 = Convert.ToInt32(tbSecondTimeInHomeTotalUnder05.Text);
            Settings.Default.settingSecondTimeInAwayTotalUnder05 = Convert.ToInt32(tbSecondTimeInAwayTotalUnder05.Text);
            Settings.Default.settingSecondTimeInAllTotalUnder25 = Convert.ToInt32(tbSecondTimeInAllTotalUnder25.Text);
            Settings.Default.settingSecondTimeInHomeTotalUnder25 = Convert.ToInt32(tbSecondTimeInHomeTotalUnder25.Text);
            Settings.Default.settingSecondTimeInAwayTotalUnder25 = Convert.ToInt32(tbSecondTimeInAwayTotalUnder25.Text);
            Settings.Default.settingSecondTimeInAllFailedToScore = Convert.ToInt32(tbSecondTimeInAllFailedToScore.Text);
            Settings.Default.settingSecondTimeInHomeFailedToScore = Convert.ToInt32(tbSecondTimeInHomeFailedToScore.Text);
            Settings.Default.settingSecondTimeInAwayFailedToScore = Convert.ToInt32(tbSecondTimeInAwayFailedToScore.Text);
            Settings.Default.settingAllMatchInAllTotalUnder15 = Convert.ToInt32(tbAllMatchInAllTotalUnder15.Text);
            Settings.Default.settingAllMatchInHomeTotalUnder15 = Convert.ToInt32(tbAllMatchInHomeTotalUnder15.Text);
            Settings.Default.settingAllMatchInAwayTotalUnder15 = Convert.ToInt32(tbAllMatchInAwayTotalUnder15.Text);
            Settings.Default.settingAllMatchInAllCleanSheets = Convert.ToInt32(tbAllMatchInAllCleanSheets.Text);
            Settings.Default.settingAllMatchInHomeCleanSheets = Convert.ToInt32(tbAllMatchInHomeCleanSheets.Text);
            Settings.Default.settingAllMatchInAwayCleanSheets = Convert.ToInt32(tbAllMatchInAwayCleanSheets.Text);
            Settings.Default.settingFirstTimeInAllTotalUnder15 = Convert.ToInt32(tbFirstTimeInAllTotalUnder15.Text);
            Settings.Default.settingFirstTimeInHomeTotalUnder15 = Convert.ToInt32(tbFirstTimeInHomeTotalUnder15.Text);
            Settings.Default.settingFirstTimeInAwayTotalUnder15 = Convert.ToInt32(tbFirstTimeInAwayTotalUnder15.Text);
            Settings.Default.settingFirstTimeInAllCleanSheets = Convert.ToInt32(tbFirstTimeInAllCleanSheets.Text);
            Settings.Default.settingFirstTimeInHomeCleanSheets = Convert.ToInt32(tbFirstTimeInHomeCleanSheets.Text);
            Settings.Default.settingFirstTimeInAwayCleanSheets = Convert.ToInt32(tbFirstTimeInAwayCleanSheets.Text);
            Settings.Default.settingSecondTimeInAllTotalUnder15 = Convert.ToInt32(tbSecondTimeInAllTotalUnder15.Text);
            Settings.Default.settingSecondTimeInHomeTotalUnder15 = Convert.ToInt32(tbSecondTimeInHomeTotalUnder15.Text);
            Settings.Default.settingSecondTimeInAwayTotalUnder15 = Convert.ToInt32(tbSecondTimeInAwayTotalUnder15.Text);
            Settings.Default.settingSecondTimeInAllCleanSheets = Convert.ToInt32(tbSecondTimeInAllCleanSheets.Text);
            Settings.Default.settingSecondTimeInHomeCleanSheets = Convert.ToInt32(tbSecondTimeInHomeCleanSheets.Text);
            Settings.Default.settingSecondTimeInAwayCleanSheets = Convert.ToInt32(tbSecondTimeInAwayCleanSheets.Text);
            Settings.Default.settingAllMatchInAllBothFailedToScore = Convert.ToInt32(tbAllMatchInAllBothFailedToScore.Text);
            Settings.Default.settingAllMatchInHomeBothFailedToScore = Convert.ToInt32(tbAllMatchInHomeBothFailedToScore.Text);
            Settings.Default.settingAllMatchInAwayBothFailedToScore = Convert.ToInt32(tbAllMatchInAwayBothFailedToScore.Text);
            Settings.Default.settingFirstTimeInAllBothFailedToScore = Convert.ToInt32(tbFirstTimeInAllBothFailedToScore.Text);
            Settings.Default.settingFirstTimeInHomeBothFailedToScore = Convert.ToInt32(tbFirstTimeInHomeBothFailedToScore.Text);
            Settings.Default.settingFirstTimeInAwayBothFailedToScore = Convert.ToInt32(tbFirstTimeInAwayBothFailedToScore.Text);
            Settings.Default.settingSecondTimeInAllBothFailedToScore = Convert.ToInt32(tbSecondTimeInAllBothFailedToScore.Text);
            Settings.Default.settingSecondTimeInHomeBothFailedToScore = Convert.ToInt32(tbSecondTimeInHomeBothFailedToScore.Text);
            Settings.Default.settingSecondTimeInAwayBothFailedToScore = Convert.ToInt32(tbSecondTimeInAwayBothFailedToScore.Text);

            Settings.Default.cbAllMatchInAllTotalUnder05 = (bool)cbAllMatchInAllTotalUnder05.IsChecked;
            Settings.Default.cbAllMatchInHomeTotalUnder05 = (bool)cbAllMatchInHomeTotalUnder05.IsChecked;
            Settings.Default.cbAllMatchInAwayTotalUnder05 = (bool)cbAllMatchInAwayTotalUnder05.IsChecked;
            Settings.Default.cbAllMatchInAllTotalUnder25 = (bool)cbAllMatchInAllTotalUnder25.IsChecked;
            Settings.Default.cbAllMatchInHomeTotalUnder25 = (bool)cbAllMatchInHomeTotalUnder25.IsChecked;
            Settings.Default.cbAllMatchInAwayTotalUnder25 = (bool)cbAllMatchInAwayTotalUnder25.IsChecked;
            Settings.Default.cbAllMatchInAllFailedToScore = (bool)cbAllMatchInAllFailedToScore.IsChecked;
            Settings.Default.cbAllMatchInHomeFailedToScore = (bool)cbAllMatchInHomeFailedToScore.IsChecked;
            Settings.Default.cbAllMatchInAwayFailedToScore = (bool)cbAllMatchInAwayFailedToScore.IsChecked;
            Settings.Default.cbFirstTimeInAllTotalUnder05 = (bool)cbFirstTimeInAllTotalUnder05.IsChecked;
            Settings.Default.cbFirstTimeInHomeTotalUnder05 = (bool)cbFirstTimeInHomeTotalUnder05.IsChecked;
            Settings.Default.cbFirstTimeInAwayTotalUnder05 = (bool)cbFirstTimeInAwayTotalUnder05.IsChecked;
            Settings.Default.cbFirstTimeInAllTotalUnder25 = (bool)cbFirstTimeInAllTotalUnder25.IsChecked;
            Settings.Default.cbFirstTimeInHomeTotalUnder25 = (bool)cbFirstTimeInHomeTotalUnder25.IsChecked;
            Settings.Default.cbFirstTimeInAwayTotalUnder25 = (bool)cbFirstTimeInAwayTotalUnder25.IsChecked;
            Settings.Default.cbFirstTimeInAllFailedToScore = (bool)cbFirstTimeInAllFailedToScore.IsChecked;
            Settings.Default.cbFirstTimeInHomeFailedToScore = (bool)cbFirstTimeInHomeFailedToScore.IsChecked;
            Settings.Default.cbFirstTimeInAwayFailedToScore = (bool)cbFirstTimeInAwayFailedToScore.IsChecked;
            Settings.Default.cbSecondTimeInAllTotalUnder05 = (bool)cbSecondTimeInAllTotalUnder05.IsChecked;
            Settings.Default.cbSecondTimeInHomeTotalUnder05 = (bool)cbSecondTimeInHomeTotalUnder05.IsChecked;
            Settings.Default.cbSecondTimeInAwayTotalUnder05 = (bool)cbSecondTimeInAwayTotalUnder05.IsChecked;
            Settings.Default.cbSecondTimeInAllTotalUnder25 = (bool)cbSecondTimeInAllTotalUnder25.IsChecked;
            Settings.Default.cbSecondTimeInHomeTotalUnder25 = (bool)cbSecondTimeInHomeTotalUnder25.IsChecked;
            Settings.Default.cbSecondTimeInAwayTotalUnder25 = (bool)cbSecondTimeInAwayTotalUnder25.IsChecked;
            Settings.Default.cbSecondTimeInAllFailedToScore = (bool)cbSecondTimeInAllFailedToScore.IsChecked;
            Settings.Default.cbSecondTimeInHomeFailedToScore = (bool)cbSecondTimeInHomeFailedToScore.IsChecked;
            Settings.Default.cbSecondTimeInAwayFailedToScore = (bool)cbSecondTimeInAwayFailedToScore.IsChecked;
            Settings.Default.cbAllMatchInAllTotalUnder15 = (bool)cbAllMatchInAllTotalUnder15.IsChecked;
            Settings.Default.cbAllMatchInHomeTotalUnder15 = (bool)cbAllMatchInHomeTotalUnder15.IsChecked;
            Settings.Default.cbAllMatchInAwayTotalUnder15 = (bool)cbAllMatchInAwayTotalUnder15.IsChecked;
            Settings.Default.cbAllMatchInAllCleanSheets = (bool)cbAllMatchInAllCleanSheets.IsChecked;
            Settings.Default.cbAllMatchInHomeCleanSheets = (bool)cbAllMatchInHomeCleanSheets.IsChecked;
            Settings.Default.cbAllMatchInAwayCleanSheets = (bool)cbAllMatchInAwayCleanSheets.IsChecked;
            Settings.Default.cbFirstTimeInAllTotalUnder15 = (bool)cbFirstTimeInAllTotalUnder15.IsChecked;
            Settings.Default.cbFirstTimeInHomeTotalUnder15 = (bool)cbFirstTimeInHomeTotalUnder15.IsChecked;
            Settings.Default.cbFirstTimeInAwayTotalUnder15 = (bool)cbFirstTimeInAwayTotalUnder15.IsChecked;
            Settings.Default.cbFirstTimeInAllCleanSheets = (bool)cbFirstTimeInAllCleanSheets.IsChecked;
            Settings.Default.cbFirstTimeInHomeCleanSheets = (bool)cbFirstTimeInHomeCleanSheets.IsChecked;
            Settings.Default.cbFirstTimeInAwayCleanSheets = (bool)cbFirstTimeInAwayCleanSheets.IsChecked;
            Settings.Default.cbSecondTimeInAllTotalUnder15 = (bool)cbSecondTimeInAllTotalUnder15.IsChecked;
            Settings.Default.cbSecondTimeInHomeTotalUnder15 = (bool)cbSecondTimeInHomeTotalUnder15.IsChecked;
            Settings.Default.cbSecondTimeInAwayTotalUnder15 = (bool)cbSecondTimeInAwayTotalUnder15.IsChecked;
            Settings.Default.cbSecondTimeInAllCleanSheets = (bool)cbSecondTimeInAllCleanSheets.IsChecked;
            Settings.Default.cbSecondTimeInHomeCleanSheets = (bool)cbSecondTimeInHomeCleanSheets.IsChecked;
            Settings.Default.cbSecondTimeInAwayCleanSheets = (bool)cbSecondTimeInAwayCleanSheets.IsChecked;
            Settings.Default.cbAllMatchInAllBothFailedToScore = (bool)cbAllMatchInAllBothFailedToScore.IsChecked;
            Settings.Default.cbAllMatchInHomeBothFailedToScore = (bool)cbAllMatchInHomeBothFailedToScore.IsChecked;
            Settings.Default.cbAllMatchInAwayBothFailedToScore = (bool)cbAllMatchInAwayBothFailedToScore.IsChecked;
            Settings.Default.cbFirstTimeInAllBothFailedToScore = (bool)cbFirstTimeInAllBothFailedToScore.IsChecked;
            Settings.Default.cbFirstTimeInHomeBothFailedToScore = (bool)cbFirstTimeInHomeBothFailedToScore.IsChecked;
            Settings.Default.cbFirstTimeInAwayBothFailedToScore = (bool)cbFirstTimeInAwayBothFailedToScore.IsChecked;
            Settings.Default.cbSecondTimeInAllBothFailedToScore = (bool)cbSecondTimeInAllBothFailedToScore.IsChecked;
            Settings.Default.cbSecondTimeInHomeBothFailedToScore = (bool)cbSecondTimeInHomeBothFailedToScore.IsChecked;
            Settings.Default.cbSecondTimeInAwayBothFailedToScore = (bool)cbSecondTimeInAwayBothFailedToScore.IsChecked;

            Settings.Default.Save();
        }

        private void SaveSettings_Click(object sender, RoutedEventArgs e)
        {
            XmlSettings xml = new XmlSettings();

            xml.SettingAllMatchInAllTotalUnder05 = Convert.ToInt32(tbAllMatchInAllTotalUnder05.Text);
            xml.SettingAllMatchInHomeTotalUnder05 = Convert.ToInt32(tbAllMatchInHomeTotalUnder05.Text);
            xml.SettingAllMatchInAwayTotalUnder05 = Convert.ToInt32(tbAllMatchInAwayTotalUnder05.Text);
            xml.SettingAllMatchInAllTotalUnder25 = Convert.ToInt32(tbAllMatchInAllTotalUnder25.Text);
            xml.SettingAllMatchInHomeTotalUnder25 = Convert.ToInt32(tbAllMatchInHomeTotalUnder25.Text);
            xml.SettingAllMatchInAwayTotalUnder25 = Convert.ToInt32(tbAllMatchInAwayTotalUnder25.Text);
            xml.SettingAllMatchInAllFailedToScore = Convert.ToInt32(tbAllMatchInAllFailedToScore.Text);
            xml.SettingAllMatchInHomeFailedToScore = Convert.ToInt32(tbAllMatchInHomeFailedToScore.Text);
            xml.SettingAllMatchInAwayFailedToScore = Convert.ToInt32(tbAllMatchInAwayFailedToScore.Text);
            xml.SettingFirstTimeInAllTotalUnder05 = Convert.ToInt32(tbFirstTimeInAllTotalUnder05.Text);
            xml.SettingFirstTimeInHomeTotalUnder05 = Convert.ToInt32(tbFirstTimeInHomeTotalUnder05.Text);
            xml.SettingFirstTimeInAwayTotalUnder05 = Convert.ToInt32(tbFirstTimeInAwayTotalUnder05.Text);
            xml.SettingFirstTimeInAllTotalUnder25 = Convert.ToInt32(tbFirstTimeInAllTotalUnder25.Text);
            xml.SettingFirstTimeInHomeTotalUnder25 = Convert.ToInt32(tbFirstTimeInHomeTotalUnder25.Text);
            xml.SettingFirstTimeInAwayTotalUnder25 = Convert.ToInt32(tbFirstTimeInAwayTotalUnder25.Text);
            xml.SettingFirstTimeInAllFailedToScore = Convert.ToInt32(tbFirstTimeInAllFailedToScore.Text);
            xml.SettingFirstTimeInHomeFailedToScore = Convert.ToInt32(tbFirstTimeInHomeFailedToScore.Text);
            xml.SettingFirstTimeInAwayFailedToScore = Convert.ToInt32(tbFirstTimeInAwayFailedToScore.Text);
            xml.SettingSecondTimeInAllTotalUnder05 = Convert.ToInt32(tbSecondTimeInAllTotalUnder05.Text);
            xml.SettingSecondTimeInHomeTotalUnder05 = Convert.ToInt32(tbSecondTimeInHomeTotalUnder05.Text);
            xml.SettingSecondTimeInAwayTotalUnder05 = Convert.ToInt32(tbSecondTimeInAwayTotalUnder05.Text);
            xml.SettingSecondTimeInAllTotalUnder25 = Convert.ToInt32(tbSecondTimeInAllTotalUnder25.Text);
            xml.SettingSecondTimeInHomeTotalUnder25 = Convert.ToInt32(tbSecondTimeInHomeTotalUnder25.Text);
            xml.SettingSecondTimeInAwayTotalUnder25 = Convert.ToInt32(tbSecondTimeInAwayTotalUnder25.Text);
            xml.SettingSecondTimeInAllFailedToScore = Convert.ToInt32(tbSecondTimeInAllFailedToScore.Text);
            xml.SettingSecondTimeInHomeFailedToScore = Convert.ToInt32(tbSecondTimeInHomeFailedToScore.Text);
            xml.SettingSecondTimeInAwayFailedToScore = Convert.ToInt32(tbSecondTimeInAwayFailedToScore.Text);
            xml.SettingAllMatchInAllTotalUnder15 = Convert.ToInt32(tbAllMatchInAllTotalUnder15.Text);
            xml.SettingAllMatchInHomeTotalUnder15 = Convert.ToInt32(tbAllMatchInHomeTotalUnder15.Text);
            xml.SettingAllMatchInAwayTotalUnder15 = Convert.ToInt32(tbAllMatchInAwayTotalUnder15.Text);
            xml.SettingAllMatchInAllCleanSheets = Convert.ToInt32(tbAllMatchInAllCleanSheets.Text);
            xml.SettingAllMatchInHomeCleanSheets = Convert.ToInt32(tbAllMatchInHomeCleanSheets.Text);
            xml.SettingAllMatchInAwayCleanSheets = Convert.ToInt32(tbAllMatchInAwayCleanSheets.Text);
            xml.SettingFirstTimeInAllTotalUnder15 = Convert.ToInt32(tbFirstTimeInAllTotalUnder15.Text);
            xml.SettingFirstTimeInHomeTotalUnder15 = Convert.ToInt32(tbFirstTimeInHomeTotalUnder15.Text);
            xml.SettingFirstTimeInAwayTotalUnder15 = Convert.ToInt32(tbFirstTimeInAwayTotalUnder15.Text);
            xml.SettingFirstTimeInAllCleanSheets = Convert.ToInt32(tbFirstTimeInAllCleanSheets.Text);
            xml.SettingFirstTimeInHomeCleanSheets = Convert.ToInt32(tbFirstTimeInHomeCleanSheets.Text);
            xml.SettingFirstTimeInAwayCleanSheets = Convert.ToInt32(tbFirstTimeInAwayCleanSheets.Text);
            xml.SettingSecondTimeInAllTotalUnder15 = Convert.ToInt32(tbSecondTimeInAllTotalUnder15.Text);
            xml.SettingSecondTimeInHomeTotalUnder15 = Convert.ToInt32(tbSecondTimeInHomeTotalUnder15.Text);
            xml.SettingSecondTimeInAwayTotalUnder15 = Convert.ToInt32(tbSecondTimeInAwayTotalUnder15.Text);
            xml.SettingSecondTimeInAllCleanSheets = Convert.ToInt32(tbSecondTimeInAllCleanSheets.Text);
            xml.SettingSecondTimeInHomeCleanSheets = Convert.ToInt32(tbSecondTimeInHomeCleanSheets.Text);
            xml.SettingSecondTimeInAwayCleanSheets = Convert.ToInt32(tbSecondTimeInAwayCleanSheets.Text);
            xml.SettingAllMatchInAllBothFailedToScore = Convert.ToInt32(tbAllMatchInAllBothFailedToScore.Text);
            xml.SettingAllMatchInHomeBothFailedToScore = Convert.ToInt32(tbAllMatchInHomeBothFailedToScore.Text);
            xml.SettingAllMatchInAwayBothFailedToScore = Convert.ToInt32(tbAllMatchInAwayBothFailedToScore.Text);
            xml.SettingFirstTimeInAllBothFailedToScore = Convert.ToInt32(tbFirstTimeInAllBothFailedToScore.Text);
            xml.SettingFirstTimeInHomeBothFailedToScore = Convert.ToInt32(tbFirstTimeInHomeBothFailedToScore.Text);
            xml.SettingFirstTimeInAwayBothFailedToScore = Convert.ToInt32(tbFirstTimeInAwayBothFailedToScore.Text);
            xml.SettingSecondTimeInAllBothFailedToScore = Convert.ToInt32(tbSecondTimeInAllBothFailedToScore.Text);
            xml.SettingSecondTimeInHomeBothFailedToScore = Convert.ToInt32(tbSecondTimeInHomeBothFailedToScore.Text);
            xml.SettingSecondTimeInAwayBothFailedToScore = Convert.ToInt32(tbSecondTimeInAwayBothFailedToScore.Text);

            xml.CbAllMatchInAllTotalUnder05 = (bool)cbAllMatchInAllTotalUnder05.IsChecked;
            xml.CbAllMatchInHomeTotalUnder05 = (bool)cbAllMatchInHomeTotalUnder05.IsChecked;
            xml.CbAllMatchInAwayTotalUnder05 = (bool)cbAllMatchInAwayTotalUnder05.IsChecked;
            xml.CbAllMatchInAllTotalUnder25 = (bool)cbAllMatchInAllTotalUnder25.IsChecked;
            xml.CbAllMatchInHomeTotalUnder25 = (bool)cbAllMatchInHomeTotalUnder25.IsChecked;
            xml.CbAllMatchInAwayTotalUnder25 = (bool)cbAllMatchInAwayTotalUnder25.IsChecked;
            xml.CbAllMatchInAllFailedToScore = (bool)cbAllMatchInAllFailedToScore.IsChecked;
            xml.CbAllMatchInHomeFailedToScore = (bool)cbAllMatchInHomeFailedToScore.IsChecked;
            xml.CbAllMatchInAwayFailedToScore = (bool)cbAllMatchInAwayFailedToScore.IsChecked;
            xml.CbFirstTimeInAllTotalUnder05 = (bool)cbFirstTimeInAllTotalUnder05.IsChecked;
            xml.CbFirstTimeInHomeTotalUnder05 = (bool)cbFirstTimeInHomeTotalUnder05.IsChecked;
            xml.CbFirstTimeInAwayTotalUnder05 = (bool)cbFirstTimeInAwayTotalUnder05.IsChecked;
            xml.CbFirstTimeInAllTotalUnder25 = (bool)cbFirstTimeInAllTotalUnder25.IsChecked;
            xml.CbFirstTimeInHomeTotalUnder25 = (bool)cbFirstTimeInHomeTotalUnder25.IsChecked;
            xml.CbFirstTimeInAwayTotalUnder25 = (bool)cbFirstTimeInAwayTotalUnder25.IsChecked;
            xml.CbFirstTimeInAllFailedToScore = (bool)cbFirstTimeInAllFailedToScore.IsChecked;
            xml.CbFirstTimeInHomeFailedToScore = (bool)cbFirstTimeInHomeFailedToScore.IsChecked;
            xml.CbFirstTimeInAwayFailedToScore = (bool)cbFirstTimeInAwayFailedToScore.IsChecked;
            xml.CbSecondTimeInAllTotalUnder05 = (bool)cbSecondTimeInAllTotalUnder05.IsChecked;
            xml.CbSecondTimeInHomeTotalUnder05 = (bool)cbSecondTimeInHomeTotalUnder05.IsChecked;
            xml.CbSecondTimeInAwayTotalUnder05 = (bool)cbSecondTimeInAwayTotalUnder05.IsChecked;
            xml.CbSecondTimeInAllTotalUnder25 = (bool)cbSecondTimeInAllTotalUnder25.IsChecked;
            xml.CbSecondTimeInHomeTotalUnder25 = (bool)cbSecondTimeInHomeTotalUnder25.IsChecked;
            xml.CbSecondTimeInAwayTotalUnder25 = (bool)cbSecondTimeInAwayTotalUnder25.IsChecked;
            xml.CbSecondTimeInAllFailedToScore = (bool)cbSecondTimeInAllFailedToScore.IsChecked;
            xml.CbSecondTimeInHomeFailedToScore = (bool)cbSecondTimeInHomeFailedToScore.IsChecked;
            xml.CbSecondTimeInAwayFailedToScore = (bool)cbSecondTimeInAwayFailedToScore.IsChecked;
            xml.CbAllMatchInAllTotalUnder15 = (bool)cbAllMatchInAllTotalUnder15.IsChecked;
            xml.CbAllMatchInHomeTotalUnder15 = (bool)cbAllMatchInHomeTotalUnder15.IsChecked;
            xml.CbAllMatchInAwayTotalUnder15 = (bool)cbAllMatchInAwayTotalUnder15.IsChecked;
            xml.CbAllMatchInAllCleanSheets = (bool)cbAllMatchInAllCleanSheets.IsChecked;
            xml.CbAllMatchInHomeCleanSheets = (bool)cbAllMatchInHomeCleanSheets.IsChecked;
            xml.CbAllMatchInAwayCleanSheets = (bool)cbAllMatchInAwayCleanSheets.IsChecked;
            xml.CbFirstTimeInAllTotalUnder15 = (bool)cbFirstTimeInAllTotalUnder15.IsChecked;
            xml.CbFirstTimeInHomeTotalUnder15 = (bool)cbFirstTimeInHomeTotalUnder15.IsChecked;
            xml.CbFirstTimeInAwayTotalUnder15 = (bool)cbFirstTimeInAwayTotalUnder15.IsChecked;
            xml.CbFirstTimeInAllCleanSheets = (bool)cbFirstTimeInAllCleanSheets.IsChecked;
            xml.CbFirstTimeInHomeCleanSheets = (bool)cbFirstTimeInHomeCleanSheets.IsChecked;
            xml.CbFirstTimeInAwayCleanSheets = (bool)cbFirstTimeInAwayCleanSheets.IsChecked;
            xml.CbSecondTimeInAllTotalUnder15 = (bool)cbSecondTimeInAllTotalUnder15.IsChecked;
            xml.CbSecondTimeInHomeTotalUnder15 = (bool)cbSecondTimeInHomeTotalUnder15.IsChecked;
            xml.CbSecondTimeInAwayTotalUnder15 = (bool)cbSecondTimeInAwayTotalUnder15.IsChecked;
            xml.CbSecondTimeInAllCleanSheets = (bool)cbSecondTimeInAllCleanSheets.IsChecked;
            xml.CbSecondTimeInHomeCleanSheets = (bool)cbSecondTimeInHomeCleanSheets.IsChecked;
            xml.CbSecondTimeInAwayCleanSheets = (bool)cbSecondTimeInAwayCleanSheets.IsChecked;
            xml.CbAllMatchInAllBothFailedToScore = (bool)cbAllMatchInAllBothFailedToScore.IsChecked;
            xml.CbAllMatchInHomeBothFailedToScore = (bool)cbAllMatchInHomeBothFailedToScore.IsChecked;
            xml.CbAllMatchInAwayBothFailedToScore = (bool)cbAllMatchInAwayBothFailedToScore.IsChecked;
            xml.CbFirstTimeInAllBothFailedToScore = (bool)cbFirstTimeInAllBothFailedToScore.IsChecked;
            xml.CbFirstTimeInHomeBothFailedToScore = (bool)cbFirstTimeInHomeBothFailedToScore.IsChecked;
            xml.CbFirstTimeInAwayBothFailedToScore = (bool)cbFirstTimeInAwayBothFailedToScore.IsChecked;
            xml.CbSecondTimeInAllBothFailedToScore = (bool)cbSecondTimeInAllBothFailedToScore.IsChecked;
            xml.CbSecondTimeInHomeBothFailedToScore = (bool)cbSecondTimeInHomeBothFailedToScore.IsChecked;
            xml.CbSecondTimeInAwayBothFailedToScore = (bool)cbSecondTimeInAwayBothFailedToScore.IsChecked;

            if (!Directory.Exists("Settings"))
                Directory.CreateDirectory("Settings");

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Settings file (*.xml)|*.xml";
            saveFileDialog.Title = "Save a settings file";
            saveFileDialog.InitialDirectory = Environment.CurrentDirectory + @"\Settings";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                XmlSerializer serXml = new XmlSerializer(typeof(XmlSettings));
                TextWriter writer = new StreamWriter(saveFileDialog.FileName);
                serXml.Serialize(writer, xml);
                writer.Close();
            }
        }

        private void LoadSettings_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists("Settings"))
                Directory.CreateDirectory("Settings");

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Settings files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.Multiselect = false;
            openFileDialog.InitialDirectory = Environment.CurrentDirectory + @"\Settings";

            openFileDialog.ShowDialog();//maybe need it wrap to if showdialog == true 

            XmlSettings xml = new XmlSettings();

            if (File.Exists(openFileDialog.FileName))
            {
                XmlSerializer serXml = new XmlSerializer(typeof(XmlSettings));
                TextReader reader = new StreamReader(openFileDialog.FileName);
                xml = serXml.Deserialize(reader) as XmlSettings;
                reader.Close();

                tbAllMatchInAllTotalUnder05.Text = xml.SettingAllMatchInAllTotalUnder05.ToString();
                tbAllMatchInHomeTotalUnder05.Text = xml.SettingAllMatchInHomeTotalUnder05.ToString();
                tbAllMatchInAwayTotalUnder05.Text = xml.SettingAllMatchInAwayTotalUnder05.ToString();
                tbAllMatchInAllTotalUnder25.Text = xml.SettingAllMatchInAllTotalUnder25.ToString();
                tbAllMatchInHomeTotalUnder25.Text = xml.SettingAllMatchInHomeTotalUnder25.ToString();
                tbAllMatchInAwayTotalUnder25.Text = xml.SettingAllMatchInAwayTotalUnder25.ToString();
                tbAllMatchInAllFailedToScore.Text = xml.SettingAllMatchInAllFailedToScore.ToString();
                tbAllMatchInHomeFailedToScore.Text = xml.SettingAllMatchInHomeFailedToScore.ToString();
                tbAllMatchInAwayFailedToScore.Text = xml.SettingAllMatchInAwayFailedToScore.ToString();
                tbFirstTimeInAllTotalUnder05.Text = xml.SettingFirstTimeInAllTotalUnder05.ToString();
                tbFirstTimeInHomeTotalUnder05.Text = xml.SettingFirstTimeInHomeTotalUnder05.ToString();
                tbFirstTimeInAwayTotalUnder05.Text = xml.SettingFirstTimeInAwayTotalUnder05.ToString();
                tbFirstTimeInAllTotalUnder25.Text = xml.SettingFirstTimeInAllTotalUnder25.ToString();
                tbFirstTimeInHomeTotalUnder25.Text = xml.SettingFirstTimeInHomeTotalUnder25.ToString();
                tbFirstTimeInAwayTotalUnder25.Text = xml.SettingFirstTimeInAwayTotalUnder25.ToString();
                tbFirstTimeInAllFailedToScore.Text = xml.SettingFirstTimeInAllFailedToScore.ToString();
                tbFirstTimeInHomeFailedToScore.Text = xml.SettingFirstTimeInHomeFailedToScore.ToString();
                tbFirstTimeInAwayFailedToScore.Text = xml.SettingFirstTimeInAwayFailedToScore.ToString();
                tbSecondTimeInAllTotalUnder05.Text = xml.SettingSecondTimeInAllTotalUnder05.ToString();
                tbSecondTimeInHomeTotalUnder05.Text = xml.SettingSecondTimeInHomeTotalUnder05.ToString();
                tbSecondTimeInAwayTotalUnder05.Text = xml.SettingSecondTimeInAwayTotalUnder05.ToString();
                tbSecondTimeInAllTotalUnder25.Text = xml.SettingSecondTimeInAllTotalUnder25.ToString();
                tbSecondTimeInHomeTotalUnder25.Text = xml.SettingSecondTimeInHomeTotalUnder25.ToString();
                tbSecondTimeInAwayTotalUnder25.Text = xml.SettingSecondTimeInAwayTotalUnder25.ToString();
                tbSecondTimeInAllFailedToScore.Text = xml.SettingSecondTimeInAllFailedToScore.ToString();
                tbSecondTimeInHomeFailedToScore.Text = xml.SettingSecondTimeInHomeFailedToScore.ToString();
                tbSecondTimeInAwayFailedToScore.Text = xml.SettingSecondTimeInAwayFailedToScore.ToString();
                tbAllMatchInAllTotalUnder15.Text = xml.SettingAllMatchInAllTotalUnder15.ToString();
                tbAllMatchInHomeTotalUnder15.Text = xml.SettingAllMatchInHomeTotalUnder15.ToString();
                tbAllMatchInAwayTotalUnder15.Text = xml.SettingAllMatchInAwayTotalUnder15.ToString();
                tbAllMatchInAllCleanSheets.Text = xml.SettingAllMatchInAllCleanSheets.ToString();
                tbAllMatchInHomeCleanSheets.Text = xml.SettingAllMatchInHomeCleanSheets.ToString();
                tbAllMatchInAwayCleanSheets.Text = xml.SettingAllMatchInAwayCleanSheets.ToString();
                tbFirstTimeInAllTotalUnder15.Text = xml.SettingFirstTimeInAllTotalUnder15.ToString();
                tbFirstTimeInHomeTotalUnder15.Text = xml.SettingFirstTimeInHomeTotalUnder15.ToString();
                tbFirstTimeInAwayTotalUnder15.Text = xml.SettingFirstTimeInAwayTotalUnder15.ToString();
                tbFirstTimeInAllCleanSheets.Text = xml.SettingFirstTimeInAllCleanSheets.ToString();
                tbFirstTimeInHomeCleanSheets.Text = xml.SettingFirstTimeInHomeCleanSheets.ToString();
                tbFirstTimeInAwayCleanSheets.Text = xml.SettingFirstTimeInAwayCleanSheets.ToString();
                tbSecondTimeInAllTotalUnder15.Text = xml.SettingSecondTimeInAllTotalUnder15.ToString();
                tbSecondTimeInHomeTotalUnder15.Text = xml.SettingSecondTimeInHomeTotalUnder15.ToString();
                tbSecondTimeInAwayTotalUnder15.Text = xml.SettingSecondTimeInAwayTotalUnder15.ToString();
                tbSecondTimeInAllCleanSheets.Text = xml.SettingSecondTimeInAllCleanSheets.ToString();
                tbSecondTimeInHomeCleanSheets.Text = xml.SettingSecondTimeInHomeCleanSheets.ToString();
                tbSecondTimeInAwayCleanSheets.Text = xml.SettingSecondTimeInAwayCleanSheets.ToString();
                tbAllMatchInAllBothFailedToScore.Text = xml.SettingAllMatchInAllBothFailedToScore.ToString();
                tbAllMatchInHomeBothFailedToScore.Text = xml.SettingAllMatchInHomeBothFailedToScore.ToString();
                tbAllMatchInAwayBothFailedToScore.Text = xml.SettingAllMatchInAwayBothFailedToScore.ToString();
                tbFirstTimeInAllBothFailedToScore.Text = xml.SettingFirstTimeInAllBothFailedToScore.ToString();
                tbFirstTimeInHomeBothFailedToScore.Text = xml.SettingFirstTimeInHomeBothFailedToScore.ToString();
                tbFirstTimeInAwayBothFailedToScore.Text = xml.SettingFirstTimeInAwayBothFailedToScore.ToString();
                tbSecondTimeInAllBothFailedToScore.Text = xml.SettingSecondTimeInAllBothFailedToScore.ToString();
                tbSecondTimeInHomeBothFailedToScore.Text = xml.SettingSecondTimeInHomeBothFailedToScore.ToString();
                tbSecondTimeInAwayBothFailedToScore.Text = xml.SettingSecondTimeInAwayBothFailedToScore.ToString();

                cbAllMatchInAllTotalUnder05.IsChecked = xml.CbAllMatchInAllTotalUnder05;
                cbAllMatchInHomeTotalUnder05.IsChecked = xml.CbAllMatchInHomeTotalUnder05;
                cbAllMatchInAwayTotalUnder05.IsChecked = xml.CbAllMatchInAwayTotalUnder05;
                cbAllMatchInAllTotalUnder25.IsChecked = xml.CbAllMatchInAllTotalUnder25;
                cbAllMatchInHomeTotalUnder25.IsChecked = xml.CbAllMatchInHomeTotalUnder25;
                cbAllMatchInAwayTotalUnder25.IsChecked = xml.CbAllMatchInAwayTotalUnder25;
                cbAllMatchInAllFailedToScore.IsChecked = xml.CbAllMatchInAllFailedToScore;
                cbAllMatchInHomeFailedToScore.IsChecked = xml.CbAllMatchInHomeFailedToScore;
                cbAllMatchInAwayFailedToScore.IsChecked = xml.CbAllMatchInAwayFailedToScore;
                cbFirstTimeInAllTotalUnder05.IsChecked = xml.CbFirstTimeInAllTotalUnder05;
                cbFirstTimeInHomeTotalUnder05.IsChecked = xml.CbFirstTimeInHomeTotalUnder05;
                cbFirstTimeInAwayTotalUnder05.IsChecked = xml.CbFirstTimeInAwayTotalUnder05;
                cbFirstTimeInAllTotalUnder25.IsChecked = xml.CbFirstTimeInAllTotalUnder25;
                cbFirstTimeInHomeTotalUnder25.IsChecked = xml.CbFirstTimeInHomeTotalUnder25;
                cbFirstTimeInAwayTotalUnder25.IsChecked = xml.CbFirstTimeInAwayTotalUnder25;
                cbFirstTimeInAllFailedToScore.IsChecked = xml.CbFirstTimeInAllFailedToScore;
                cbFirstTimeInHomeFailedToScore.IsChecked = xml.CbFirstTimeInHomeFailedToScore;
                cbFirstTimeInAwayFailedToScore.IsChecked = xml.CbFirstTimeInAwayFailedToScore;
                cbSecondTimeInAllTotalUnder05.IsChecked = xml.CbSecondTimeInAllTotalUnder05;
                cbSecondTimeInHomeTotalUnder05.IsChecked = xml.CbSecondTimeInHomeTotalUnder05;
                cbSecondTimeInAwayTotalUnder05.IsChecked = xml.CbSecondTimeInAwayTotalUnder05;
                cbSecondTimeInAllTotalUnder25.IsChecked = xml.CbSecondTimeInAllTotalUnder25;
                cbSecondTimeInHomeTotalUnder25.IsChecked = xml.CbSecondTimeInHomeTotalUnder25;
                cbSecondTimeInAwayTotalUnder25.IsChecked = xml.CbSecondTimeInAwayTotalUnder25;
                cbSecondTimeInAllFailedToScore.IsChecked = xml.CbSecondTimeInAllFailedToScore;
                cbSecondTimeInHomeFailedToScore.IsChecked = xml.CbSecondTimeInHomeFailedToScore;
                cbSecondTimeInAwayFailedToScore.IsChecked = xml.CbSecondTimeInAwayFailedToScore;
                cbAllMatchInAllTotalUnder15.IsChecked = xml.CbAllMatchInAllTotalUnder15;
                cbAllMatchInHomeTotalUnder15.IsChecked = xml.CbAllMatchInHomeTotalUnder15;
                cbAllMatchInAwayTotalUnder15.IsChecked = xml.CbAllMatchInAwayTotalUnder15;
                cbAllMatchInAllCleanSheets.IsChecked = xml.CbAllMatchInAllCleanSheets;
                cbAllMatchInHomeCleanSheets.IsChecked = xml.CbAllMatchInHomeCleanSheets;
                cbAllMatchInAwayCleanSheets.IsChecked = xml.CbAllMatchInAwayCleanSheets;
                cbFirstTimeInAllTotalUnder15.IsChecked = xml.CbFirstTimeInAllTotalUnder15;
                cbFirstTimeInHomeTotalUnder15.IsChecked = xml.CbFirstTimeInHomeTotalUnder15;
                cbFirstTimeInAwayTotalUnder15.IsChecked = xml.CbFirstTimeInAwayTotalUnder15;
                cbFirstTimeInAllCleanSheets.IsChecked = xml.CbFirstTimeInAllCleanSheets;
                cbFirstTimeInHomeCleanSheets.IsChecked = xml.CbFirstTimeInHomeCleanSheets;
                cbFirstTimeInAwayCleanSheets.IsChecked = xml.CbFirstTimeInAwayCleanSheets;
                cbSecondTimeInAllTotalUnder15.IsChecked = xml.CbSecondTimeInAllTotalUnder15;
                cbSecondTimeInHomeTotalUnder15.IsChecked = xml.CbSecondTimeInHomeTotalUnder15;
                cbSecondTimeInAwayTotalUnder15.IsChecked = xml.CbSecondTimeInAwayTotalUnder15;
                cbSecondTimeInAllCleanSheets.IsChecked = xml.CbSecondTimeInAllCleanSheets;
                cbSecondTimeInHomeCleanSheets.IsChecked = xml.CbSecondTimeInHomeCleanSheets;
                cbSecondTimeInAwayCleanSheets.IsChecked = xml.CbSecondTimeInAwayCleanSheets;
                cbAllMatchInAllBothFailedToScore.IsChecked = xml.CbAllMatchInAllBothFailedToScore;
                cbAllMatchInHomeBothFailedToScore.IsChecked = xml.CbAllMatchInHomeBothFailedToScore;
                cbAllMatchInAwayBothFailedToScore.IsChecked = xml.CbAllMatchInAwayBothFailedToScore;
                cbFirstTimeInAllBothFailedToScore.IsChecked = xml.CbFirstTimeInAllBothFailedToScore;
                cbFirstTimeInHomeBothFailedToScore.IsChecked = xml.CbFirstTimeInHomeBothFailedToScore;
                cbFirstTimeInAwayBothFailedToScore.IsChecked = xml.CbFirstTimeInAwayBothFailedToScore;
                cbSecondTimeInAllBothFailedToScore.IsChecked = xml.CbSecondTimeInAllBothFailedToScore;
                cbSecondTimeInHomeBothFailedToScore.IsChecked = xml.CbSecondTimeInHomeBothFailedToScore;
                cbSecondTimeInAwayBothFailedToScore.IsChecked = xml.CbSecondTimeInAwayBothFailedToScore;
            }
            else
                MessageBox.Show("Файл не найден");
        }

        //regex code for revers expression about "="
        //(\s*)([^\s]+)\s*=\s*([^\s*]+)\s*;
        //$1$3=$2;
        //i can test new regex expressions on their website

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbAllMatchInAllTotalUnder05.Text = Settings.Default.settingAllMatchInAllTotalUnder05.ToString();
            tbAllMatchInHomeTotalUnder05.Text = Settings.Default.settingAllMatchInHomeTotalUnder05.ToString();
            tbAllMatchInAwayTotalUnder05.Text = Settings.Default.settingAllMatchInAwayTotalUnder05.ToString();
            tbAllMatchInAllTotalUnder25.Text = Settings.Default.settingAllMatchInAllTotalUnder25.ToString();
            tbAllMatchInHomeTotalUnder25.Text = Settings.Default.settingAllMatchInHomeTotalUnder25.ToString();
            tbAllMatchInAwayTotalUnder25.Text = Settings.Default.settingAllMatchInAwayTotalUnder25.ToString();
            tbAllMatchInAllFailedToScore.Text = Settings.Default.settingAllMatchInAllFailedToScore.ToString();
            tbAllMatchInHomeFailedToScore.Text = Settings.Default.settingAllMatchInHomeFailedToScore.ToString();
            tbAllMatchInAwayFailedToScore.Text = Settings.Default.settingAllMatchInAwayFailedToScore.ToString();
            tbFirstTimeInAllTotalUnder05.Text = Settings.Default.settingFirstTimeInAllTotalUnder05.ToString();
            tbFirstTimeInHomeTotalUnder05.Text = Settings.Default.settingFirstTimeInHomeTotalUnder05.ToString();
            tbFirstTimeInAwayTotalUnder05.Text = Settings.Default.settingFirstTimeInAwayTotalUnder05.ToString();
            tbFirstTimeInAllTotalUnder25.Text = Settings.Default.settingFirstTimeInAllTotalUnder25.ToString();
            tbFirstTimeInHomeTotalUnder25.Text = Settings.Default.settingFirstTimeInHomeTotalUnder25.ToString();
            tbFirstTimeInAwayTotalUnder25.Text = Settings.Default.settingFirstTimeInAwayTotalUnder25.ToString();
            tbFirstTimeInAllFailedToScore.Text = Settings.Default.settingFirstTimeInAllFailedToScore.ToString();
            tbFirstTimeInHomeFailedToScore.Text = Settings.Default.settingFirstTimeInHomeFailedToScore.ToString();
            tbFirstTimeInAwayFailedToScore.Text = Settings.Default.settingFirstTimeInAwayFailedToScore.ToString();
            tbSecondTimeInAllTotalUnder05.Text = Settings.Default.settingSecondTimeInAllTotalUnder05.ToString();
            tbSecondTimeInHomeTotalUnder05.Text = Settings.Default.settingSecondTimeInHomeTotalUnder05.ToString();
            tbSecondTimeInAwayTotalUnder05.Text = Settings.Default.settingSecondTimeInAwayTotalUnder05.ToString();
            tbSecondTimeInAllTotalUnder25.Text = Settings.Default.settingSecondTimeInAllTotalUnder25.ToString();
            tbSecondTimeInHomeTotalUnder25.Text = Settings.Default.settingSecondTimeInHomeTotalUnder25.ToString();
            tbSecondTimeInAwayTotalUnder25.Text = Settings.Default.settingSecondTimeInAwayTotalUnder25.ToString();
            tbSecondTimeInAllFailedToScore.Text = Settings.Default.settingSecondTimeInAllFailedToScore.ToString();
            tbSecondTimeInHomeFailedToScore.Text = Settings.Default.settingSecondTimeInHomeFailedToScore.ToString();
            tbSecondTimeInAwayFailedToScore.Text = Settings.Default.settingSecondTimeInAwayFailedToScore.ToString();
            tbAllMatchInAllTotalUnder15.Text = Settings.Default.settingAllMatchInAllTotalUnder15.ToString();
            tbAllMatchInHomeTotalUnder15.Text = Settings.Default.settingAllMatchInHomeTotalUnder15.ToString();
            tbAllMatchInAwayTotalUnder15.Text = Settings.Default.settingAllMatchInAwayTotalUnder15.ToString();
            tbAllMatchInAllCleanSheets.Text = Settings.Default.settingAllMatchInAllCleanSheets.ToString();
            tbAllMatchInHomeCleanSheets.Text = Settings.Default.settingAllMatchInHomeCleanSheets.ToString();
            tbAllMatchInAwayCleanSheets.Text = Settings.Default.settingAllMatchInAwayCleanSheets.ToString();
            tbFirstTimeInAllTotalUnder15.Text = Settings.Default.settingFirstTimeInAllTotalUnder15.ToString();
            tbFirstTimeInHomeTotalUnder15.Text = Settings.Default.settingFirstTimeInHomeTotalUnder15.ToString();
            tbFirstTimeInAwayTotalUnder15.Text = Settings.Default.settingFirstTimeInAwayTotalUnder15.ToString();
            tbFirstTimeInAllCleanSheets.Text = Settings.Default.settingFirstTimeInAllCleanSheets.ToString();
            tbFirstTimeInHomeCleanSheets.Text = Settings.Default.settingFirstTimeInHomeCleanSheets.ToString();
            tbFirstTimeInAwayCleanSheets.Text = Settings.Default.settingFirstTimeInAwayCleanSheets.ToString();
            tbSecondTimeInAllTotalUnder15.Text = Settings.Default.settingSecondTimeInAllTotalUnder15.ToString();
            tbSecondTimeInHomeTotalUnder15.Text = Settings.Default.settingSecondTimeInHomeTotalUnder15.ToString();
            tbSecondTimeInAwayTotalUnder15.Text = Settings.Default.settingSecondTimeInAwayTotalUnder15.ToString();
            tbSecondTimeInAllCleanSheets.Text = Settings.Default.settingSecondTimeInAllCleanSheets.ToString();
            tbSecondTimeInHomeCleanSheets.Text = Settings.Default.settingSecondTimeInHomeCleanSheets.ToString();
            tbSecondTimeInAwayCleanSheets.Text = Settings.Default.settingSecondTimeInAwayCleanSheets.ToString();
            tbAllMatchInAllBothFailedToScore.Text = Settings.Default.settingAllMatchInAllBothFailedToScore.ToString();
            tbAllMatchInHomeBothFailedToScore.Text = Settings.Default.settingAllMatchInHomeBothFailedToScore.ToString();
            tbAllMatchInAwayBothFailedToScore.Text = Settings.Default.settingAllMatchInAwayBothFailedToScore.ToString();
            tbFirstTimeInAllBothFailedToScore.Text = Settings.Default.settingFirstTimeInAllBothFailedToScore.ToString();
            tbFirstTimeInHomeBothFailedToScore.Text = Settings.Default.settingFirstTimeInHomeBothFailedToScore.ToString();
            tbFirstTimeInAwayBothFailedToScore.Text = Settings.Default.settingFirstTimeInAwayBothFailedToScore.ToString();
            tbSecondTimeInAllBothFailedToScore.Text = Settings.Default.settingSecondTimeInAllBothFailedToScore.ToString();
            tbSecondTimeInHomeBothFailedToScore.Text = Settings.Default.settingSecondTimeInHomeBothFailedToScore.ToString();
            tbSecondTimeInAwayBothFailedToScore.Text = Settings.Default.settingSecondTimeInAwayBothFailedToScore.ToString();

            cbAllMatchInAllTotalUnder05.IsChecked = Settings.Default.cbAllMatchInAllTotalUnder05;
            cbAllMatchInHomeTotalUnder05.IsChecked = Settings.Default.cbAllMatchInHomeTotalUnder05;
            cbAllMatchInAwayTotalUnder05.IsChecked = Settings.Default.cbAllMatchInAwayTotalUnder05;
            cbAllMatchInAllTotalUnder25.IsChecked = Settings.Default.cbAllMatchInAllTotalUnder25;
            cbAllMatchInHomeTotalUnder25.IsChecked = Settings.Default.cbAllMatchInHomeTotalUnder25;
            cbAllMatchInAwayTotalUnder25.IsChecked = Settings.Default.cbAllMatchInAwayTotalUnder25;
            cbAllMatchInAllFailedToScore.IsChecked = Settings.Default.cbAllMatchInAllFailedToScore;
            cbAllMatchInHomeFailedToScore.IsChecked = Settings.Default.cbAllMatchInHomeFailedToScore;
            cbAllMatchInAwayFailedToScore.IsChecked = Settings.Default.cbAllMatchInAwayFailedToScore;
            cbFirstTimeInAllTotalUnder05.IsChecked = Settings.Default.cbFirstTimeInAllTotalUnder05;
            cbFirstTimeInHomeTotalUnder05.IsChecked = Settings.Default.cbFirstTimeInHomeTotalUnder05;
            cbFirstTimeInAwayTotalUnder05.IsChecked = Settings.Default.cbFirstTimeInAwayTotalUnder05;
            cbFirstTimeInAllTotalUnder25.IsChecked = Settings.Default.cbFirstTimeInAllTotalUnder25;
            cbFirstTimeInHomeTotalUnder25.IsChecked = Settings.Default.cbFirstTimeInHomeTotalUnder25;
            cbFirstTimeInAwayTotalUnder25.IsChecked = Settings.Default.cbFirstTimeInAwayTotalUnder25;
            cbFirstTimeInAllFailedToScore.IsChecked = Settings.Default.cbFirstTimeInAllFailedToScore;
            cbFirstTimeInHomeFailedToScore.IsChecked = Settings.Default.cbFirstTimeInHomeFailedToScore;
            cbFirstTimeInAwayFailedToScore.IsChecked = Settings.Default.cbFirstTimeInAwayFailedToScore;
            cbSecondTimeInAllTotalUnder05.IsChecked = Settings.Default.cbSecondTimeInAllTotalUnder05;
            cbSecondTimeInHomeTotalUnder05.IsChecked = Settings.Default.cbSecondTimeInHomeTotalUnder05;
            cbSecondTimeInAwayTotalUnder05.IsChecked = Settings.Default.cbSecondTimeInAwayTotalUnder05;
            cbSecondTimeInAllTotalUnder25.IsChecked = Settings.Default.cbSecondTimeInAllTotalUnder25;
            cbSecondTimeInHomeTotalUnder25.IsChecked = Settings.Default.cbSecondTimeInHomeTotalUnder25;
            cbSecondTimeInAwayTotalUnder25.IsChecked = Settings.Default.cbSecondTimeInAwayTotalUnder25;
            cbSecondTimeInAllFailedToScore.IsChecked = Settings.Default.cbSecondTimeInAllFailedToScore;
            cbSecondTimeInHomeFailedToScore.IsChecked = Settings.Default.cbSecondTimeInHomeFailedToScore;
            cbSecondTimeInAwayFailedToScore.IsChecked = Settings.Default.cbSecondTimeInAwayFailedToScore;
            cbAllMatchInAllTotalUnder15.IsChecked = Settings.Default.cbAllMatchInAllTotalUnder15;
            cbAllMatchInHomeTotalUnder15.IsChecked = Settings.Default.cbAllMatchInHomeTotalUnder15;
            cbAllMatchInAwayTotalUnder15.IsChecked = Settings.Default.cbAllMatchInAwayTotalUnder15;
            cbAllMatchInAllCleanSheets.IsChecked = Settings.Default.cbAllMatchInAllCleanSheets;
            cbAllMatchInHomeCleanSheets.IsChecked = Settings.Default.cbAllMatchInHomeCleanSheets;
            cbAllMatchInAwayCleanSheets.IsChecked = Settings.Default.cbAllMatchInAwayCleanSheets;
            cbFirstTimeInAllTotalUnder15.IsChecked = Settings.Default.cbFirstTimeInAllTotalUnder15;
            cbFirstTimeInHomeTotalUnder15.IsChecked = Settings.Default.cbFirstTimeInHomeTotalUnder15;
            cbFirstTimeInAwayTotalUnder15.IsChecked = Settings.Default.cbFirstTimeInAwayTotalUnder15;
            cbFirstTimeInAllCleanSheets.IsChecked = Settings.Default.cbFirstTimeInAllCleanSheets;
            cbFirstTimeInHomeCleanSheets.IsChecked = Settings.Default.cbFirstTimeInHomeCleanSheets;
            cbFirstTimeInAwayCleanSheets.IsChecked = Settings.Default.cbFirstTimeInAwayCleanSheets;
            cbSecondTimeInAllTotalUnder15.IsChecked = Settings.Default.cbSecondTimeInAllTotalUnder15;
            cbSecondTimeInHomeTotalUnder15.IsChecked = Settings.Default.cbSecondTimeInHomeTotalUnder15;
            cbSecondTimeInAwayTotalUnder15.IsChecked = Settings.Default.cbSecondTimeInAwayTotalUnder15;
            cbSecondTimeInAllCleanSheets.IsChecked = Settings.Default.cbSecondTimeInAllCleanSheets;
            cbSecondTimeInHomeCleanSheets.IsChecked = Settings.Default.cbSecondTimeInHomeCleanSheets;
            cbSecondTimeInAwayCleanSheets.IsChecked = Settings.Default.cbSecondTimeInAwayCleanSheets;
            cbAllMatchInAllBothFailedToScore.IsChecked = Settings.Default.cbAllMatchInAllBothFailedToScore;
            cbAllMatchInHomeBothFailedToScore.IsChecked = Settings.Default.cbAllMatchInHomeBothFailedToScore;
            cbAllMatchInAwayBothFailedToScore.IsChecked = Settings.Default.cbAllMatchInAwayBothFailedToScore;
            cbFirstTimeInAllBothFailedToScore.IsChecked = Settings.Default.cbFirstTimeInAllBothFailedToScore;
            cbFirstTimeInHomeBothFailedToScore.IsChecked = Settings.Default.cbFirstTimeInHomeBothFailedToScore;
            cbFirstTimeInAwayBothFailedToScore.IsChecked = Settings.Default.cbFirstTimeInAwayBothFailedToScore;
            cbSecondTimeInAllBothFailedToScore.IsChecked = Settings.Default.cbSecondTimeInAllBothFailedToScore;
            cbSecondTimeInHomeBothFailedToScore.IsChecked = Settings.Default.cbSecondTimeInHomeBothFailedToScore;
            cbSecondTimeInAwayBothFailedToScore.IsChecked = Settings.Default.cbSecondTimeInAwayBothFailedToScore;
        }

        private void NumberValidTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DeleteWhitespacesAndSetDefaultWhenLostFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).Text = Regex.Replace((sender as TextBox).Text, @"\s+", "");
            if ((sender as TextBox).Text == "")
                (sender as TextBox).Text = "2";
        }
    }
}