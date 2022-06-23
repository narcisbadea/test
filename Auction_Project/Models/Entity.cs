namespace Auction_Project.Models
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
        
        public DateTime? Created { get; set; }

        public DateTime? Updated { get; set; }
    }
}
