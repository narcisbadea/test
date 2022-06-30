using Auction_Project.Models.Items;
using Auction_Project.Models.Users;

namespace Auction_Project.Models.Bids
{
    public class BidResponse
    {
        public ItemResponse ItemResponse { get; set; }
        public UserResponse UserResponse { get; set; }

        //public int BidId { get; set; }


        public BidResponse(Bid bid)
        {
            ItemResponse = new ItemResponse(bid.Item.Desc, bid.CurrentPrice, bid.Item.ImagesAddress);
            
            UserResponse = new UserResponse
            {
                UserName = bid.User.UserName,
                FirstName = bid.User.FirstName,
                LastName = bid.User.LastName,
                Email = bid.User.Email
            };
            // BidId = bid.Id;
        }
    }
}
