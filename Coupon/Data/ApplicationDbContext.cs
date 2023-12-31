using Coupon.Models;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace Coupon.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Coupons> Coupon { get; set; }
    }
}
