using Auction_Project.Models.Base;

namespace Auction_Project.Models.Items
{
    public class Item : Entity
    {

        public bool IsSold { get; set; } = false;

        public bool Available { get; set; } = false;

        public string? Desc { get; set; }

        public decimal? Price { get; set; }

        public string? ImagesAddress { get; set; }

        public Item()
        {

        }

        public Item(ItemRequest itemRequest)
        {
            IsSold = itemRequest.IsSold;
            Available = itemRequest.Available;
            Desc = itemRequest.Desc;
            Price = itemRequest.Price;
            ImagesAddress = itemRequest.ImagesAddress;
        }

        public Item(bool isSold, bool available, string? desc, decimal? price, string? imagesAddress)
        {
            IsSold = isSold;
            Available = available;
            Desc = desc;
            Price = price;
            ImagesAddress = imagesAddress;
        }
    }
}
