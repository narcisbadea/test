using Auction_Project.Models.Items;
using Auction_Project.Models.Users;

namespace Auction_Project.Models.Bids;

public class BidResponseUser
{
    public ItemResponse ItemResponse { get; set; }

    //public int BidId { get; set; }


    public BidResponseUser(Bid bid)
    {
        ItemResponse = new ItemResponse
        {
            Desc = bid.Item.Desc,
            Price = bid.CurrentPrice,
            ImagesAddress = bid.Item.ImagesAddress
        };
        // BidId = bid.Id;
    }
}

