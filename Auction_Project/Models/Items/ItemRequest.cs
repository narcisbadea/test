namespace Auction_Project.Models.Items;

public class ItemRequest
{
    public bool IsSold { get; set; } = false;

    public bool Available { get; set; } = false;

    public string? Desc { get; set; }

    public decimal? Price { get; set; }

    public string? ImagesAddress { get; set; }

}


