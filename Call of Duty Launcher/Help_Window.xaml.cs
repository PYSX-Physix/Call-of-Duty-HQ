using Call_of_Duty_Launcher;
using System;
using System.Diagnostics;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Call_of_Duty_HQ
{
    /// <summary>
    /// Interaction logic for Help_Window.xaml
    /// </summary>
    public partial class Help_Window : Window
    {
        public Help_Window()
        {
            InitializeComponent();
        }

        private void Back_Clicked(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();

            this.Close();
        }

        private void repobutton_Clicked(object sender, RoutedEventArgs e)
        {
            string url = "https://github.com/Physix-Physix/Call-of-Duty-Launcher";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        
        }
    }
}
