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

namespace Call_of_Duty_HQ.Games
{
    /// <summary>
    /// Interaction logic for Call_of_Duty_MW_III.xaml
    /// </summary>
    public partial class Call_of_Duty_MW_III : Window
    {
        public Call_of_Duty_MW_III()
        {
            InitializeComponent();
        }

        private void CoD_Run_Clicked(object sender, RoutedEventArgs e)
        {
            Coming_Soon coming_Soon = new Coming_Soon();

            coming_Soon.Show();

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
