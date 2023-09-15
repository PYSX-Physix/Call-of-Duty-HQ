using System.Windows;
using System.Diagnostics;
using Call_of_Duty_Launcher;

namespace Call_of_Duty_HQ.Games
{
    /// <summary>
    /// Interaction logic for Call_of_Duty_Window.xaml
    /// </summary>
    public partial class Call_of_Duty_Window : Window
    {
        public Call_of_Duty_Window()
        {
            InitializeComponent();
        }

        private void CoD_Run_Clicked(object sender, RoutedEventArgs e)
        {
            Process process = Process.Start("C:\\Program Files (x86)\\Steam\\steam.exe", "steam://rungameid/2620");

            CoD_Game_Launched Game_Launched = new CoD_Game_Launched();

            Game_Launched.Show();
            
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
