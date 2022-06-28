using Auction_Project.Models.Base;

namespace Auction_Project.Models.Users
{
    public class User : Entity
    {

        public bool IsAdmin { get; set; } = false;

        public string UserName { get; set; }

        public byte[] Password { get; set; }

        public byte[] PwSalt { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Cnp { get; set; }

    }

}
