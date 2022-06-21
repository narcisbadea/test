namespace Auction_Project.Models
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
