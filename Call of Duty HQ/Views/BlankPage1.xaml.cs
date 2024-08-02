using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Call_of_Duty_HQ.Contracts.Services;
using Call_of_Duty_HQ.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Call_of_Duty_HQ.Views;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class BlankPage1 : Page
{
    readonly INavigationService _navigationService;

    public BlankPage1()
    {
        this.InitializeComponent();
    }

    private void MWIII_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
#pragma warning disable CS8604 // Possible null reference argument.
        _navigationService.NavigateTo(typeof(MWIIIViewModel).FullName);

    }

    private void MWII_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(MWIIViewModel).FullName);
    }

    private void V_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(VanguardViewModel).FullName);
    }

    private void BOCW_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(BOCWViewModel).FullName);
    }

    private void MW_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(MW2019ViewModel).FullName);
    }

    private void WWII_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(WWIIViewModel).FullName);
    }

    private void IW_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(IWViewModel).FullName);
    }

    private void BO3_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(BO3ViewModel).FullName);
    }

    private void AW_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(AWViewModel).FullName);
    }

    private void G_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(GhostsViewModel).FullName);
    }

    private void BO2_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(BO2ViewModel).FullName);
    }

    private void MW3_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(MW3ViewModel).FullName);
    }

    private void BO_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(BOViewModel).FullName);
    }

    private void MW2_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(MW2ViewModel).FullName);
    }

    private void WaW_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(WaWViewModel).FullName);
    }

    private void MW4_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(CoD4MWViewModel).FullName);
    }

    private void C3_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(CoD3ViewModel).FullName);
    }

    private void C2_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(CoD2ViewModel).FullName);
    }

    private void C_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(CoDViewModel).FullName);
    }

    private void BO6_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(BO6ViewModel).FullName);
    }
}
