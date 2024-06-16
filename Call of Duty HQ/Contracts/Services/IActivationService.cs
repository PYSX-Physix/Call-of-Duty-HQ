namespace Call_of_Duty_HQ.Contracts.Services;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs);
}
