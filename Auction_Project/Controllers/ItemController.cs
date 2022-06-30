using Microsoft.AspNetCore.Mvc;
using Auction_Project.Services.ItemService;
using Auction_Project.Models.Items;
using Microsoft.AspNetCore.Authorization;
using Auction_Project.Services.UserService;
using Auction_Project.DataBase;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Auction_Project.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {

        private readonly IRepository<Item> _repository;
        private readonly ItemsServices _itemServices;
        private readonly IUserService _userServices;


        public ItemsController(IRepository<Item> repository, ItemsServices itemServices, IUserService userServices)
        {
            _repository = repository;
            _itemServices = itemServices;
            _userServices = userServices;
        }


        // GET 
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Get()
        {
            var role = _userServices.GetMyRole();

            if (role != null)
            {
                if (role == "Admin")
                {
                    var items = await _repository.Get();
                    if (items == null)
                        return NotFound("List is empty");
                    return Ok(items);
                }
                if (role == "User")
                {
                    var items = await _itemServices.Get();
                    if (items == null)
                        return NotFound("List is empty");
                    return Ok(items);
                }
            }
            return BadRequest();
        }

       
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ItemResponse>> GetById(int id)
        {
            var role = _userServices.GetMyRole();

            if (role != null)
            {
                if (role == "Admin")
                {
                    var item = await _repository.GetById(id);
                    if (item == null)
                        return NotFound("List is empty");
                    return Ok(item);
                }
                if (role == "User")
                {
                    var item = await _itemServices.GetById(id);
                    if (item == null)
                        return NotFound("List is empty");
                    return Ok(item);
                }
            }
            return BadRequest();
        }


        // POST >
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Item>> Post(Item item)
        {
            if (await _itemServices.Post(item)!=null)
                return Ok(item);
            return BadRequest();
        }



        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Item item, int id)
        {
            var status = await _itemServices.Update(item);
           
            return Ok();
        }

        // DELETE 
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