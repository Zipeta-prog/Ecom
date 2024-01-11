using Auth.Models.Dtos;
using Auth.Models;
using AutoMapper;

namespace Auth.Profiles
{
    public class AuthProfiles:Profile
    {
        public AuthProfiles()
        {
            CreateMap<RegisterUserDto, ApplicationUser>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(r => r.Email));

            CreateMap<UserDto, ApplicationUser>().ReverseMap();
        }
    }
}
