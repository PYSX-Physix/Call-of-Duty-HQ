using Call_of_Duty_Launcher;
using System.Diagnostics;
using System.Windows;

namespace Call_of_Duty_HQ.Games
{
    /// <summary>
    /// Interaction logic for Call_of_Duty_MWII_Window.xaml
    /// </summary>
    public partial class Call_of_Duty_MWII_Window : Window
    {
        public Call_of_Duty_MWII_Window()
        {
            InitializeComponent();
        }

        private void CoD_Run_Clicked(object sender, RoutedEventArgs e)
        {
            CoD_Game_Launched coD_Game_Launched = new CoD_Game_Launched();

            coD_Game_Launched.Show();

            Process process = Process.Start("C:\\Program Files (x86)\\Steam\\steam.exe", "steam://rungameid/1938090");

            this.Close();
        }

        private void Back_Clicked(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();

            this.Close();
        }
    }
}
