using Call_of_Duty_Launcher;
using System;
using System.Diagnostics;
using System.Windows;

namespace Call_of_Duty_HQ.Games
{
    /// <summary>
    /// Interaction logic for Call_of_Duty_UO_Window.xaml
    /// </summary>
    public partial class Call_of_Duty_UO_Window : Window
    {
        public Call_of_Duty_UO_Window()
        {
            InitializeComponent();
        }

        private void CoD_Run_Clicked(object sender, EventArgs e)
        {
            CoD_Game_Launched coD_Game_Launched = new CoD_Game_Launched();

            coD_Game_Launched.Show();

            Process process = Process.Start("steam://rungameid/2640");

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
