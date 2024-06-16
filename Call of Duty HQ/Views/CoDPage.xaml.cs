using Call_of_Duty_HQ.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Call_of_Duty_HQ.Views;

public sealed partial class CoDPage : Page
{
    public CoDViewModel ViewModel
    {
        get;
    }

    public CoDPage()
    {
        ViewModel = App.GetService<CoDViewModel>();
        InitializeComponent();
    }
}
