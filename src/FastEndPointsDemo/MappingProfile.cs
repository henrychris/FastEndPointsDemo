using AutoMapper;
using FastEndPointsDemo.Data.Entities;
using FastEndPointsDemo.Endpoints.RequestModels;
using FastEndPointsDemo.Endpoints.ResponseModels;

namespace FastEndPointsDemo;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, LoginResponse>();
        CreateMap<RegisterRequest, User>()
            .ForMember(d => d.UserName, opt => opt.MapFrom(src => src.EmailAddress))
            .ForMember(d => d.EmailAddress, opt => opt.MapFrom(src => src.EmailAddress));
        CreateMap<User, RegisterResponse>();
    }
}