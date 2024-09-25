﻿using System.Diagnostics;
using System.Text.Json;
using Windows.Storage;
using Call_of_Duty_HQ.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace Call_of_Duty_HQ.Views;

public sealed partial class CoD2Page : Page
{
    string steamPath = ApplicationData.Current.LocalSettings.Values["Steam Path"] as string;

    public CoD2ViewModel ViewModel
    {
        get;
    }

    public CoD2Page()
    {
        ViewModel = App.GetService<CoD2ViewModel>();
        InitializeComponent();
        GetSteamStoreInfo();
    }

    private async void GetSteamStoreInfo()
    {
        string url = $"https://store.steampowered.com/appreviews/2630?json=1";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                // Parse the JSON response
                using (JsonDocument doc = JsonDocument.Parse(responseBody))
                {
                    JsonElement root = doc.RootElement;
                    if (root.TryGetProperty("query_summary", out JsonElement querySummary) &&
                        querySummary.TryGetProperty("review_score_desc", out JsonElement reviewScoreDesc))
                    {
                        FeedbackText.Text = $"Feedback: {reviewScoreDesc.GetString()}";
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                FeedbackText.Text = $"Exception Caught! Message: {ex.Message}";
            }
            catch (JsonException ex)
            {
                FeedbackText.Text = $"JSON Parsing Exception! Message: {ex.Message}";
            }
        }
    }


    private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        Process.Start($"{steamPath}\\steam.exe", "steam://rungameid/2630");
    }
}
