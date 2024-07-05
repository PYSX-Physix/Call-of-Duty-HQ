using Call_of_Duty_HQ.Contracts.Services;
using Call_of_Duty_HQ.ViewModels;
using Call_of_Duty_HQ.Views;

using CommunityToolkit.Mvvm.ComponentModel;

using Microsoft.UI.Xaml.Controls;

namespace Call_of_Duty_HQ.Services;

public class PageService : IPageService
{
    private readonly Dictionary<string, Type> _pages = new();

    public PageService()
    {
        Configure<MainViewModel, MainPage>();
        Configure<BOCWViewModel, BOCWPage>();
        Configure<MWIIIViewModel, MWIIIPage>();
        Configure<MWIIViewModel, MWIIPage>();
        Configure<VanguardViewModel, VanguardPage>();
        Configure<MW2019ViewModel, MW2019Page>();
        Configure<BO4ViewModel, BO4Page>();
        Configure<WWIIViewModel, WWIIPage>();
        Configure<IWViewModel, IWPage>();
        Configure<BO3ViewModel, BO3Page>();
        Configure<AWViewModel, AWPage>();
        Configure<GhostsViewModel, GhostsPage>();
        Configure<BO2ViewModel, BO2Page>();
        Configure<MW3ViewModel, MW3Page>();
        Configure<BOViewModel, BOPage>();
        Configure<MW2ViewModel, MW2Page>();
        Configure<WaWViewModel, WaWPage>();
        Configure<CoD4MWViewModel, CoD4MWPage>();
        Configure<CoD3ViewModel, CoD3Page>();
        Configure<CoD2ViewModel, CoD2Page>();
        Configure<CoDViewModel, CoDPage>();
        Configure<BO6ViewModel, BO6Page>();
        Configure<SettingsViewModel, SettingsPage>();
        Configure<AboutViewModel, AboutPage>();
        Configure<HelpViewModel, HelpPage>();
    }

    public Type GetPageType(string key)
    {
        Type? pageType;
        lock (_pages)
        {
            if (!_pages.TryGetValue(key, out pageType))
            {
                    throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
            }
        }

        return pageType;
    }

    private void Configure<VM, V>()
        where VM : ObservableObject
        where V : Page
    {
        lock (_pages)
        {
            var key = typeof(VM).FullName!;
            if (_pages.ContainsKey(key))
            {
                throw new ArgumentException($"The key {key} is already configured in PageService");
            }

            var type = typeof(V);
            if (_pages.ContainsValue(type))
            {
                throw new ArgumentException($"This type is already configured with key {_pages.First(p => p.Value == type).Key}");
            }

            _pages.Add(key, type);
        }
    }
}
