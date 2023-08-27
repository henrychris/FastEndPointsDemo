namespace FastEndPointsDemo.Interfaces;

public interface ITokenService
{
    public string CreateAccessToken(string userId, string firstName, string emailAddress, string role);
}