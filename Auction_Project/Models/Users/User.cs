using Microsoft.AspNetCore.Identity;

namespace Auction_Project.Models.Users
{
    public class User : IdentityUser
    {
        public DateTime Created { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Cnp { get; set; } = string.Empty;

    }

}
