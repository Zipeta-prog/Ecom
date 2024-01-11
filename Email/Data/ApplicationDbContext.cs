using Email.Models;
using Microsoft.EntityFrameworkCore;

namespace Email.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Emails> Email { get; set; }
    }
}
