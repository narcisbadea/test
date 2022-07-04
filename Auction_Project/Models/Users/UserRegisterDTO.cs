namespace Auction_Project.Models.Users
{
    public class UserRegisterDTO
    {

        public string UserName { get; set; }

        public string Password { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Cnp { get; set; }

    }
}
