using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PrinudnaNaplata.Models.Dto.Auth;
using PrinudnaNaplata.Models.Dtos.Auth;

namespace PrinudnaNaplata.Mappings
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<IdentityUser, LoginRequestDto>().ReverseMap();
            CreateMap<IdentityUser, LoginResponseDto>().ReverseMap();
            CreateMap<IdentityUser, ChangePasswordResponseDto>().ReverseMap();
            CreateMap<IdentityUser, ResetPasswordResponseDto>().ReverseMap();
        }
    }
}
