using Call_of_Duty_HQ.ViewModels;
using System.Diagnostics;
using Microsoft.UI.Xaml.Controls;
using Windows.Storage;

namespace Call_of_Duty_HQ.Views;

public sealed partial class MWIIIPage : Page
{
    string steamPath = ApplicationData.Current.LocalSettings.Values["Steam Path"] as string;

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
        Process.Start($"{steamPath}\\steam.exe", "steam://rungameid/1938090");
    }
}
