using Call_of_Duty_HQ.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Call_of_Duty_HQ.Views;

public sealed partial class BO4Page : Page
{
    public BO4ViewModel ViewModel
    {
        get;
    }

    public BO4Page()
    {
        ViewModel = App.GetService<BO4ViewModel>();
        InitializeComponent();
    }
}
