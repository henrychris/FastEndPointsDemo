using FastEndPointsDemo.Models;

namespace FastEndPointsDemo;

public class AuthService : IAuthService
{
    public Task<User> Login()
    {
        return Task.FromResult(new User
        {
            Id = "user-id",
            FirstName = "Henry",
            LastName = "Ihenacho",
            Email = "henry@errandpay.com",
            Status = "Active",
            PhoneNumber = "08060601234",
            UserName = "henryIhenacho"
        });
    }
}