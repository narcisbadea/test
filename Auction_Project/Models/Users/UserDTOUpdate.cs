using Auction_Project.Models;

namespace Auction_Project.Models.Users
{
    public class UserDTOUpdate
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cnp { get; set; }
        public bool isAdmin { get; set; }
    }
}
