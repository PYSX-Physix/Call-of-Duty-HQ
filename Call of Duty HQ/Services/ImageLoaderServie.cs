using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Newtonsoft.Json.Linq;

public class ImageStreamer
{
    public async Task<string> GetImageUrlAsync(string jsonUrl)
    {
        using (var client = new HttpClient())
        {
            var json = await client.GetStringAsync(jsonUrl);
            var jsonObject = JObject.Parse(json);
            return jsonObject["newsimage1"].ToString();
        }
    }
    public async Task LoadImage(string imageUrl, Image image)
    {
        var uri = new Uri(imageUrl);
        var bitmapImage = new BitmapImage(uri);
        image.Source = bitmapImage;
    }

    internal async Task LoadImage(string? imagejsonurl, JsonElement newsImage) => throw new NotImplementedException();
}
