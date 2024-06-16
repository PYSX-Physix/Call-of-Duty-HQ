using Call_of_Duty_HQ.ViewModels;
using System.Diagnostics;
using Microsoft.UI.Xaml.Controls;

namespace Call_of_Duty_HQ.Views;

public sealed partial class MWIIIPage : Page
{
    public MWIIIViewModel ViewModel
    {
        get;
    }

    public MWIIIPage()
    {
        ViewModel = App.GetService<MWIIIViewModel>();
        InitializeComponent();
    }

    private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        Process.Start("C:\\Program Files (x86)\\Steam\\steam.exe", "steam://rungameid/1938090");
    }
}
