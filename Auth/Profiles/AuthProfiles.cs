using Auth.Models;
using Auth.Models.Dtos;
using AutoMapper;

namespace Auth.Profiles
{
    public class AuthProfiles:Profile
    {
        public AuthProfiles()
        {
            CreateMap<RegisterUserDto, Buyers>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(r => r.Email));

            CreateMap<UserDto, Buyers>().ReverseMap();
        }
    }
}
