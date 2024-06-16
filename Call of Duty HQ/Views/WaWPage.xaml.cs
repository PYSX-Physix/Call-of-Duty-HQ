using Call_of_Duty_HQ.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Call_of_Duty_HQ.Views;

public sealed partial class WaWPage : Page
{
    public WaWViewModel ViewModel
    {
        get;
    }

    public WaWPage()
    {
        ViewModel = App.GetService<WaWViewModel>();
        InitializeComponent();
    }
}
