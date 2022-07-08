namespace Auction_Project.Models.Users
{
    public class UserResponseDTO
    {

        public string Id { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IList<string> userRoles { get; set; }

    }
}
