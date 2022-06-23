namespace Auction_Project.Models
{
    public class Bids:Entity
    {
       
        public int Id_User { get; set; }

        public int Id_Item { get; set; }

        public decimal CurrentPrice { get; set; }

    }
}
