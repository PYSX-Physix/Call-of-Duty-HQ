using System.Net.Http;
using System.Text.Json;

namespace Call_of_Duty_HQ.Services;

public class UpdateService
{
    string AppVersion = "1.0";
    private string OnlineVersionString;

    public async void CheckforUpdates()
    {
        try
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync("https://physixstudios.com/launcher.json");
            message.EnsureSuccessStatusCode();
            string responsebody = await message.Content.ReadAsStringAsync();

            using (JsonDocument doc = JsonDocument.Parse(responsebody))
            {
                JsonElement root = doc.RootElement;
                if (root.TryGetProperty("ReleaseLauncher", out JsonElement versionsummary) && (
                    versionsummary.TryGetProperty("LatestVersion", out JsonElement versionelement)))
                {
                    OnlineVersionString = versionelement.ToString();
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
}