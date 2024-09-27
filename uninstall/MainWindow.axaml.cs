using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Microsoft.Win32;
using System.IO;

namespace uninstall
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.Shutdown();
            }
        }

        private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            string installLocation = Directory.GetCurrentDirectory();
            string appName = "Call of Duty HQ";

            // Delete files and directories
            if (Directory.Exists(installLocation))
            {
                Directory.Delete(installLocation, true);
            }

            // Remove registry entries
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall", true);
            if (key != null)
            {
                key.DeleteSubKeyTree(appName, false);
            }
        }
    }
}