using Call_of_Duty_HQ.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Call_of_Duty_HQ.Views;

public sealed partial class CoD2Page : Page
{
    public CoD2ViewModel ViewModel
    {
        get;
    }

    public CoD2Page()
    {
        ViewModel = App.GetService<CoD2ViewModel>();
        InitializeComponent();
    }
}
