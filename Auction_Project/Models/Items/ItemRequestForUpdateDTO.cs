using Auction_Project.Models.Pictures;

namespace Auction_Project.Models.Items
{
    public class ItemRequestForUpdateDTO
    {
        public int Id { get; set; }
        public string? Desc { get; set; }

        public string? Name { get; set; }

        public decimal? Price { get; set; }

        public List<PictureRequestDTO>? Gallery { get; set; }
    }
}
