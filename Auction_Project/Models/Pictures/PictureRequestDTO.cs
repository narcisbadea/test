namespace Auction_Project.Models.Pictures
{
    public class PictureRequestDTO
    {
        public int ItemId { get; set; }
        public IFormFile? Image { get; set; }

        public string? Description { get; set; }
    }
}
