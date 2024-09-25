using System.Reflection;
using Windows.ApplicationModel;
using Call_of_Duty_HQ.Helpers;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Call_of_Duty_HQ.ViewModels;

public partial class AboutViewModel : ObservableRecipient
{
    [ObservableProperty]
    private string _versionDescription;

    public AboutViewModel()
    {

        _versionDescription = GetVersionDescription();
    }

    private static string GetVersionDescription()
    {
        Version version;

        if (RuntimeHelper.IsMSIX)
        {
            var packageVersion = Package.Current.Id.Version;

            version = new(packageVersion.Major, packageVersion.Minor, packageVersion.Build, packageVersion.Revision);
        }
        else
        {
            version = Assembly.GetExecutingAssembly().GetName().Version!;
        }

        return $"{"AppDisplayName".GetLocalized()} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
    }
}
