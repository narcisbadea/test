namespace Auction_Project.Models.Bid
{
    public class BidRequest
    {
        public int ID_User { get; set; }

        public int ID_Item { get; set; }

        public decimal CurrentPrice { get; set; }
    }
}
