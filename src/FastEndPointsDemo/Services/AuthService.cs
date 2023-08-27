using FastEndpoints;
using FastEndPointsDemo.Data;
using FastEndPointsDemo.Data.Entities;
using FastEndPointsDemo.Endpoints.RequestModels;
using FastEndPointsDemo.Endpoints.ResponseModels;
using FastEndPointsDemo.Interfaces;
using FastEndPointsDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace FastEndPointsDemo.Services;

public class AuthService : IAuthService
{
    private readonly DataContext _context;
    private readonly IPasswordHashService _hashService;
    private readonly ITokenService _tokenService;
    private readonly AutoMapper.IMapper _mapper;
    private readonly IUtilityService _utilityService;
    private readonly IPasswordHashService _passwordHasher;

    public AuthService(DataContext context, IPasswordHashService hashService, ITokenService tokenService,
        AutoMapper.IMapper mapper, IUtilityService utilityService, IPasswordHashService passwordHasher)
    {
        _context = context;
        _hashService = hashService;
        _tokenService = tokenService;
        _mapper = mapper;
        _utilityService = utilityService;
        _passwordHasher = passwordHasher;
    }

    public async Task<ServiceResponse<LoginResponse>> Login(LoginRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.EmailAddress == request.Email);
        if (user == null)
        {
            return ReturnedServiceResponse<LoginResponse>.ErrorResponse("User not found.", null);
        }

        var isPasswordValid = _hashService.VerifyPassword(request.Password, user.PasswordHash);
        if (!isPasswordValid)
        {
            return ReturnedServiceResponse<LoginResponse>.ErrorResponse("Email or password is incorrect.", null);
        }

        if (user.Status == Status.Blacklisted.ToString())
        {
            return ReturnedServiceResponse<LoginResponse>.ErrorResponse("User is blacklisted.", null);
        }

        var accessToken = _tokenService.CreateAccessToken(user.Id, user.FirstName, user.EmailAddress, user.Role);
        var response = _mapper.Map<LoginResponse>(user);
        response.AccessToken = accessToken;
        return ReturnedServiceResponse<LoginResponse>.SuccessResponse(response);
    }

    public async Task<ServiceResponse<RegisterResponse>> Register(RegisterRequest request)
    {
        var user = _mapper.Map<User>(request);
        user.PhoneNumber = _utilityService.FormatPhoneNumber(request.PhoneNumber);

        var doesUserWithPhoneNumberExist = await _context.Users.AnyAsync(x => x.PhoneNumber == user.PhoneNumber);
        if (doesUserWithPhoneNumberExist)
        {
            return ReturnedServiceResponse<RegisterResponse>.ErrorResponse(
                "User with this phone number already exists!", null);
        }

        var doesUserWithEmailExist = await _context.Users.AnyAsync(x => x.EmailAddress == user.EmailAddress);
        if (doesUserWithEmailExist)
        {
            return ReturnedServiceResponse<RegisterResponse>.ErrorResponse(
                "User with this email already exists!", null);
        }

        var business = _context.Find<Business>(request.BusinessCode);
        user.ReferralCode = business == null ? Constants.DefaultReferralCode : business.Code;

        user.PasswordHash = _passwordHasher.HashPassword(request.Password);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        var response = _mapper.Map<RegisterResponse>(user);
        response.AccessToken = _tokenService.CreateAccessToken(user.Id, user.FirstName, user.EmailAddress, user.Role);

        return ReturnedServiceResponse<RegisterResponse>.SuccessResponse(response);
    }
}