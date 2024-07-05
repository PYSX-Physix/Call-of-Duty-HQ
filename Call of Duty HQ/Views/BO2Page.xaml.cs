using Call_of_Duty_HQ.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Call_of_Duty_HQ.Views;

public sealed partial class BO2Page : Page
{
    public BO2ViewModel ViewModel
    {
        get;
    }

    public BO2Page()
    {
        ViewModel = App.GetService<BO2ViewModel>();
        InitializeComponent();
    }
}
