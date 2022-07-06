using Auction_Project.Models.Bids;

namespace Auction_Project.Models.Items
{
    public class ItemResponseForClientDTO
    {
        public ItemResponseDTO ItemResponse { get; set; }
        public BidResponseDTO BidResponseList { get; set; }
    
    }

}
