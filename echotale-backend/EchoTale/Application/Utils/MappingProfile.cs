using Application.DTOs;
using AutoMapper;
using Domain.Common;
using Domain.Entities;

namespace Application.Utils;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterUserRequestDto, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.FirstName, opt => opt.Ignore())
            .ForMember(dest=> dest.LastName, opt => opt.Ignore())
            .ForMember(dest=> dest.PhoneNumber, opt => opt.Ignore())
            .ForMember(dest=>dest.Gender, opt => opt.Ignore())
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.LastUpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.UserType, opt => opt.MapFrom(_ => UserType.Regular))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            ;

        CreateMap<User, UserResponseDto>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ForMember(dest => dest.UserType, opt => opt.MapFrom(src => src.UserType));
    }
}  