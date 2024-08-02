using System.Diagnostics;
using Call_of_Duty_HQ.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Call_of_Duty_HQ.Views;

public sealed partial class CoD4MWPage : Page
{
    public CoD4MWViewModel ViewModel
    {
        get;
    }

    public CoD4MWPage()
    {
        ViewModel = App.GetService<CoD4MWViewModel>();
        InitializeComponent();
    }

    private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        Process.Start("C:\\Program Files (x86)\\Steam\\steam.exe", "steam://rungameid/7940");
    }
}
