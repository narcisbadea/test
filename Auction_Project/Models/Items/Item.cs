using Auction_Project.Models.Base;
using Auction_Project.Models.Users;

namespace Auction_Project.Models.Items
{
    public class Item 
    {

        public bool IsSold { get; set; } = false;

        public bool Available { get; set; } = false;

        public string? Desc { get; set; }

        public decimal? Price { get; set; }
        public User winningBid { get; set; }
        public DateTime? endTime { get; set; }
        public DateTime? postedTime { get; set; }

        public List<Picture>? Gallery { get; set; }
    }
}
