using Auction_Project.Models.Base;
using Auction_Project.Models.Bids;
using Auction_Project.Models.Pictures;
using Auction_Project.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace Auction_Project.Models.Items
{
    public class Item : IModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsSold { get; set; } = false;

        public bool IsAvailable { get; set; } = true;

        public string? Desc { get; set; }

        public decimal? Price { get; set; }

        public Bid? winningBid { get; set; } = null;

        public DateTime? endTime { get; set; }

        public DateTime? postedTime { get; set; }

        public List<Picture>? Gallery { get; set; }
    }
}
