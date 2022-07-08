namespace Auction_Project.Models.Items
{
    public class ItemRequestAsSoldDTO
    {
        public bool IsSold { get; set; } = false;

        public bool IsAvailable { get; set; } = false;

        public int? winningBidId { get; set; } = null;

        public double? EndTime { get; set; }
    }
}
