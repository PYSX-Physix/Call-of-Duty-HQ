﻿using System.Text.Json;
using Call_of_Duty_HQ.Contracts.Services;
using Call_of_Duty_HQ.Services;
using Call_of_Duty_HQ.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Call_of_Duty_HQ.Views;

public sealed partial class MainPage : Page
{
    readonly INavigationService _navigationService;
#pragma warning disable CS8604 // Possible null reference argument.
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
        _navigationService = App.GetService<INavigationService>();
    }

    private void BO6_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(BO6ViewModel).FullName);
    }

    private void MWIII_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(MWIIIViewModel).FullName);
    }

    private void MWII_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(MWIIViewModel).FullName);
    }

    private void V_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(VanguardViewModel).FullName);
    }

    private void BOCW_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(BOCWViewModel).FullName);
    }

    private void MW_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(MW2019ViewModel).FullName);
    }

    private void WWII_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(WWIIViewModel).FullName);
    }

    private void IW_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(IWViewModel).FullName);
    }

    private void BO3_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(BO3ViewModel).FullName);
    }

    private void AW_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(AWViewModel).FullName);
    }

    private void G_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(GhostsViewModel).FullName);
    }

    private void BO2_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(BO2ViewModel).FullName);
    }

    private void MW3_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(MW3ViewModel).FullName);
    }

    private void BO_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(BOViewModel).FullName);
    }

    private void MW2_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(MW2ViewModel).FullName);
    }

    private void WaW_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(WaWViewModel).FullName);
    }

    private void MW4_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(CoD4MWViewModel).FullName);
    }

    private void C3_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(CoD3ViewModel).FullName);
    }

    private void C2_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(CoD2ViewModel).FullName);
    }

    private void C_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(CoDViewModel).FullName);
    }
#pragma warning restore CS8604 // Possible null reference argument.
}
