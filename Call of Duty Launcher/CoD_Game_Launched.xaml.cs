using System.Windows;

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
        }

        private void Ok_Button_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
