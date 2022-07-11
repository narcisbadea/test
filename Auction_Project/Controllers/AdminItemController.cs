using Microsoft.AspNetCore.Mvc;
using Auction_Project.Services.ItemService;
using Auction_Project.Models.Items;
using Microsoft.AspNetCore.Authorization;
using Auction_Project.Services.BidService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Auction_Project.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminItemsController : ControllerBase
    {

        private readonly ItemsServices _itemService;
        private readonly IBidCloseServices _bidCloseServices;


        public AdminItemsController(ItemsServices itemServices, IBidCloseServices bidCloseServices)
        {
            _itemService = itemServices;
            _bidCloseServices = bidCloseServices;
        }

        [HttpGet("/unlisteditems/{nr}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<ItemResponseDTO>>> Get(int nr)
        {
            var unlisted = await _itemService.GetAdminByPageUnapproved(nr);
            if (unlisted != null)
                return Ok(unlisted);
            return NotFound("No items in list.");
        }


        [HttpGet("/pageadmin/{nr}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<ItemResponseForAdminDTO>>> GetUnlisted(int nr)
        {
            var got = await _itemService.GetAdminByPage(nr);
            if (got != null)
                return Ok(got);
            return NotFound("No items in list.");
            //trebuie sa vada pretul curent daca s-a biduit pe item
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ItemResponseForAdminDTO>> GetById(int id)
        {
            var got = await _itemService.GetByIdForUser(id);
            if (got != null)
                return Ok(got);
            return NotFound("Item not found.");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ItemResponseDTO>> Post(ItemRequestDTO toPost)
        {
            var item = await _itemService.PostAdmin(toPost);
  
            if (item)
                return Ok(item);
            return BadRequest("Error input data!");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Update(int id)
        { 
           var updated = await _bidCloseServices.SetApproved(id);
           if(updated != null)
               return Ok(updated);
            return BadRequest("Not successful approved!");
        }

        // DELETE 
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Disable(int id)
        {
            var item = await _itemService.GetById(id);
            if (item != null)
            {
                await _itemService.Disable(id);
                return Ok("Item set as unavailable");
            }
            return NotFound("Item not found");
        }

        [HttpDelete("/soldforadmin/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Sell(int id)
        {
            var item = await _bidCloseServices.SetAsSoldByAdmin(id);
            if (item != null)
                return Ok("Item sold");
            return NotFound("Item not found");
        }
    }
}