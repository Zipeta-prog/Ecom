using Coupon.Models;
using Microsoft.EntityFrameworkCore;

namespace Coupon.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Coupons> Coupon { get; set; }
    }
}
