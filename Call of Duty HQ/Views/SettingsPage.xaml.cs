using Call_of_Duty_HQ.ViewModels;

using Microsoft.UI.Xaml.Controls;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.Storage;
using Call_of_Duty_HQ.Helpers;
using Microsoft.UI.System;
using Call_of_Duty_HQ.Contracts.Services;
using System.Linq;

namespace Call_of_Duty_HQ.Views;

public sealed partial class SettingsPage : Page
{
    public SettingsViewModel ViewModel
    {
        get;
    }

    public SettingsPage()
    {
        ViewModel = App.GetService<SettingsViewModel>();
        this.InitializeComponent();
        Construct();
    }

    private void Construct()
    {
        string SteamFolder = ApplicationData.Current.LocalSettings.Values["Steam Path"] as string;
        SteamPath.Text = SteamFolder;
    }

    private async void PickFolderButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        // Clear previous returned file name, if it exists, between iterations of this scenario

        // Create a folder picker
        FolderPicker openPicker = new Windows.Storage.Pickers.FolderPicker();

        // See the sample code below for how to make the window accessible from the App class.
        var window = App.MainWindow;

        // Retrieve the window handle (HWND) of the current WinUI 3 window.
        var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);

        // Initialize the folder picker with the window handle (HWND).
        WinRT.Interop.InitializeWithWindow.Initialize(openPicker, hWnd);

        // Set options for your folder picker
        openPicker.SuggestedStartLocation = PickerLocationId.Desktop;
        openPicker.FileTypeFilter.Add("*");

        // Open the picker for the user to pick a folder
        StorageFolder folder = await openPicker.PickSingleFolderAsync();
        if (folder != null)
        {
            if (File.Exists("\\steam.exe"))
            {
                ApplicationData.Current.LocalSettings.Values["Steam Path"] = folder.Path;
                SteamPath.Text= folder.Path;
                SteamInfoBar.Title = "Success";
                SteamInfoBar.IsOpen = true;
                SteamInfoBar.Severity = InfoBarSeverity.Success;
                SteamInfoBar.Message = "Steam has been found and this directory has been saved.";
            }
            else
            {
                ApplicationData.Current.LocalSettings.Values["Steam Path"] = folder.Path;
                SteamPath.Text = folder.Path;
                SteamInfoBar.Title = "Error";
                SteamInfoBar.IsOpen = true;
                SteamInfoBar.Severity = InfoBarSeverity.Error;
                SteamInfoBar.Message = "Steam is not detected in this folder please try another folder.";
            }

        }
        else
        {
            
        }
    }

    
}
