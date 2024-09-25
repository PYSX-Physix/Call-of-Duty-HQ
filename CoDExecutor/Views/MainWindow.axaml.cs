using System;
using System.Diagnostics;
using Avalonia.Controls;

namespace CoDExecutor.Views
{
    public partial class MainWindow : Window
    {
        public string steamPath;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void StartCoD(int steamID)
        {
            Process.Start($"{steamPath}\\steam.exe", $"steam://rungameid/{steamID}");
        }
    }
}