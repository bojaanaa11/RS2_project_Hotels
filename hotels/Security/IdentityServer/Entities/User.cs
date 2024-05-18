using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Entities
{
    public class User : IdentityUser
    {
        // Possibly add new fields

        public string FirstName { get; set; }

        public string LastName { get; set; }


    }
}
