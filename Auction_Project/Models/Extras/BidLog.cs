using Auction_Project.Models.Base;
using Auction_Project.Models.Items;
using Auction_Project.Models.Users;

namespace Auction_Project.Models.Extras
{
    public class BidLog : Entity
    {
        public User User { get; set; }

        public Item Item { get; set; }

        public decimal CurrentPrice { get; set; }
    }
}
