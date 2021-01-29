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

        public void CompletedWork()
        {
            labelStatus.Content = "Статус: Не работает";
            buttonSearchSettings.IsEnabled = true;
            buttonStartThreeDays.IsEnabled = true;
            buttonStartToday.IsEnabled = true;
            gridCheckBoxes.IsEnabled = true;
            progressBarMain.Value = 0;
        }

        private void DisableFormAndRefreshVariables()
        {
            labelStatus.Content = "Статус: Поиск матчей";
            buttonSearchSettings.IsEnabled = false;
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

        private void buttonSearchSettings_Click(object sender, RoutedEventArgs e)
        {
            SearchSettings searchSettingWindow = new SearchSettings();
            this.Hide();
            searchSettingWindow.ShowDialog();
            this.Show();
        }

        private void buttonStartToday_Click(object sender, RoutedEventArgs e)
        {
            DisableFormAndRefreshVariables();
            backWorker.Start("сегодня", this);
        }

        private void buttonStartThreeDays_Click(object sender, RoutedEventArgs e)
        {
            backWorker.Start("сегодня, завтра, послезавтра", this);
        }
    }
}
