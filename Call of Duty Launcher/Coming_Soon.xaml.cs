using Call_of_Duty_Launcher;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Coming_Soon.xaml
    /// </summary>
    public partial class Coming_Soon : Window
    {
        public Coming_Soon()
        {
            InitializeComponent();
        }

        private void Ok_Clicked(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();

            main.Show();

            Close();
        }
    }
}
