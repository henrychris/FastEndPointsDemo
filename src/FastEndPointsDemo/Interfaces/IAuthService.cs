using FastEndPointsDemo.Data.Entities;
using FastEndPointsDemo.Endpoints.RequestModels;
using FastEndPointsDemo.Endpoints.ResponseModels;
using FastEndPointsDemo.Models;

namespace FastEndPointsDemo.Interfaces;

public interface IAuthService
{
    public Task<ServiceResponse<LoginResponse>> Login(LoginRequest request);
    public Task<ServiceResponse<RegisterResponse>> Register(RegisterRequest request);
}