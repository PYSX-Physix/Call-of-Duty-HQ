using Call_of_Duty_HQ.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Call_of_Duty_HQ.Views;

public sealed partial class UOPage : Page
{
    public UOViewModel ViewModel
    {
        get;
    }

    public UOPage()
    {
        ViewModel = App.GetService<UOViewModel>();
        InitializeComponent();
    }
}
