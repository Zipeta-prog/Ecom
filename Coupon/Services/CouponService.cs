using Coupon.Data;
using Coupon.Models;
using Coupon.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace Coupon.Services
{
    public class CouponService : ICoupon
    {
        private readonly ApplicationDbContext _context;
        public CouponService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddCoupon(Coupons coupons)
        {
            _context.Coupon.Add(coupons);
            await _context.SaveChangesAsync();
            return "Coupon Added!!";
        }

        public async Task<string> DeleteCoupon(Coupons coupons)
        {
            _context.Coupon.Remove(coupons);
            await _context.SaveChangesAsync();
            return "Coupon Removed!!";
        }

        public async Task<List<Coupons>> GetAllCoupons()
        {
            return await _context.Coupon.ToListAsync();
        }

        public async Task<Coupons> GetCoupon(Guid Id)
        {
            return await _context.Coupon.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<Coupons> GetCoupon(string code)
        {
            return await _context.Coupon.Where(x => x.CouponCode == code).FirstOrDefaultAsync();
        }

        public async Task<string> UpdateCoupon()
        {
            await _context.SaveChangesAsync();
            return "Coupon Updated !!";
        }
    }
}
