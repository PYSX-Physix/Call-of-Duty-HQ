using Call_of_Duty_HQ.Activation;
using Call_of_Duty_HQ.Contracts.Services;
using Call_of_Duty_HQ.Core.Contracts.Services;
using Call_of_Duty_HQ.Core.Services;
using Call_of_Duty_HQ.Helpers;
using Call_of_Duty_HQ.Models;
using Call_of_Duty_HQ.Services;
using Call_of_Duty_HQ.ViewModels;
using Call_of_Duty_HQ.Views;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;

namespace Call_of_Duty_HQ;

// To learn more about WinUI 3, see https://docs.microsoft.com/windows/apps/winui/winui3/.
public partial class App : Application
{
    // The .NET Generic Host provides dependency injection, configuration, logging, and other services.
    // https://docs.microsoft.com/dotnet/core/extensions/generic-host
    // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
    // https://docs.microsoft.com/dotnet/core/extensions/configuration
    // https://docs.microsoft.com/dotnet/core/extensions/logging
    public IHost Host
    {
        get;
    }

    public static T GetService<T>()
        where T : class
    {
        if ((App.Current as App)!.Host.Services.GetService(typeof(T)) is not T service)
        {
            throw new ArgumentException($"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.");
        }

        return service;
    }

    public static WindowEx MainWindow { get; } = new MainWindow();

    public static UIElement? AppTitlebar { get; set; }

    public App()
    {
        InitializeComponent();

        Host = Microsoft.Extensions.Hosting.Host.
        CreateDefaultBuilder().
        UseContentRoot(AppContext.BaseDirectory).
        ConfigureServices((context, services) =>
        {
            // Default Activation Handler
            services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

            // Other Activation Handlers

            // Services
            services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
            services.AddSingleton<ILocalSettingsService, LocalSettingsService>();
            services.AddTransient<INavigationViewService, NavigationViewService>();

            services.AddSingleton<IActivationService, ActivationService>();
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<INavigationService, NavigationService>();

            // Core Services
            services.AddSingleton<ISampleDataService, SampleDataService>();
            services.AddSingleton<IFileService, FileService>();

            // Views and ViewModels
            services.AddTransient<MWRViewModel>();
            services.AddTransient<MWRPage>();
            services.AddTransient<HelpViewModel>();
            services.AddTransient<HelpPage>();
            services.AddTransient<AboutViewModel>();
            services.AddTransient<AboutPage>();
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<SettingsPage>();
            services.AddTransient<BO6ViewModel>();
            services.AddTransient<BO6Page>();
            services.AddTransient<CoDViewModel>();
            services.AddTransient<CoDPage>();
            services.AddTransient<CoD2ViewModel>();
            services.AddTransient<CoD2Page>();
            services.AddTransient<CoD3ViewModel>();
            services.AddTransient<CoD3Page>();
            services.AddTransient<CoD4MWViewModel>();
            services.AddTransient<CoD4MWPage>();
            services.AddTransient<WaWViewModel>();
            services.AddTransient<WaWPage>();
            services.AddTransient<MW2ViewModel>();
            services.AddTransient<MW2Page>();
            services.AddTransient<BOViewModel>();
            services.AddTransient<BOPage>();
            services.AddTransient<MW3ViewModel>();
            services.AddTransient<MW3Page>();
            services.AddTransient<BO2ViewModel>();
            services.AddTransient<BO2Page>();
            services.AddTransient<GhostsViewModel>();
            services.AddTransient<GhostsPage>();
            services.AddTransient<AWViewModel>();
            services.AddTransient<AWPage>();
            services.AddTransient<BO3ViewModel>();
            services.AddTransient<BO3Page>();
            services.AddTransient<IWViewModel>();
            services.AddTransient<IWPage>();
            services.AddTransient<WWIIViewModel>();
            services.AddTransient<WWIIPage>();
            services.AddTransient<MW2019ViewModel>();
            services.AddTransient<MW2019Page>();
            services.AddTransient<VanguardViewModel>();
            services.AddTransient<VanguardPage>();
            services.AddTransient<MWIIViewModel>();
            services.AddTransient<MWIIPage>();
            services.AddTransient<MWIIIViewModel>();
            services.AddTransient<MWIIIPage>();
            services.AddTransient<BOCWViewModel>();
            services.AddTransient<BOCWPage>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<MainPage>();
            services.AddTransient<ShellPage>();
            services.AddTransient<ShellViewModel>();

            // Configuration
            services.Configure<LocalSettingsOptions>(context.Configuration.GetSection(nameof(LocalSettingsOptions)));
        }).
        Build();

        UnhandledException += App_UnhandledException;
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        Exception ex = e.Exception;
        throw ex;
    }

    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);

        await App.GetService<IActivationService>().ActivateAsync(args);
    }
}
