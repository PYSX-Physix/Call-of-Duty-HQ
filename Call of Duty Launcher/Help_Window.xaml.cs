using Call_of_Duty_Launcher;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            string url = "https://github.com/Physix-Physix/Call-of-Duty-HQ/tree/main";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
    }
}
