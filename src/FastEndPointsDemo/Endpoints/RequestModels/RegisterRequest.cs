namespace FastEndPointsDemo.Endpoints.RequestModels;

public class RegisterRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string Role { get; set; }
    public string BusinessCode { get; set; }
    public string Password { get; set; }
}