using FastEndPointsDemo.Models;

namespace FastEndPointsDemo.Data.Entities;

public class User
{
    /// <summary>
    /// 
    /// </summary>
    public string Id { get; set; } = Guid.NewGuid().ToString();

    /// <summary>
    /// 
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string EmailAddress { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string Status { get; set; } = Models.Status.Active.ToString();

    /// <summary>
    /// The hash representation of a user's password
    /// </summary>
    public string PasswordHash { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;
    public string ReferralCode { get; set; } = string.Empty;
}