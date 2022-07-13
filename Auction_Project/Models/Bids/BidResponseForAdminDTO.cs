using Ganss.Excel;

namespace Auction_Project.Models.Bids;

public class BidResponseForAdminDTO
{
    [Column(1)]
    public string? UserNameForBid { get; set; }
    [Column(Letter = "B")]
    public string? UserEmailForBid { get; set; }
    [Column(Letter = "C")]
    public int ItemIdForBid { get; set; }
    [Column(Letter = "D")]
    public bool ItemIsSold { get; set; }
    [Column(Letter = "E")]
    public decimal? Price { get; set; }

}
