using Auction_Project.Models.Base;
using Auction_Project.Models.Users;

namespace Auction_Project.Models.Items
{
    public class Item
    {

        public int Id { get; set; };
        public string Name { get; set; };
        public string? Description { get; set; }
        public decimal? StartingPrice { get; set; }
        public bool IsActivate { get; set; }
        public bool IsSold { get; set; }
        public User WinningBid { get; set;}
        public DateTime? EndingDate { get; set; }
        public DateTime? PostedTime { get; set; }
        public Picture Gallery { get; set; }
}
