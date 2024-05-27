using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Entities
{
    public class User : IdentityUser
    {
        // Possibly add new fields

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}
