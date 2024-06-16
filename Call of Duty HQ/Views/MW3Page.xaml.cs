using Call_of_Duty_HQ.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Call_of_Duty_HQ.Views;

public sealed partial class MW3Page : Page
{
    public MW3ViewModel ViewModel
    {
        get;
    }

    public MW3Page()
    {
        ViewModel = App.GetService<MW3ViewModel>();
        InitializeComponent();
    }
}
