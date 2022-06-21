namespace Auction_Project.Models
{
    public class Items : Entity
    {
        public int Id_Item;

        public string? Desc { get; set; }

        public decimal? Price { get; set; }

        public DateTime? Created { get; set; }
        
        public DateTime? Updated { get; set; }


    }
}
