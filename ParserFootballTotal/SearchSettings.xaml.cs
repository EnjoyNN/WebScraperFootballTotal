using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace ParserFootballTotal
{
    /// <summary>
    /// Interaction logic for SearchSettings.xaml
    /// </summary>
    public partial class SearchSettings : Window
    {
        public SearchSettings()
        {
            InitializeComponent();
        }

        private void buttonX_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void AcceptSettings_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.settingAllMatchInAllTotalUnder05 = Convert.ToInt32(tbAllMatchInAllTotalUnder05.Text);
            Properties.Settings.Default.settingAllMatchInHomeTotalUnder05 = Convert.ToInt32(tbAllMatchInHomeTotalUnder05.Text);
            Properties.Settings.Default.settingAllMatchInAwayTotalUnder05 = Convert.ToInt32(tbAllMatchInAwayTotalUnder05.Text);
            Properties.Settings.Default.settingAllMatchInAllTotalUnder25 = Convert.ToInt32(tbAllMatchInAllTotalUnder25.Text);
            Properties.Settings.Default.settingAllMatchInHomeTotalUnder25 = Convert.ToInt32(tbAllMatchInHomeTotalUnder25.Text);
            Properties.Settings.Default.settingAllMatchInAwayTotalUnder25 = Convert.ToInt32(tbAllMatchInAwayTotalUnder25.Text);
            Properties.Settings.Default.settingAllMatchInAllFailedToScore = Convert.ToInt32(tbAllMatchInAllFailedToScore.Text);
            Properties.Settings.Default.settingAllMatchInHomeFailedToScore = Convert.ToInt32(tbAllMatchInHomeFailedToScore.Text);
            Properties.Settings.Default.settingAllMatchInAwayFailedToScore = Convert.ToInt32(tbAllMatchInAwayFailedToScore.Text);
            Properties.Settings.Default.settingFirstTimeInAllTotalUnder05 = Convert.ToInt32(tbFirstTimeInAllTotalUnder05.Text);
            Properties.Settings.Default.settingFirstTimeInHomeTotalUnder05 = Convert.ToInt32(tbFirstTimeInHomeTotalUnder05.Text);
            Properties.Settings.Default.settingFirstTimeInAwayTotalUnder05 = Convert.ToInt32(tbFirstTimeInAwayTotalUnder05.Text);
            Properties.Settings.Default.settingFirstTimeInAllTotalUnder25 = Convert.ToInt32(tbFirstTimeInAllTotalUnder25.Text);
            Properties.Settings.Default.settingFirstTimeInHomeTotalUnder25 = Convert.ToInt32(tbFirstTimeInHomeTotalUnder25.Text);
            Properties.Settings.Default.settingFirstTimeInAwayTotalUnder25 = Convert.ToInt32(tbFirstTimeInAwayTotalUnder25.Text);
            Properties.Settings.Default.settingFirstTimeInAllFailedToScore = Convert.ToInt32(tbFirstTimeInAllFailedToScore.Text);
            Properties.Settings.Default.settingFirstTimeInHomeFailedToScore = Convert.ToInt32(tbFirstTimeInHomeFailedToScore.Text);
            Properties.Settings.Default.settingFirstTimeInAwayFailedToScore = Convert.ToInt32(tbFirstTimeInAwayFailedToScore.Text);
            Properties.Settings.Default.settingSecondTimeInAllTotalUnder05 = Convert.ToInt32(tbSecondTimeInAllTotalUnder05.Text);
            Properties.Settings.Default.settingSecondTimeInHomeTotalUnder05 = Convert.ToInt32(tbSecondTimeInHomeTotalUnder05.Text);
            Properties.Settings.Default.settingSecondTimeInAwayTotalUnder05 = Convert.ToInt32(tbSecondTimeInAwayTotalUnder05.Text);
            Properties.Settings.Default.settingSecondTimeInAllTotalUnder25 = Convert.ToInt32(tbSecondTimeInAllTotalUnder25.Text);
            Properties.Settings.Default.settingSecondTimeInHomeTotalUnder25 = Convert.ToInt32(tbSecondTimeInHomeTotalUnder25.Text);
            Properties.Settings.Default.settingSecondTimeInAwayTotalUnder25 = Convert.ToInt32(tbSecondTimeInAwayTotalUnder25.Text);
            Properties.Settings.Default.settingSecondTimeInAllFailedToScore = Convert.ToInt32(tbSecondTimeInAllFailedToScore.Text);
            Properties.Settings.Default.settingSecondTimeInHomeFailedToScore = Convert.ToInt32(tbSecondTimeInHomeFailedToScore.Text);
            Properties.Settings.Default.settingSecondTimeInAwayFailedToScore = Convert.ToInt32(tbSecondTimeInAwayFailedToScore.Text);
            Properties.Settings.Default.settingAllMatchInAllTotalUnder15 = Convert.ToInt32(tbAllMatchInAllTotalUnder15.Text);
            Properties.Settings.Default.settingAllMatchInHomeTotalUnder15 = Convert.ToInt32(tbAllMatchInHomeTotalUnder15.Text);
            Properties.Settings.Default.settingAllMatchInAwayTotalUnder15 = Convert.ToInt32(tbAllMatchInAwayTotalUnder15.Text);
            Properties.Settings.Default.settingAllMatchInAllCleanSheets = Convert.ToInt32(tbAllMatchInAllCleanSheets.Text);
            Properties.Settings.Default.settingAllMatchInHomeCleanSheets = Convert.ToInt32(tbAllMatchInHomeCleanSheets.Text);
            Properties.Settings.Default.settingAllMatchInAwayCleanSheets = Convert.ToInt32(tbAllMatchInAwayCleanSheets.Text);
            Properties.Settings.Default.settingFirstTimeInAllTotalUnder15 = Convert.ToInt32(tbFirstTimeInAllTotalUnder15.Text);
            Properties.Settings.Default.settingFirstTimeInHomeTotalUnder15 = Convert.ToInt32(tbFirstTimeInHomeTotalUnder15.Text);
            Properties.Settings.Default.settingFirstTimeInAwayTotalUnder15 = Convert.ToInt32(tbFirstTimeInAwayTotalUnder15.Text);
            Properties.Settings.Default.settingFirstTimeInAllCleanSheets = Convert.ToInt32(tbFirstTimeInAllCleanSheets.Text);
            Properties.Settings.Default.settingFirstTimeInHomeCleanSheets = Convert.ToInt32(tbFirstTimeInHomeCleanSheets.Text);
            Properties.Settings.Default.settingFirstTimeInAwayCleanSheets = Convert.ToInt32(tbFirstTimeInAwayCleanSheets.Text);
            Properties.Settings.Default.settingSecondTimeInAllTotalUnder15 = Convert.ToInt32(tbSecondTimeInAllTotalUnder15.Text);
            Properties.Settings.Default.settingSecondTimeInHomeTotalUnder15 = Convert.ToInt32(tbSecondTimeInHomeTotalUnder15.Text);
            Properties.Settings.Default.settingSecondTimeInAwayTotalUnder15 = Convert.ToInt32(tbSecondTimeInAwayTotalUnder15.Text);
            Properties.Settings.Default.settingSecondTimeInAllCleanSheets = Convert.ToInt32(tbSecondTimeInAllCleanSheets.Text);
            Properties.Settings.Default.settingSecondTimeInHomeCleanSheets = Convert.ToInt32(tbSecondTimeInHomeCleanSheets.Text);
            Properties.Settings.Default.settingSecondTimeInAwayCleanSheets = Convert.ToInt32(tbSecondTimeInAwayCleanSheets.Text);
            Properties.Settings.Default.settingAllMatchInAllBothFailedToScore = Convert.ToInt32(tbAllMatchInAllBothFailedToScore.Text);
            Properties.Settings.Default.settingAllMatchInHomeBothFailedToScore = Convert.ToInt32(tbAllMatchInHomeBothFailedToScore.Text);
            Properties.Settings.Default.settingAllMatchInAwayBothFailedToScore = Convert.ToInt32(tbAllMatchInAwayBothFailedToScore.Text);
            Properties.Settings.Default.settingFirstTimeInAllBothFailedToScore = Convert.ToInt32(tbFirstTimeInAllBothFailedToScore.Text);
            Properties.Settings.Default.settingFirstTimeInHomeBothFailedToScore = Convert.ToInt32(tbFirstTimeInHomeBothFailedToScore.Text);
            Properties.Settings.Default.settingFirstTimeInAwayBothFailedToScore = Convert.ToInt32(tbFirstTimeInAwayBothFailedToScore.Text);
            Properties.Settings.Default.settingSecondTimeInAllBothFailedToScore = Convert.ToInt32(tbSecondTimeInAllBothFailedToScore.Text);
            Properties.Settings.Default.settingSecondTimeInHomeBothFailedToScore = Convert.ToInt32(tbSecondTimeInHomeBothFailedToScore.Text);
            Properties.Settings.Default.settingSecondTimeInAwayBothFailedToScore = Convert.ToInt32(tbSecondTimeInAwayBothFailedToScore.Text);

            Properties.Settings.Default.Save();

            this.Close();
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

            if (!Directory.Exists("Settings"))
                Directory.CreateDirectory("Settings");

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Settings file (*.xml)|*.xml";
            saveFileDialog.Title = "Save a settings file";
            saveFileDialog.InitialDirectory = Environment.CurrentDirectory + @"\Settings";
            saveFileDialog.ShowDialog();

            if (File.Exists(saveFileDialog.FileName))
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
            }
            else
                MessageBox.Show("Файл не найден");
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //regex code for revers expression about "="
        //(\s*)([^\s]+)\s*=\s*([^\s*]+)\s*;
        //$1$3=$2;
        //i can test new regex expressions on their website

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbAllMatchInAllTotalUnder05.Text = Properties.Settings.Default.settingAllMatchInAllTotalUnder05.ToString();
            tbAllMatchInHomeTotalUnder05.Text = Properties.Settings.Default.settingAllMatchInHomeTotalUnder05.ToString();
            tbAllMatchInAwayTotalUnder05.Text = Properties.Settings.Default.settingAllMatchInAwayTotalUnder05.ToString();
            tbAllMatchInAllTotalUnder25.Text = Properties.Settings.Default.settingAllMatchInAllTotalUnder25.ToString();
            tbAllMatchInHomeTotalUnder25.Text = Properties.Settings.Default.settingAllMatchInHomeTotalUnder25.ToString();
            tbAllMatchInAwayTotalUnder25.Text = Properties.Settings.Default.settingAllMatchInAwayTotalUnder25.ToString();
            tbAllMatchInAllFailedToScore.Text = Properties.Settings.Default.settingAllMatchInAllFailedToScore.ToString();
            tbAllMatchInHomeFailedToScore.Text = Properties.Settings.Default.settingAllMatchInHomeFailedToScore.ToString();
            tbAllMatchInAwayFailedToScore.Text = Properties.Settings.Default.settingAllMatchInAwayFailedToScore.ToString();
            tbFirstTimeInAllTotalUnder05.Text = Properties.Settings.Default.settingFirstTimeInAllTotalUnder05.ToString();
            tbFirstTimeInHomeTotalUnder05.Text = Properties.Settings.Default.settingFirstTimeInHomeTotalUnder05.ToString();
            tbFirstTimeInAwayTotalUnder05.Text = Properties.Settings.Default.settingFirstTimeInAwayTotalUnder05.ToString();
            tbFirstTimeInAllTotalUnder25.Text = Properties.Settings.Default.settingFirstTimeInAllTotalUnder25.ToString();
            tbFirstTimeInHomeTotalUnder25.Text = Properties.Settings.Default.settingFirstTimeInHomeTotalUnder25.ToString();
            tbFirstTimeInAwayTotalUnder25.Text = Properties.Settings.Default.settingFirstTimeInAwayTotalUnder25.ToString();
            tbFirstTimeInAllFailedToScore.Text = Properties.Settings.Default.settingFirstTimeInAllFailedToScore.ToString();
            tbFirstTimeInHomeFailedToScore.Text = Properties.Settings.Default.settingFirstTimeInHomeFailedToScore.ToString();
            tbFirstTimeInAwayFailedToScore.Text = Properties.Settings.Default.settingFirstTimeInAwayFailedToScore.ToString();
            tbSecondTimeInAllTotalUnder05.Text = Properties.Settings.Default.settingSecondTimeInAllTotalUnder05.ToString();
            tbSecondTimeInHomeTotalUnder05.Text = Properties.Settings.Default.settingSecondTimeInHomeTotalUnder05.ToString();
            tbSecondTimeInAwayTotalUnder05.Text = Properties.Settings.Default.settingSecondTimeInAwayTotalUnder05.ToString();
            tbSecondTimeInAllTotalUnder25.Text = Properties.Settings.Default.settingSecondTimeInAllTotalUnder25.ToString();
            tbSecondTimeInHomeTotalUnder25.Text = Properties.Settings.Default.settingSecondTimeInHomeTotalUnder25.ToString();
            tbSecondTimeInAwayTotalUnder25.Text = Properties.Settings.Default.settingSecondTimeInAwayTotalUnder25.ToString();
            tbSecondTimeInAllFailedToScore.Text = Properties.Settings.Default.settingSecondTimeInAllFailedToScore.ToString();
            tbSecondTimeInHomeFailedToScore.Text = Properties.Settings.Default.settingSecondTimeInHomeFailedToScore.ToString();
            tbSecondTimeInAwayFailedToScore.Text = Properties.Settings.Default.settingSecondTimeInAwayFailedToScore.ToString();
            tbAllMatchInAllTotalUnder15.Text = Properties.Settings.Default.settingAllMatchInAllTotalUnder15.ToString();
            tbAllMatchInHomeTotalUnder15.Text = Properties.Settings.Default.settingAllMatchInHomeTotalUnder15.ToString();
            tbAllMatchInAwayTotalUnder15.Text = Properties.Settings.Default.settingAllMatchInAwayTotalUnder15.ToString();
            tbAllMatchInAllCleanSheets.Text = Properties.Settings.Default.settingAllMatchInAllCleanSheets.ToString();
            tbAllMatchInHomeCleanSheets.Text = Properties.Settings.Default.settingAllMatchInHomeCleanSheets.ToString();
            tbAllMatchInAwayCleanSheets.Text = Properties.Settings.Default.settingAllMatchInAwayCleanSheets.ToString();
            tbFirstTimeInAllTotalUnder15.Text = Properties.Settings.Default.settingFirstTimeInAllTotalUnder15.ToString();
            tbFirstTimeInHomeTotalUnder15.Text = Properties.Settings.Default.settingFirstTimeInHomeTotalUnder15.ToString();
            tbFirstTimeInAwayTotalUnder15.Text = Properties.Settings.Default.settingFirstTimeInAwayTotalUnder15.ToString();
            tbFirstTimeInAllCleanSheets.Text = Properties.Settings.Default.settingFirstTimeInAllCleanSheets.ToString();
            tbFirstTimeInHomeCleanSheets.Text = Properties.Settings.Default.settingFirstTimeInHomeCleanSheets.ToString();
            tbFirstTimeInAwayCleanSheets.Text = Properties.Settings.Default.settingFirstTimeInAwayCleanSheets.ToString();
            tbSecondTimeInAllTotalUnder15.Text = Properties.Settings.Default.settingSecondTimeInAllTotalUnder15.ToString();
            tbSecondTimeInHomeTotalUnder15.Text = Properties.Settings.Default.settingSecondTimeInHomeTotalUnder15.ToString();
            tbSecondTimeInAwayTotalUnder15.Text = Properties.Settings.Default.settingSecondTimeInAwayTotalUnder15.ToString();
            tbSecondTimeInAllCleanSheets.Text = Properties.Settings.Default.settingSecondTimeInAllCleanSheets.ToString();
            tbSecondTimeInHomeCleanSheets.Text = Properties.Settings.Default.settingSecondTimeInHomeCleanSheets.ToString();
            tbSecondTimeInAwayCleanSheets.Text = Properties.Settings.Default.settingSecondTimeInAwayCleanSheets.ToString();
            tbAllMatchInAllBothFailedToScore.Text = Properties.Settings.Default.settingAllMatchInAllBothFailedToScore.ToString();
            tbAllMatchInHomeBothFailedToScore.Text = Properties.Settings.Default.settingAllMatchInHomeBothFailedToScore.ToString();
            tbAllMatchInAwayBothFailedToScore.Text = Properties.Settings.Default.settingAllMatchInAwayBothFailedToScore.ToString();
            tbFirstTimeInAllBothFailedToScore.Text = Properties.Settings.Default.settingFirstTimeInAllBothFailedToScore.ToString();
            tbFirstTimeInHomeBothFailedToScore.Text = Properties.Settings.Default.settingFirstTimeInHomeBothFailedToScore.ToString();
            tbFirstTimeInAwayBothFailedToScore.Text = Properties.Settings.Default.settingFirstTimeInAwayBothFailedToScore.ToString();
            tbSecondTimeInAllBothFailedToScore.Text = Properties.Settings.Default.settingSecondTimeInAllBothFailedToScore.ToString();
            tbSecondTimeInHomeBothFailedToScore.Text = Properties.Settings.Default.settingSecondTimeInHomeBothFailedToScore.ToString();
            tbSecondTimeInAwayBothFailedToScore.Text = Properties.Settings.Default.settingSecondTimeInAwayBothFailedToScore.ToString();
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
