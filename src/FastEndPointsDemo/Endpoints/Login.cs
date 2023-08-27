using System.Net;
using FastEndpoints;
using FastEndPointsDemo.Data.Entities;
using FastEndPointsDemo.Endpoints.RequestModels;
using FastEndPointsDemo.Endpoints.ResponseModels;
using FastEndPointsDemo.Interfaces;
using FastEndPointsDemo.Models;
using FluentValidation;

namespace FastEndPointsDemo.Endpoints;

public class Login : Endpoint<LoginRequest, ApiResponse<LoginResponse>>
{
    private readonly IAuthService _authService;

    public Login(IAuthService authService)
    {
        _authService = authService;
    }

    public override void Configure()
    {
        Post("/auth/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        var result = await _authService.Login(req);
        if (result.IsSuccess)
        {
            await SendAsync(new ApiResponse<LoginResponse>(result.Data),
                cancellation: ct);
        }

        // we can create our own version of the send method if needed
        // await SendAsync(new ApiResponse<LoginResponse>(Map.FromEntity(result.Data)),
        //     (int)HttpStatusCode.BadRequest,
        //     ct);
        ThrowError(result.Error?.Message!);
    }
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