using Call_of_Duty_HQ.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Call_of_Duty_HQ.Views;

public sealed partial class CoD3Page : Page
{
    public CoD3ViewModel ViewModel
    {
        get;
    }

    public CoD3Page()
    {
        ViewModel = App.GetService<CoD3ViewModel>();
        InitializeComponent();
    }
}
