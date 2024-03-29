﻿using Coupon.Models;

namespace Coupon.Services.IService
{
    public interface ICoupon
    {
        Task<List<Coupons>> GetAllCoupons();
        Task<Coupons> GetCoupon(Guid Id);
        Task<Coupons> GetCoupon(string code);
        Task<string> AddCoupon(Coupons coupon);
        Task<string> UpdateCoupon();
        Task<string> DeleteCoupon(Coupons coupon);
    }
}
