using Microsoft.AspNetCore.Identity;

namespace Cargo.Application.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

