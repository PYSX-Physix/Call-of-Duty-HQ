using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Call_of_Duty_HQ.Services;
using Microsoft.Extensions.Configuration;

namespace Call_of_Duty_HQ.Views;

public partial class MainView : UserControl
{
    private string SteamDir = Program.Configuration["AppSettings:SteamPath"];
    
    public MainView()
    {
        InitializeComponent();
    }


    private void StartCoDGame(int SteamID)
    {
        Steam steam = new Steam();
        steam.StartCoD(SteamID);
        if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.Shutdown();
        }
    }
    private void CoDHQ_OnClick(object? sender, RoutedEventArgs e)
    {
        StartCoDGame(1938090);
    }
}