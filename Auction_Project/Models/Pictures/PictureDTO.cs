using Microsoft.AspNetCore.Mvc;

namespace Auction_Project.Models.Pictures
{
    public class PictureDTO
    {
        public FileContentResult Image { get; set; }

        public string Description { get; set; }
    }
}
