using Auction_Project.Models.Base;
using Auction_Project.Models.Items;
using Auction_Project.Models.Users;

namespace Auction_Project.Models.Bids
{
    public class Bid : Entity
    {
        public User? IdUser { get; set; }
        public Item? IdItem { get; set; }
        public decimal? BidPrice { get; set; }
        public DateTime DateTime { get; set; }

    }
}