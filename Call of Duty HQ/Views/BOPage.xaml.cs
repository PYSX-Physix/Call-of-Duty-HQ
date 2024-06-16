using Call_of_Duty_HQ.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Call_of_Duty_HQ.Views;

public sealed partial class BOPage : Page
{
    public BOViewModel ViewModel
    {
        get;
    }

    public BOPage()
    {
        ViewModel = App.GetService<BOViewModel>();
        InitializeComponent();
    }
}
