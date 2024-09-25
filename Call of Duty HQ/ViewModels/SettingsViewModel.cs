using System.Reflection;
using System.Windows.Input;
using Windows.ApplicationModel;
using Call_of_Duty_HQ.Contracts.Services;
using Call_of_Duty_HQ.Helpers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;

namespace Call_of_Duty_HQ.ViewModels;

public partial class SettingsViewModel : ObservableRecipient
{
    private readonly IThemeSelectorService _themeSelectorService;

    [ObservableProperty]
    private ElementTheme _elementTheme;


    public ICommand SwitchThemeCommand
    {
        get;
    }

    public SettingsViewModel(IThemeSelectorService themeSelectorService)
    {
        _themeSelectorService = themeSelectorService;
        _elementTheme = _themeSelectorService.Theme;

        SwitchThemeCommand = new RelayCommand<ElementTheme>(
            async (param) =>
            {
                if (ElementTheme != param)
                {
                    ElementTheme = param;
                    await _themeSelectorService.SetThemeAsync(param);
                }
            });
    }

    
}
