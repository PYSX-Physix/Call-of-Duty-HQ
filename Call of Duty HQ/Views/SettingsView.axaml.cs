using System;
using System.Net.Http;
using System.Text.Json;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using Call_of_Duty_HQ;
using Microsoft.Win32;

namespace Call_of_Duty_HQ.Views;

public partial class SettingsView : UserControl
{
    private string OnlineVersionString;
    private string displayVersion;

    public SettingsView()
    {
        InitializeComponent();
        ConstructSettings();
    }

    private async void ConstructSettings()
    {
        SteamDirTB.Text = Program.Configuration["AppSettings:SteamPath"];

        string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Call of Duty HQ";
        using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey))
        {
            if (key != null)
            {
                displayVersion = key.GetValue("DisplayVersion") as string;
            }
        }



        try
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Call of Duty Launcher");
            HttpResponseMessage response = await client.GetAsync("https://api.github.com/repos/PYSX-Physix/Call-of-Duty-HQ/releases/latest");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var json = JsonDocument.Parse(responseBody);
            OnlineVersionString = json.RootElement.GetProperty("tag_name").ToString();
        }
        catch (HttpRequestException ex)
        {
            Call_of_Duty_HQ.Views.Popup popup = new();
            popup.Title = "Error";
            popup.Content = ex.Message;
            popup.Show();
        }
        catch (JsonException ex)
        {
            Call_of_Duty_HQ.Views.Popup popup = new();
            popup.Title = "Error";
            popup.Content = ex.Message;
            popup.Show();
        }

        LocalVersion.Text = $"Current Version: {displayVersion}";
        OnlineVersion.Text = $"Online Version: {OnlineVersionString}";


        if (displayVersion != OnlineVersionString)
        {
            if (OnlineVersionString != null)
            {
                Call_of_Duty_HQ.Views.Popup popup = new();
                popup.Title = "Update Available";
                popup.PopupTitle.Text = "An Update is Available";
                popup.PopupMessage.Text = $"An update {OnlineVersionString} you're on {displayVersion}";
                popup.IsQuestion = true;
                popup.Show();
            }
            else
            {
                return;
            }
        }
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

            //TODO: Make the selected folder actually apply the new Steam directory selected by the user
            SteamDirTB.Text += folderPath;
        }
    }
}