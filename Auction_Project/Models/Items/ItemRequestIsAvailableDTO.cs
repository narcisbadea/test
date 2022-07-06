namespace Auction_Project.Models.Items
{
    public class ItemRequestIsAvailableDTO
    {
        public bool IsAvailable { get; set; } = false;
        public DateTime? postedTime { get; set; }
    }
}
