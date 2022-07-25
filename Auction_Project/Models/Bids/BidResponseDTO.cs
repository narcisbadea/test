using Auction_Project.Models.Items;
using Auction_Project.Models.Users;

namespace Auction_Project.Models.Bids
{
    public class BidResponseDTO
    {
        public ItemResponseDTO ItemResponse { get; set; } 
        public UserResponseDTO UserResponse { get; set; }

        public decimal BidPrice { get; set; }
    }
}
