using Auction_Project.Models.Pictures;

namespace Auction_Project.Models.Items;

public class ItemResponseDTO
{
    public string Name { get; set; }
    public string? Desc { get; set; }

    public decimal? Price { get; set; }

    public DateTime? endTime { get; set; }

    public DateTime? postedTime { get; set; }

    public List<PictureResponseDTO>? Gallery { get; set; }

}
