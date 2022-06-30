namespace Auction_Project.Models.Items;

public class ItemResponse
{
    public string? Desc { get; set; }

    public decimal? Price { get; set; }

    public string? ImagesAddress { get; set; }

    public ItemResponse(Item item)
    {
        Desc = item.Desc;
        Price = item.Price;
        ImagesAddress = item.ImagesAddress;
    }
    public ItemResponse(string? desc, decimal? price, string? imagesAddress)
    {
        Desc = desc;
        Price = price;
        ImagesAddress = imagesAddress;
    }
}
