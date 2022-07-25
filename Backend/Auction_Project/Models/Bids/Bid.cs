
using Auction_Project.Models.Base;
using Auction_Project.Models.Items;
using Auction_Project.Models.Users;

namespace Auction_Project.Models.Bids
{
    public class Bid: IModel
    {
        public int Id { get; set; }

        public User? User { get; set; }

        public Item? Item { get; set; }

        public decimal BidPrice { get; set; }

        public DateTime bidTime { get; set; } = DateTime.UtcNow;

    }
}