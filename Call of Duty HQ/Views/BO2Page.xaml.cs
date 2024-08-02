﻿using System.Diagnostics;
using Call_of_Duty_HQ.ViewModels;

using Microsoft.UI.Xaml.Controls;
using Windows.Storage;

namespace Call_of_Duty_HQ.Views;

public sealed partial class BO2Page : Page
{
    string steamPath = ApplicationData.Current.LocalSettings.Values["Steam Path"] as string;

    public BO2ViewModel ViewModel
    {
        get;
    }

    public BO2Page()
    {
        ViewModel = App.GetService<BO2ViewModel>();
        InitializeComponent();
    }

    private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        Process.Start($"{steamPath}\\steam.exe", "steam://rungameid/202970");
    }
}
