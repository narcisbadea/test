using Auction_Project.Models.Base;
using Auction_Project.Models.Items;
using Auction_Project.Models.Users;

namespace Auction_Project.Models.Bids
{
    public class ItemsForApproval : Entity
    {
        public bool IsSold { get; set; } = false;

        public bool Available { get; set; } = false;

        public string? Desc { get; set; }

        public decimal? Price { get; set; }

        public string? ImagesAddress { get; set; }
    }

}