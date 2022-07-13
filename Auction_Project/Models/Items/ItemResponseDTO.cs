using Auction_Project.Models.Pictures;

namespace Auction_Project.Models.Items;

public class ItemResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Desc { get; set; }

    public decimal? Price { get; set; }

    public string? EndTime { get; set; }

    public DateTime? postedTime { get; set; }

    public List<int>? Gallery { get; set; }

}
