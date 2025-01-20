using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using Microsoft.Win32;
using System.Linq;

namespace HQ_Installer.Views
{
    public partial class MainWindow : Window
    {

        public string InstallDirStr = "C:\\Program Files\\Call of Duty HQ";

        public MainWindow()
        {
            InitializeComponent();
            InstallDir.Text = InstallDirStr;
        }

        private void Finish_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (RunOnClose.IsChecked == true)
            {
                Process.Start($"{InstallDirStr}\\Call of Duty Launcher.exe");
            }
            this.Close();
        }

        private void Cancel_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.Shutdown();
            }
        }

        private void Install_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            IntroPanel.IsVisible = false;
            InstallPanel.IsVisible = true;
        }

        private void Start_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            InstallPanel.IsVisible = false;
            StatusPanel.IsVisible = true;
            InstallFiles();
        }

        private void InstallFiles()
        {
            try
            {
                WebClient webClient = new WebClient();
                InstallProgressBar.IsIndeterminate = false;
                webClient.DownloadFileCompleted += Client_DownloadFileCompleted;
                webClient.DownloadProgressChanged += Client_DownloadProgressChanged;
                webClient.DownloadFileAsync(new Uri("https://github.com/PYSX-Physix/Call-of-Duty-HQ/releases/latest/download/Call.of.Duty.Launcher.zip"), "Call of Duty Launcher.zip");
            }
            catch (Exception ex)
            {
                StatusPanel.IsVisible = false;
                ErrorPanel.IsVisible = true;
                ErrorText.Text = $"{ex.Message}. Please close the installer and try again.";
            }
        }

        private void Client_DownloadFileCompleted(object? sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (!Directory.Exists(InstallDirStr))
            {
                Directory.CreateDirectory(InstallDirStr);
                ZipFile.ExtractToDirectory("Call of Duty Launcher.zip", InstallDirStr, true);
                File.Delete("Call of Duty Launcher.zip");
            }
            OutroPanel.IsVisible = true;
            StatusPanel.IsVisible = false;
            RegisterApp();
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            InstallProgressBar.Maximum = e.TotalBytesToReceive;
            InstallProgressBar.Value = e.BytesReceived;
        }

        public void RegisterApp()
        {
            //Sets up app name and information in Registry Editor
            string appName = "Call of Duty HQ";
            string appVersion = "1.0.0.0";
            string publisher = "Physix";
            string installLocation = $"{InstallDirStr}";
            string uninstallString = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\Call of Duty HQ\\uninstall.exe";

            //Gets the size of the program in KB
            long sizeInBytes = Directory.GetFiles(installLocation, "*", SearchOption.AllDirectories).Sum(file => new FileInfo(file).Length);
            long sizeInKB = sizeInBytes / 1024;

            //Adds the keys to a dedicated folder with name, version, publisher, locations, and program size
            RegistryKey key = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall\" + appName);
#pragma warning disable CA1416 // Validate platform compatibility
            key.SetValue("DisplayName", appName);
            key.SetValue("DisplayVersion", appVersion);
            key.SetValue("Publisher", publisher);
            key.SetValue("InstallLocation", installLocation);
            key.SetValue("UninstallString", uninstallString);
            key.SetValue("NoModify", 1, RegistryValueKind.DWord);
            key.SetValue("EstimatedSize", sizeInKB, RegistryValueKind.DWord);
            key.Close();

#pragma warning restore CA1416 // Validate platform compatibility
        }
    }
}