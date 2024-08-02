﻿using System.Diagnostics;
using Call_of_Duty_HQ.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Call_of_Duty_HQ.Views;

public sealed partial class WaWPage : Page
{
    public WaWViewModel ViewModel
    {
        get;
    }

    public WaWPage()
    {
        ViewModel = App.GetService<WaWViewModel>();
        InitializeComponent();
    }
    private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        Process.Start("C:\\Program Files (x86)\\Steam\\steam.exe", "steam://rungameid/1938090");
    }
}