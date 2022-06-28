using Auction_Project.Models.Base;

namespace Auction_Project.Models.Items
{
    public class Item : Entity
    {

        public string? Desc { get; set; }

        public decimal? Price { get; set; }

        public string? ImagesAddress { get; set; }

    }

}
