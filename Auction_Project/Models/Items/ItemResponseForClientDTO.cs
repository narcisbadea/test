using Auction_Project.Models.Bids;

namespace Auction_Project.Models.Items
{
    public class ItemResponseForClientDTO
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Desc { get; set; }

        public decimal? InitialPrice { get; set; }

        public double? EndTime { get; set; }

        public List<int>? Gallery { get; set; }

        public string? LastBidUserFirstName { get; set; }

        public decimal? LastBidPrice { get; set; }

        public DateTime postedTime { get; set;  }

    }

}
