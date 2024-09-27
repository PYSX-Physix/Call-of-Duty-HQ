using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace uninstall
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Uninstall()
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

            Console.WriteLine("Uninstallation complete.");
        }
    }
}