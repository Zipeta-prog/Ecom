using Microsoft.EntityFrameworkCore;
using Stripe.Climate;

namespace Orders.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Order> Orders { get; set; }
    }
}
