using Ganss.Excel;

namespace Auction_Project.Models.Bids;

public class BidResponseForAdminDTO
{
    [Column(1)]
    public string? UserNameForBid { get; set; }
    [Column(Letter = "B")]
    public string? UserEmailForBid { get; set; }
    [Ignore]
    public int ItemIdForBid { get; set; }
    [Column(Letter = "C")]
    public bool ItemIsSold { get; set; }
    [Column(Letter = "D")]
    public decimal? Price { get; set; }

}
