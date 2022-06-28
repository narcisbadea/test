namespace Auction_Project.Models.Bid
{
    public class BidResponse
    {
        public ItemResponse ItemResponse { get; set; }
        public UserResponse UserResponse { get; set; }

        //public int BidId { get; set; }


        public BidResponse(Bid bid)
        {
            ItemResponse = new ItemResponse
            {
                Desc = bid.Item.Desc,
                Price = bid.CurrentPrice,
                ImagesAddress = bid.Item.ImagesAddress
            };
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
