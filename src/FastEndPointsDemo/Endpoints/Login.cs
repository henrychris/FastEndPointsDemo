using FastEndpoints;
using FastEndPointsDemo.Endpoints.RequestModels;
using FastEndPointsDemo.Endpoints.ResponseModels;
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

// validators dont need to be registered, FastEndpoint auto searches the assembly
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