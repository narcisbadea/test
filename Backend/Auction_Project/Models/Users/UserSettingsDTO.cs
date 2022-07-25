using Auction_Project.Models;

namespace Auction_Project.Models.Users
{
    public class UserSettingsDTO
    {

        public string UserName { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string Email { get; set; }

    }

}
