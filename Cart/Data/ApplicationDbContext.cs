using Cart.Models;
using Microsoft.EntityFrameworkCore;
namespace Cart.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Carts> Carts { get; set; }

    }
}
