using Auction_Project.Models.Base;
using Auction_Project.Models.Users;

namespace Auction_Project.Models.BannedUsers
{
    public class BannedUser : Entity
    {
        public User User { get; set; }
        public User Admin { get; set; }
    }
}
