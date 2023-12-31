using Auth.Models;
using Auth.Services.IService;

namespace Auth.Services
{
    public class JwtServices : IJwt
    {
        public string GenerateToken(Buyers buyer, IEnumerable<string> Roles)
        {
            throw new NotImplementedException();
        }
    }
}
