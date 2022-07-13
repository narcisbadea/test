using Auction_Project.Models.Pictures;

namespace Auction_Project.Models.Items
{
    public class ItemOwnItemDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsSold { get; set; } = false;

        public string? Desc { get; set; }

        public decimal? Price { get; set; }

        public double? EndTime { get; set; }

        public DateTime? postedTime { get; set; }

        public List<Picture>? Gallery { get; set; } = null;
    }
}
