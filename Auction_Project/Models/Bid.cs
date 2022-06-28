namespace Auction_Project.Models
{
    public class Bid:Entity
    {
   
        public User User { get; set; }

        public Item Item { get; set; }

        public decimal CurrentPrice { get; set; }

    }
}
//david