using FastEndPointsDemo.Models;

namespace FastEndPointsDemo.Interfaces;

public interface IUtilityService
{
    /// <summary>
    /// Validate that a password passes strength requirements.
    /// </summary>
    /// <param name="password">The password to validate.</param>
    /// <returns></returns>
    ServiceResponse<bool> ValidatePassword(string password);

    /// <summary>
    /// Format a phone number to contain country code.
    /// </summary>
    /// <param name="phoneNumber"></param>
    /// <returns></returns>
    string FormatPhoneNumber(string phoneNumber);
}