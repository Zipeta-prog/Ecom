using Cart.Models.Dtos;

namespace Cart.Services.IService
{
    public interface ICoupon
    {
        Task<CouponDto> GetCouponByCouponCode(string couponCode);
    }
}
