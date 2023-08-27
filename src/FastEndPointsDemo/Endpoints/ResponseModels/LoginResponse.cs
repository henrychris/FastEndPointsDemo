namespace FastEndPointsDemo.Endpoints.ResponseModels;

public class LoginResponse
{
    /// <summary>
    /// 
    /// </summary>
    public string? Id { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string? FirstName { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string? LastName { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string? UserName { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string EmailAddress { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string? PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string? Status { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string RoleCode { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string ReferralCode { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string UserReferralCode { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string? CountryCode { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public bool IsPinSet { get; set; } = false;

    /// <summary>
    /// 
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string TokenType { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public DateTime ExpiresIn { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string RefreshToken { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public bool IsEmailConfirmed { get; set; } = false;

    /// <summary>
    /// 
    /// </summary>
    public bool IsPhoneNumberConfirmed { get; set; } = false;

    /// <summary>
    /// 
    /// </summary>
    public string Lga { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string State { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public bool IsDefaultPassword { get; set; } = false;
}
