using Email.Data;
using Email.Models;
using Microsoft.EntityFrameworkCore;

namespace Email.Services
{
    public class EmailsService
    {
        private DbContextOptions<ApplicationDbContext> options;

        public EmailsService(DbContextOptions<ApplicationDbContext> options)
        {
            this.options = options;
        }

        public async Task addDatatoDatabase(Emails emails)
        {
            var _db = new ApplicationDbContext(options);
            _db.Email.Add(emails);
            await _db.SaveChangesAsync();
        }
    }
}
