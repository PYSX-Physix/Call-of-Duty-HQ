using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using Call_of_Duty_HQ;

namespace Call_of_Duty_HQ.Views;

public partial class SettingsView : UserControl
{
    public SettingsView()
    {
        InitializeComponent();
        ConstructSettings();
    }

    private void ConstructSettings()
    {
        SteamDirTB.Text = Program.Configuration["AppSettings:SteamPath"];
    }

    private async void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        
        // Get top level from the current control. Alternatively, you can use Window reference instead.
        var topLevel = TopLevel.GetTopLevel(this);

        // Start async operation to open the folder picker dialog.
        var folders = await topLevel.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
        {
            Title = "Select Folder",
            AllowMultiple = false
        });

        if (folders.Count >= 1)
        {
            // Do something with the selected folder.
            var selectedFolder = folders[0];
            // Example: Get the path of the selected folder.
            var folderPath = selectedFolder.Path;
            
            Call_of_Duty_HQ.Views.Popup popup = new();
            popup.PopupTitle.Text = "Confirm Steam Directory";
            popup.PopupMessage.Text = folderPath.ToString();
            popup.CancelButton.Content = "Cancel";
            popup.PrimaryButton.Content = "Confirm";
            popup.Show();
        }
    }
}