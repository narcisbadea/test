namespace Auction_Project.Models.Items
{
    public class ItemResponseForUpdateDTO
    {
        public int Id { get; set; }
        public string? Desc { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
    }
}
