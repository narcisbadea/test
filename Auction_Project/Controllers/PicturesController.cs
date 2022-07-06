using Auction_Project.Models.Pictures;
using Auction_Project.Services.PictureService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auction_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private readonly IPictureService _pictureService;

        public PicturesController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PictureResponseDTO>> GetById(int id)
        {
            var response = await _pictureService.GetById(id);
            return Ok(response);
        }
        [HttpGet("show/{id}")]
        public async Task<ActionResult<IFormFile>> GetImageById(int id)
        {
            var response = await _pictureService.GetById(id);
            var stream = System.IO.File.ReadAllBytes(response.ImageAddress);
            var type = "image/" + response.ImageAddress.Split('.').Last();
            return File(stream, type);
        }

        [HttpPost]
        public async Task<ActionResult<PictureResponseDTO>> Post([FromForm] PictureRequestDTO pic)
        {
            var response = await _pictureService.PostPicture(pic);
            return Ok(response);
        }

        [HttpPost("list")]
        public async Task<ActionResult<List<PictureResponseDTO>>> PostPictures([FromForm] List<PictureRequestDTO> pics)
        {
            var response = await _pictureService.PostPictures(pics);
            return Ok(response);
        }
    }
}
