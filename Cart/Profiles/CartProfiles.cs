using AutoMapper;
using Cart.Models;
using Cart.Models.Dtos;

namespace Cart.Profiles
{
    public class CartProfiles:Profile
    {
        public CartProfiles()
        {

            CreateMap<AddCartDto, Carts>().ReverseMap();
        }
    }
}
