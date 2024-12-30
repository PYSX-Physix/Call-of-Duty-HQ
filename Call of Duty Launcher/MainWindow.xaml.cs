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
    public partial class MainWindow : Window
    {
        string OnlineVersionString;
        string displayVersion;

        public MainWindow()
        {
            InitializeComponent();
            CheckforUpdates();
        }

        private void Launch()
        {
            Process.Start($"{Directory.GetCurrentDirectory()}\\Application\\Call of Duty HQ.exe");
            Application.Current.Shutdown();
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            MainBar.Maximum = e.TotalBytesToReceive;
            MainBar.Value = e.BytesReceived;
        }

        private void Client_DownloadFileCompleted(object? sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            try
            {
                if (Directory.Exists($"{Directory.GetCurrentDirectory()}\\Application"))
                {
                    MainText.Text = "Overwriting Old Files";
                    ZipFile.ExtractToDirectory("Call of Duty HQ.zip", "Application", true);
                    File.Delete("Call of Duty HQ.zip");
                    RegisterApp();
                    Launch();
                }
                else
                {
                    MainText.Text = "Extracting Files";
                    Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\Application\\");
                    ZipFile.ExtractToDirectory("Call of Duty HQ.zip", "Application");
                    File.Delete("Call of Duty HQ.zip");
                    Launch();
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
            if (!Directory.Exists("Application"))
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += Client_DownloadFileCompleted;
                webClient.DownloadProgressChanged += Client_DownloadProgressChanged;
                webClient.DownloadFileAsync(new Uri("https://github.com/PYSX-Physix/Call-of-Duty-HQ/releases/latest/download/Call.of.Duty.HQ.zip"), "Call of Duty HQ.zip");
            }
            else
            {
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
                    MessageBox.Show(ex.Message);
                    return;
                }

                if (displayVersion != OnlineVersionString)
                {
                    MessageBox.Show("An update is available. Please click OK to download the latest version.");
                    WebClient webClient = new WebClient();
                    webClient.DownloadFileCompleted += Client_DownloadFileCompleted;
                    webClient.DownloadProgressChanged += Client_DownloadProgressChanged;
                    webClient.DownloadFileAsync(new Uri("https://github.com/PYSX-Physix/Call-of-Duty-HQ/releases/latest/download/Call.of.Duty.HQ.zip"), "Call of Duty HQ.zip");
                }
                else
                {
                    Launch();
                }
            }
        }



        private bool IsAdministrator()
        {
            var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            var principal = new System.Security.Principal.WindowsPrincipal(identity);
            return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
        }

        private void ElevateProcess()
        {
            var processInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = Process.GetCurrentProcess().MainModule.FileName,
                Verb = "runas"
            };

            try
            {
                Process.Start(processInfo);
                Application.Current.Shutdown();
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MainText.Text= "The application requires administrative privileges to install.";
                MainBar.IsIndeterminate = false;
            }
        }

        public void RegisterApp()
        {
            if (IsAdministrator() == false)
            {
                ElevateProcess();
            }
            else
            {
                //Sets up app name and information in Registry Editor
                string appName = "Call of Duty HQ";

                //Adds the keys to a dedicated folder with name, version, publisher, locations, and program size
                RegistryKey key = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall\" + appName);


                key.SetValue("DisplayVersion", OnlineVersionString);
                key.Close();


            }
        }
    }
}