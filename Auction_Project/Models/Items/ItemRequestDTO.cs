using Auction_Project.Models.Pictures;

namespace Auction_Project.Models.Items;

public class ItemRequestDTO
{
    public string? Desc { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public List<int>? GalleryIds { get; set; }

    public DateTime? EndTime { get; set; }

}


