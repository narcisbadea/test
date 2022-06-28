namespace Auction_Project.Models
{
    public class BannedUser: Entity
    {
        public User User { get; set; }
        public User Admin { get; set; }
    }
}
