using Microsoft.Win32;
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
using System.IO;

namespace Call_of_Duty_Launcher
{
    /// <summary>
    /// Interaction logic for Steam_API_ID_Enter.xaml
    /// </summary>
    public partial class Steam_API_ID_Enter : Window
    {
        public Steam_API_ID_Enter()
        {
            InitializeComponent();

            
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Continue_Clicked(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();


        }

        
    }
}
