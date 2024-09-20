using System.Diagnostics;
using System.Text.Json;
using Call_of_Duty_HQ.ViewModels;

using Microsoft.UI.Xaml.Controls;
using Windows.Storage;

namespace Call_of_Duty_HQ.Views;

public sealed partial class CoDPage : Page
{
    string steamPath = ApplicationData.Current.LocalSettings.Values["Steam Path"] as string;

    public CoDViewModel ViewModel
    {
        get;
    }

    public CoDPage()
    {
        ViewModel = App.GetService<CoDViewModel>();
        InitializeComponent();
        GetSteamStoreInfo();
    }

    private async void GetSteamStoreInfo()
    {
        string url = $"https://store.steampowered.com/appreviews/1938090?json=1";

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
}

    private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        Process.Start($"{steamPath}\\steam.exe", "steam://rungameid/2620");
    }
}
