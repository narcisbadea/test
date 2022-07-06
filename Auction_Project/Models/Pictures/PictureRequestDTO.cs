namespace Auction_Project.Models.Pictures
{
    public class PictureRequestDTO
    {
        public IFormFile? Image { get; set; }

        public string? Description { get; set; }
    }
}
