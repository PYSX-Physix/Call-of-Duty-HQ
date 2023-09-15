using System.Windows;
using System.Diagnostics;
using System;
using Call_of_Duty_Launcher;

namespace Call_of_Duty_HQ.Games
{
    /// <summary>
    /// Interaction logic for Call_of_Duty_2_Window.xaml
    /// </summary>
    public partial class Call_of_Duty_2_Window : Window
    {
        public Call_of_Duty_2_Window()
        {
            InitializeComponent();
        }

        private void CoD_Run_Clicked(object sender, EventArgs e)
        {
            CoD_Game_Launched coD_Game_Launched = new CoD_Game_Launched();

            coD_Game_Launched.Show();

            Process process = Process.Start("C:\\Program Files (x86)\\Steam\\steam.exe", "steam://rungameid/2630");

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
