using Microsoft.EntityFrameworkCore;
using Products.Model;

namespace Products.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products{ get; set; }

        public DbSet<ProductPic> ProductPics { get; set; }
    }
}
