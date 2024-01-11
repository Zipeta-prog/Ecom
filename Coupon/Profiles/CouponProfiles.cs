using AutoMapper;
using Coupon.Models.Dtos;
using Coupon.Models;

namespace Coupon.Profiles
{
    public class CouponProfiles
    {
        public class CouponProfile : Profile
        {
            public CouponProfile()
            {
                CreateMap<AddCouponDto, Coupons>().ReverseMap();
            }
        }
    }
}
