using Auction_Project.Models.Items;

namespace Auction_Project.Models.Bids
{
    public class BidRequestDTO
    {

        public int ItemId { get; set; }

        public decimal BidPrice { get; set; }
    }

}
