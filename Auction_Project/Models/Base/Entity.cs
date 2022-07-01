namespace Auction_Project.Models.Base
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }

        public DateTime? Created { get; set; } = DateTime.UtcNow;

        public DateTime? Updated { get; set; } = DateTime.UtcNow;
    }
}
