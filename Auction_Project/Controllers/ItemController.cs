using Microsoft.AspNetCore.Mvc;
using Auction_Project.Services.ItemService;
using Auction_Project.Models.Items;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Auction_Project.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {

        private readonly ItemsServices _itemServices;

        public ItemsController(ItemsServices itemServices)
        {
            _itemServices = itemServices;
        }


        // GET: api/<ItemsController>
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<ItemResponse>>> Get()
        {
            var items = await _bidServices.Get();
            if (bids.Count == 0)
                return NotFound("List is empty");
            return Ok(bids);
        }*/

       
       
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemResponse>> GetById(int id)
        {
            var item = await _itemServices.GetById(id);

            if (item != null)
                return Ok(new ItemResponse());
            return NotFound("Item not found");
        }

        // POST api/<BidsController>
        [HttpPost]
        public async Task<ActionResult<Item>> Post(Item item)
        {
            if (await _itemServices.Post(item)!=null)
                return Ok(item);
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Item m_Item, int id)
        {
            var status = await _itemServices.Update(m_Item);
           
            return Ok();
        }

        // DELETE api/<BidsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _itemServices.GetById(id);
            if (item != null)
            {
                await _itemServices.Delete(id);
                return Ok("Item removed");
            }
            return NotFound("Item not found");
        }
    }
}
