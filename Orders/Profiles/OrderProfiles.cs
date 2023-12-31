using AutoMapper;
using Orders.Models;
using Orders.Models.Dtos;

namespace Orders.Profiles
{
    public class OrderProfiles:Profile
    {
        public OrderProfiles()
        {

            CreateMap<AddOrderDto, Order>().ReverseMap();
        }
    }
}
