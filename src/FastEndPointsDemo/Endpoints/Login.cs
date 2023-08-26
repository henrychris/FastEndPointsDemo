using FastEndpoints;
using FastEndPointsDemo.Models;
using FluentValidation;

namespace FastEndPointsDemo.Endpoints;

public class Login : Endpoint<LoginRequest, LoginResponse, UserToLoginResponseMapper>
{
    private readonly IAuthService _authService;

    // inject any dependencies.
    public Login(IAuthService authService)
    {
        _authService = authService;
    }

    public override void Configure()
    {
        Post("/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        var result = await _authService.Login();
        await SendAsync(Map.FromEntity(result), cancellation: ct);
    }
}

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

public class LoginResponse
{
    /// <summary>
    /// 
    /// </summary>
    public string Id { get; set; } = string.Empty;

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
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;

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

public class UserToLoginResponseMapper : Mapper<LoginRequest, LoginResponse, User>
{
    // optional mapping setup.
    // we can also map the request to a domain model if we need to.
    // or use autoMapper, or whatever we decide.
    // public override User ToEntity(LoginRequest r)
    // {
    //     return base.ToEntity(r);
    // }

    public override LoginResponse FromEntity(User e) => new()
    {
        Id = e.Id,
        FirstName = e.FirstName,
        LastName = e.LastName,
        UserName = e.UserName,
        PhoneNumber = e.PhoneNumber,
        Status = e.Status
    };
}

// validators dont need to be registered
public class ThisValidator : Validator<LoginRequest>
{
    public ThisValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .EmailAddress().WithMessage("This isn't a valid email address.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("{PropertyName} is required.");
    }
}