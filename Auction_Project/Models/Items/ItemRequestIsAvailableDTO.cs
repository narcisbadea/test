namespace Auction_Project.Models.Items
{
    public class ItemRequestAvailableDTO
    {
        public bool Available { get; set; } = false;
        public DateTime? postedTime { get; set; }
    }
}
