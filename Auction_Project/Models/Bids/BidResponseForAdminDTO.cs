namespace Auction_Project.Models.Bids;

public class BidResponseForAdminDTO
{

    public string? UserNameForBid { get; set; }
    public string? UserEmailForBid { get; set; }

    public int ItemIdForBid { get; set; }
    public bool ItemIsSold { get; set; }

    public decimal? Price { get; set; }

}
