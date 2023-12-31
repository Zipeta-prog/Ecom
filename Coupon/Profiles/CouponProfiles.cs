using AutoMapper;
using Coupon.Models;
using Coupon.Models.Dtos;

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
