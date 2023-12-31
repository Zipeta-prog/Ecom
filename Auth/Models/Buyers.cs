using Microsoft.AspNetCore.Identity;

namespace Auth.Models
{
    public class Buyers:IdentityUser
    {
        public string Name { get; set; } = string.Empty;
    }
}
