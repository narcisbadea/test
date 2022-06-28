using Auction_Project.Models.Base;

namespace Auction_Project.Models.Item
{
    public class Item : Entity
    {

        public string? Desc { get; set; }

        public decimal? Price { get; set; }

        public string? ImagesAddress { get; set; }

    }

}
