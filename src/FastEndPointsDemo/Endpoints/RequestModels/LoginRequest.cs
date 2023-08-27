namespace FastEndPointsDemo.Endpoints.RequestModels;

public class LoginRequest
{
    /// <summary>
    /// UserName can be either PhoneNumber or EmailAddress
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string Password { get; set; } = string.Empty;
}