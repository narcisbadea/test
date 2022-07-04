using Auction_Project.Models.Base;

namespace Auction_Project.Models.Users
{
    public class User : IModel
    {
        public int Id { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;

        public string UserName { get; set; }

        public byte[] Password { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Cnp { get; set; }

    }

}
