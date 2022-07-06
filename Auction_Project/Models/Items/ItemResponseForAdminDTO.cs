using Auction_Project.Models.Bids;

namespace Auction_Project.Models.Items
{
    public class ItemResponseForAdminDTO
    {
        public string Name { get; set; }
        public string? Desc { get; set; }

        public decimal? InitialPrice { get; set; }

        public DateTime? endTime { get; set; }

        public List<int>? Gallery { get; set; }

        public List<Bid>? BidsOnItem { get; set; }

    }
}
