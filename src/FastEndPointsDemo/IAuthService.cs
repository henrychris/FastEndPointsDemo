using FastEndPointsDemo.Models;

namespace FastEndPointsDemo;

public interface IAuthService
{
    public Task<User> Login();
}