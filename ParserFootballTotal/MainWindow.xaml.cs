using System.Windows;
using System.Windows.Input;


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

        private void buttonMin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void buttonX_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void buttonSearchSettings_Click(object sender, RoutedEventArgs e)
        {
            SearchSettings searchSettingWindow = new SearchSettings();
            this.Hide();
            searchSettingWindow.ShowDialog();
            this.Show();
        }

        private void buttonStartToday_Click(object sender, RoutedEventArgs e)
        {
            backWorker.Start("today", this);
        }
    }
}
