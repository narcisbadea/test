using Auction_Project.Models.Base;

namespace Auction_Project.Models.BannedUser
{
    public class BannedUser : Entity
    {
        public User User { get; set; }
        public User Admin { get; set; }
    }
}
