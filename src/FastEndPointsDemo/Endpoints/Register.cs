using System.Text.RegularExpressions;
using FastEndpoints;
using FastEndPointsDemo.Endpoints.RequestModels;
using FastEndPointsDemo.Endpoints.ResponseModels;
using FastEndPointsDemo.Interfaces;
using FastEndPointsDemo.Models;
using FluentValidation;

namespace FastEndPointsDemo.Endpoints;

public class Register : Endpoint<RegisterRequest, ApiResponse<RegisterResponse>>
{
    private readonly IAuthService _authService;

    public Register(IAuthService authService)
    {
        _authService = authService;
    }

    public override void Configure()
    {
        Post("/auth/register");
        AllowAnonymous();
        AllowFileUploads();
    }

    public override async Task HandleAsync(RegisterRequest req, CancellationToken ct)
    {
        var result = await _authService.Register(req);
        if (result.IsSuccess)
        {
            await SendAsync(new ApiResponse<RegisterResponse>(result.Data),
                cancellation: ct);
        }
        else
        {
            ThrowError(result.Error?.Message!);
        }
    }
}

public class MyValidator : Validator<RegisterRequest>
{
    public MyValidator()
    {
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MinimumLength(10).WithMessage("Phone number is too short.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(50).WithMessage("{PropertyName} is too long.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(50).WithMessage("{PropertyName} is too long.");

        RuleFor(x => x.EmailAddress).NotEmpty().WithMessage("{PropertyName} is required").EmailAddress();

        RuleFor(x => x.Role).NotEmpty();
        RuleFor(x => x.BusinessCode).NotEmpty();


        var specialChar = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
        var upperCase = new Regex(@"[A-Z]+");
        var lowerCase = new Regex(@"[a-z]+");
        var number = new Regex(@"[0-9]+");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long")
            .Matches(specialChar).WithMessage("Password must contain at least one special character")
            .Matches(upperCase).WithMessage("Password must contain at least one uppercase letter")
            .Matches(lowerCase).WithMessage("Password must contain at least one lowercase letter")
            .Matches(number).WithMessage("Password must contain at least one number");
    }
}