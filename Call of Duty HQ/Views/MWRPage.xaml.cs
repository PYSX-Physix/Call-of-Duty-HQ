using System.Diagnostics;
using System.Text.Json;
using Windows.Storage;
using Call_of_Duty_HQ.ViewModels;
using Microsoft.UI.Xaml.Controls;
using Call_of_Duty_HQ.Contracts.Services;

namespace Call_of_Duty_HQ.Views;

public sealed partial class MWRPage : Page
{
    string steamPath = ApplicationData.Current.LocalSettings.Values["Steam Path"] as string;
    readonly INavigationService _navigationService;

    public MWRViewModel ViewModel
    {
        get;
    }

    public MWRPage()
    {
        ViewModel = App.GetService<MWRViewModel>();
        InitializeComponent();
        GetSteamStoreInfo();
        _navigationService = App.GetService<INavigationService>();
    }

    private async void GetSteamStoreInfo()
    {
        string url = $"https://store.steampowered.com/appreviews/393080?json=1";

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
        Process.Start($"{steamPath}\\steam.exe", "steam://rungameid/393080");
    }

    private void Border_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        _navigationService.NavigateTo(typeof(MWRViewModel).FullName);
    }
}
