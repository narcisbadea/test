using Auction_Project.Models.Base;

namespace Auction_Project.Models.Bid
{
    public class Bid : Entity
    {

        public User User { get; set; }

        public Item Item { get; set; }

        public decimal CurrentPrice { get; set; }

    }
}
//david