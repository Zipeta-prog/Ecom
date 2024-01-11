using Auth.Models;

namespace Auth.Services.IService
{
    public interface IJwt
    {
        string GenerateToken(ApplicationUser user, IEnumerable<string> Roles);
    }
}
