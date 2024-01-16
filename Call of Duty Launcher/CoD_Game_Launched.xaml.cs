using Call_of_Duty_Launcher;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Collections.Generic;

namespace Call_of_Duty_HQ
{
    /// <summary>
    /// Interaction logic for CoD_Game_Launched.xaml
    /// </summary>
    public partial class CoD_Game_Launched : Window
    {
        public CoD_Game_Launched()
        {
            InitializeComponent();
            Left = System.Windows.SystemParameters.WorkArea.Width - Width;
            Top = System.Windows.SystemParameters.WorkArea.Height - Height;
            System.Media.SystemSounds.Hand.Play();
            ClosingTasks();
        }

        private void Ok_Button_Clicked(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private async void ClosingTasks()
        {
            await Task.Delay(5000);
            Close();
        }
    }
}
