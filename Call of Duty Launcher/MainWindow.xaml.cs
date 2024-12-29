using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Net;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Compression;
using Microsoft.Win32;

namespace Call_of_Duty_Launcher
{

#pragma warning disable SYSLIB0014 // Type or member is obsolete
    public partial class MainWindow : Window
    {
        string OnlineVersionString;
        string displayVersion;

        public MainWindow()
        {
            InitializeComponent();
            Startup();
        }

        private async void Startup()
        {
            //Checks if the Directory Exists
            MainBar.IsIndeterminate = true;
            MainText.Text = "Checking if Launcher Exists";
            if (!File.Exists($"{Directory.GetCurrentDirectory()}\\Application\\Call of Duty HQ.exe"))
            {
                if (!File.Exists(Directory.GetCurrentDirectory() + "\\Call of Duty HQ.zip"))
                {
                    MainBar.IsIndeterminate = false;
                    try
                    {
                        WebClient client = new();
                        client.DownloadDataCompleted += Client_DownloadDataCompleted;
                        client.DownloadProgressChanged += Client_DownloadProgressChanged;
                        client.DownloadFileAsync(new Uri("https://api.onedrive.com/v1.0/shares/s!AqHJOX3p8RnQo5tkymKIaEENISXEjg/root/content"), "Call of Duty HQ.zip");
                    }
                    catch (WebException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MainText.Text = "Extracting Files";
                    MainBar.IsIndeterminate = true;
                    try
                    {
                        MainBar.IsIndeterminate = true;
                        MainText.Text = "Extracting Files";
                        ZipFile.ExtractToDirectory("Call of Duty HQ.zip", "Application");
                        File.Delete($"{Directory.GetCurrentDirectory()}\\Call of Duty HQ.zip");
                        Launch();
                    }
                    catch (DirectoryNotFoundException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (InvalidDataException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            //Checks For Updates
            MainText.Text = "Checking for Updates...";
            MainBar.IsIndeterminate = true;
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
                    }
                }

            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (JsonException ex)
            {
                MessageBox.Show(ex.Message);
            }

            CheckforUpdates();
            if (displayVersion != OnlineVersionString)
            {
                MainBar.IsIndeterminate = false;
                try
                {
                    MainBar.IsIndeterminate = false;
                    try
                    {
                        WebClient updateclient = new();
                        updateclient.DownloadDataCompleted += Updateclient_DownloadDataCompleted;
                        updateclient.DownloadProgressChanged += Updateclient_DownloadProgressChanged;
                        updateclient.DownloadFileAsync(new Uri("https://api.onedrive.com/v1.0/shares/s!AqHJOX3p8RnQo5tkymKIaEENISXEjg/root/content"), "Call of Duty HQ.zip");
                    }
                    catch (WebException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                catch (WebException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Updateclient_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            try
            {
                if (Directory.Exists($"{Directory.GetCurrentDirectory()}\\Application"))
                {
                    ZipFile.ExtractToDirectory("Call of Duty HQ.zip", "Application", true);
                    File.Delete(Directory.GetCurrentDirectory() + "Call of Duty HQ.zip");
                }
                else
                {
                    ZipFile.ExtractToDirectory("Call of Duty HQ.zip", "Application");
                    File.Delete(Directory.GetCurrentDirectory() + "Call of Duty HQ.zip");
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidDataException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Updateclient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Launch()
        {
            Process.Start($"{Directory.GetCurrentDirectory()}\\Application\\Call of Duty HQ.exe");
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            MainBar.Maximum = e.TotalBytesToReceive;
            MainBar.Value = e.BytesReceived;
            MainText.Text = $"Progress: {e.ProgressPercentage}%";
        }

        private void Client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            try
            {
                if (Directory.Exists($"{Directory.GetCurrentDirectory()}\\Application"))
                {
                    ZipFile.ExtractToDirectory("Call of Duty HQ.zip", "Application", true);
                    File.Delete(Directory.GetCurrentDirectory() + "Call of Duty HQ.zip");
                }
                else
                {
                    ZipFile.ExtractToDirectory("Call of Duty HQ.zip", "Application");
                    File.Delete(Directory.GetCurrentDirectory() + "Call of Duty HQ.zip");
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidDataException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void CheckforUpdates()
        {
            string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
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
        }

        private async void InstallUpdate()
        {
            
        }
    }

#pragma warning restore SYSLIB0014 // Type or member is obsolete
}