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
    ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;


    public SettingsViewModel ViewModel
    {
        get;
    }

    public SettingsPage()
    {
        ViewModel = App.GetService<SettingsViewModel>();
        InitializeComponent();
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
            StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", folder);
            SteamPath.Text = folder.Path;
            
        }
        else
        {
            PickFolderOutputTextBlock.Text = "Operation cancelled.";
        }
    }

    
}
