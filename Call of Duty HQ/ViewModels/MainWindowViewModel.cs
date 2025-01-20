using System;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SkiaSharp;

namespace Call_of_Duty_HQ.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty] private bool _isPaneClosed;

        [ObservableProperty]
        private ListItemTemplate? _selectedItem;


        public void SetActiveViewModel(Type viewModel)
        {
            
        }

        partial void OnSelectedItemChanged(ListItemTemplate? value)
        {
            if (value is null) return;
            var instance = Activator.CreateInstance(value.ModelType);
            if (instance is null) return;
            ActiveViewModel = (ViewModelBase)instance;
        }
        
        [RelayCommand]
        private void ClosePane()
        {
            IsPaneClosed = !IsPaneClosed;
        }
        
        [ObservableProperty]
        private ViewModelBase _activeViewModel= new MainViewModel();

        public ObservableCollection<ListItemTemplate> Items { get; } = new()
        {
            new ListItemTemplate(typeof(MainViewModel), "Home", "Home"),
            new ListItemTemplate(typeof(RoadmapViewModel), "Roadmap", "Calendar"),
            new ListItemTemplate(typeof(HelpViewModel), "Help", "Help"),
            new ListItemTemplate(typeof(SettingsViewModel), "Settings", "Settings"),
        };
    }

    public class ListItemTemplate
    {
        public ListItemTemplate(Type type, string name, string icon)
        {
            ModelType = type;
            Name = name;

            Application.Current.TryFindResource(icon, out var res);
            Icon = (StreamGeometry)res;
        }
        
        public string Name { get; }
        public Type ModelType { get; }
        public StreamGeometry Icon { get; }
    }
}
