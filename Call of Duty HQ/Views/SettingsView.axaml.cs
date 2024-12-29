﻿using System;
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
    string AppVersion = "1.0.0.0";
    private string OnlineVersionString;
    private string displayVersion;

    public SettingsView()
    {
        InitializeComponent();
        ConstructSettings();
    }

    private async void ConstructSettings()
    {
        string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
        LocalVersion.Text = $"Current Version: {AppVersion}";
        SteamDirTB.Text = Program.Configuration["AppSettings:SteamPath"];

        using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey))
        {
            if (key != null)
            {
                foreach (string subkeyName in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkeyName))
                    {
                        if (subkey != null)
                        {
                            displayVersion = subkey.GetValue("DisplayVersion") as string;
                        }
                    }
                }
            }
        }

        try
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync("http://127.0.0.1:5500/avaupdates.json");
            message.EnsureSuccessStatusCode();
            string responsebody = await message.Content.ReadAsStringAsync();

            using (JsonDocument doc = JsonDocument.Parse(responsebody))
            {
                JsonElement root = doc.RootElement;
                if (root.TryGetProperty("ReleaseLauncher", out JsonElement versionsummary) && (
                    versionsummary.TryGetProperty("LatestVersion", out JsonElement versionelement)))
                {
                    OnlineVersionString = versionelement.ToString();
                    OnlineVersion.Text = $"Latest Version: {OnlineVersionString}";
                }
            }

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

        if (AppVersion != OnlineVersionString)
        {
            if (OnlineVersionString != null)
            {
                Call_of_Duty_HQ.Views.Popup popup = new();
                popup.Title = "Update Available";
                popup.PopupTitle.Text = "An Update is Available";
                popup.PopupMessage.Text = $"An update {OnlineVersionString} you're on {AppVersion}";
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