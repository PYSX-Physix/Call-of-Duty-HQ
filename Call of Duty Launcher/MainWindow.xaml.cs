using Call_of_Duty_HQ.Games;
using Call_of_Duty_HQ;
using System;
using System.Windows;
using System.Net;
using System.Diagnostics;
using System.Windows.Media.Animation;

namespace Call_of_Duty_Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowAbout windowAbout = new WindowAbout();

            windowAbout.Show();
        }

        private void Button_Click_Help(object sender, RoutedEventArgs e)
        {
            Help_Window help_Window = new Help_Window();
            help_Window.Show();
            this.Close();
        }

        private void ___CallofDutyLaunch_Clicked(object sender, RoutedEventArgs e)
        {
            Call_of_Duty_Window call_Of_Duty_Window = new Call_of_Duty_Window();
            call_Of_Duty_Window.Show();

            Close();
        }

        private void ___CallofDutyLaunchUO__Clicked(object sender, RoutedEventArgs e)
        {
            Call_of_Duty_UO_Window call_Of_Duty_UO_ = new Call_of_Duty_UO_Window();
            call_Of_Duty_UO_.Show();

            Close();
        }

        private void ___CallofDutyLaunch2__Clicked(object sender, RoutedEventArgs e)
        {
            Call_of_Duty_2_Window coD_2 = new Call_of_Duty_2_Window();

            coD_2.Show();

            this.Close();
        }

        private void ___CallofDutyLaunch___MW_Clicked(object sender, RoutedEventArgs e)
        {
            Call_of_Duty_4_MW coD_4_MW = new Call_of_Duty_4_MW();

            coD_4_MW.Show();

            this.Close();
        }

        private void ___CallofDutyLaunch___WaW_Clicked(object sender, RoutedEventArgs e)
        {
            Call_of_Duty_WaW_Window CoD_Game_WaW = new Call_of_Duty_WaW_Window();

            CoD_Game_WaW.Show();

            this.Close();
        }

        private void ___CallofDutyLaunch___MW2_Clicked(object sender, RoutedEventArgs e)
        {
            Call_of_Duty_MW2 coD_MW2 = new Call_of_Duty_MW2();

            coD_MW2.Show();

            this.Close();
        }

        private void ___CallofDutyLaunch___BO_Clicked(object sender, RoutedEventArgs e)
        {
            Call_of_Duty_BO_Window CoD_BO = new Call_of_Duty_BO_Window();

            CoD_BO.Show();

            this.Close();
        }

        private void ___CallofDutyLaunch___MW3_Clicked(object sender, RoutedEventArgs e)
        {
            Call_of_Duty_MW3_Window CoD_MW3 = new Call_of_Duty_MW3_Window();

            CoD_MW3.Show();

            this.Close();
        }

        private void ___CallofDutyLaunch___BO_2_Clicked(object sender, RoutedEventArgs e)
        {
            Call_of_Duty_BO2_Window CoD_BO2 = new Call_of_Duty_BO2_Window();

            CoD_BO2.Show();

            this.Close();
        }

        private void ___CallofDutyLaunch___G_Clicked(object sender, RoutedEventArgs e)
        {
            Call_of_Duty_G_Window CoD_Ghost = new Call_of_Duty_G_Window();

            CoD_Ghost.Show();

            this.Close();
        }

        private void ___CallofDutyLaunch___AW_Clicked(object sender, RoutedEventArgs e)
        {
            Call_of_Duty_AW_Window CoD_AW = new Call_of_Duty_AW_Window();

            CoD_AW.Show();

            this.Close();
        }

        private void ___CallofDutyLaunch___BO_3_Clicked(object sender, RoutedEventArgs e)
        {
            Call_of_Duty_BO3_Window CoD_BO3 = new Call_of_Duty_BO3_Window();

            CoD_BO3.Show();

            this.Close();
        }

        private void ___CallofDutyLaunch___IW_Clicked(object sender, RoutedEventArgs e)
        {
            Call_of_Duty_IW_Window CoD_IW = new Call_of_Duty_IW_Window();

            CoD_IW.Show();

            this.Close();
        }

        private void ___CallofDutyLaunch___WW2_Clicked(object sender, RoutedEventArgs e)
        {
            Call_of_Duty_WW2_Window CoD_WW2 = new Call_of_Duty_WW2_Window();

            CoD_WW2.Show();

            this.Close();
        }

        private void ___CallofDutyLaunch__MW_19_Clicked(object sender, RoutedEventArgs e)
        {
            Call_of_Duty_MW_19_Window CoD_MW_19 = new Call_of_Duty_MW_19_Window();

            CoD_MW_19.Show();

            this.Close();
        }

        private void ___CallofDutyLaunch___BOCW_Clicked(object sender, RoutedEventArgs e)
        {
            Call_of_Duty_BOCW_Window CoD_BOCW = new Call_of_Duty_BOCW_Window();

            CoD_BOCW.Show();

            this.Close();
        }

        private void ___CallofDutyLaunch__VG_Click(object sender, RoutedEventArgs e)
        {
            Call_of_Duty_VG_Window CoD_VG = new Call_of_Duty_VG_Window();

            CoD_VG.Show();

            this.Close();
        }

        private void ___CallofDutyLaunch__MW2_22_Clicked(object sender, RoutedEventArgs e)
        {
            Call_of_Duty_MWII_Window CoD_MWII = new Call_of_Duty_MWII_Window();

            CoD_MWII.Show();

            this.Close();
        }

        }
    }

