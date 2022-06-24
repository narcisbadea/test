namespace Auction_Project.Models
{
    public class Bid:Entity
    {
       
        public int Id_User { get; set; }

        public int Id_Item { get; set; }

        public decimal CurrentPrice { get; set; }

    }
}
//david