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

        public string Installdir = Program.Configuration["InstallPath"];
        public string UninstallDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public MainWindow()
        {
            InitializeComponent();
            InstallDir.Text = Installdir;
        }

        private void Finish_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (RunOnClose.IsChecked == true)
            {
                Process.Start($"{Installdir}Call of Duty HQ.exe");
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
                webClient.DownloadFileAsync(new Uri("https://api.onedrive.com/v1.0/shares/s!AqHJOX3p8RnQo5tkymKIaEENISXEjg/root/content"), "Call of Duty HQ.zip");
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
            if (!Directory.Exists(Installdir))
            {
                Directory.CreateDirectory(Installdir);
                ZipFile.ExtractToDirectory("Call of Duty HQ.zip", Installdir, true);
                File.Delete("Call of Duty HQ.zip");
            }
            OutroPanel.IsVisible = true;
            StatusPanel.IsVisible = false;
            RegisterApp();
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            InstallProgressBar.Maximum = e.TotalBytesToReceive;
            InstallProgressBar.Value = e.ProgressPercentage;
        }

        public void RegisterApp()
        {
            string appName = "Call of Duty HQ Avalonia Version";
            string appVersion = "1.0.0.0";
            string publisher = "Physix";
            string installLocation = $"{Installdir}";
            string uninstallString = UninstallDir + @"\uninstall.exe";

            long sizeInBytes = Directory.GetFiles(installLocation, "*", SearchOption.AllDirectories).Sum(file => new FileInfo(file).Length);
            long sizeInKB = sizeInBytes / 1024;

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