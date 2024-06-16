using Call_of_Duty_HQ.Core.Models;

namespace Call_of_Duty_HQ.Core.Contracts.Services;

// Remove this class once your pages/features are using your data.
public interface ISampleDataService
{
    Task<IEnumerable<SampleOrder>> GetListDetailsDataAsync();
}
