using FastEndPointsDemo.Interfaces;
using FastEndPointsDemo.Models;

namespace FastEndPointsDemo.Services;

public class UtilityService : IUtilityService
{
    public ServiceResponse<bool> ValidatePassword(string password)
    {
        // could do password validation in the endpoint?
        throw new NotImplementedException();
    }

    public string FormatPhoneNumber(string phoneNumber)
    {
        var tenDigitPhoneNumber = phoneNumber.Substring(phoneNumber.Length - 10, 10);
        return $"234{tenDigitPhoneNumber}";
    }
}