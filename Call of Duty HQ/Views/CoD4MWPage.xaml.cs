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
}
