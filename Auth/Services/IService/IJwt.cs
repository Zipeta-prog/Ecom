using Auth.Models;

namespace Auth.Services.IService
{
    public interface IJwt
    {
        string GenerateToken(Buyers buyer, IEnumerable<string> Roles);
    }
}
