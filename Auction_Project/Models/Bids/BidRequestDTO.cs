using Auction_Project.Models.Items;

namespace Auction_Project.Models.Bids
{
    public class BidRequestDTO
    {

        public Item? Item { get; set; }

        public decimal BidPrice { get; set; }
    }

}
