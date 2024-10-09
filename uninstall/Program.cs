using System;
using System.IO;
using Microsoft.Win32;

namespace Uninstaller
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Remove application files
                string appPath = Directory.GetCurrentDirectory();
                if (Directory.Exists(appPath))
                {
                    Directory.Delete(appPath, true);
                    Console.WriteLine("Application files deleted.");
                }

                // Remove registry entries
                string registryPath = @"Software\YourCompany\YourApplication";
                RegistryKey key = Registry.CurrentUser.OpenSubKey(registryPath, true);
                if (key != null)
                {
                    Registry.CurrentUser.DeleteSubKeyTree(registryPath);
                    Console.WriteLine("Registry entries deleted.");
                }

                Console.WriteLine("Uninstallation completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during uninstallation: {ex.Message}");
            }
        }
    }
}

