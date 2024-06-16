using Call_of_Duty_HQ.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Call_of_Duty_HQ.Views;

public sealed partial class MW2Page : Page
{
    public MW2ViewModel ViewModel
    {
        get;
    }

    public MW2Page()
    {
        ViewModel = App.GetService<MW2ViewModel>();
        InitializeComponent();
    }
}
