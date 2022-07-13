using Auction_Project.Models.Items;
using Auction_Project.Services.BidService;
using Auction_Project.Services.ItemService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Auction_Project.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientItemController : ControllerBase
{
    private readonly ItemsServices _itemService;
    private readonly IBidCloseServices _bidCloseServices;

    public ClientItemController(ItemsServices itemService, IBidCloseServices bidCloseServices)
    {
        _itemService = itemService;
        _bidCloseServices = bidCloseServices;
    }


    [HttpGet("my-items")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<ItemResponseDTO>>> GetOwnItems()
    {
        var ownItem = await _itemService.GetOwnItemsForUser();

        if (ownItem != null)
            return Ok(ownItem);
        return NotFound("No items in list.");
    }
    [HttpGet("item-state")]
    [Authorize]
    public async Task<ActionResult<string>> GetItemState(int itemId)
    {
        var itemState = await _itemService.GetItemState(itemId);
        if (itemState != null)
        {
            return Ok(itemState.ToString());
        }
        return NotFound();

    }
    [HttpGet("get-all")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<ItemResponseForClientDTO>>> Get()
    {
        var got = await _itemService.GetUser();
        if (got!=null)
            return Ok(got);
        return NotFound("No items in list.");
    }

    [HttpGet("get-item-by-page/{nr}")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<ItemResponseForClientDTO>>> Get(int nr)
    {
        var got = await _itemService.GetUserByPage(nr);
        if (got != null)
            return Ok(got);
        return NotFound("There is no items.");
        //trebuie sa vada pretul curent daca s-a biduit pe item
    }

    [HttpGet("get-item-by-id/{id}")]
    [Authorize]
    public async Task<ActionResult<ItemResponseForClientDTO>> GetById(int id)
    {
        var got = await _itemService.GetByIdForUser(id);
        if (got != null)
            return Ok(got);
        return NotFound("Item not found.");
    }

    [HttpPost("add-item")]
    [Authorize]
    public async Task<ActionResult<ItemRequestDTO>> Post(ItemRequestDTO toPost)
    {
        var item = await _itemService.PostClient(toPost);
        if(item)
            return Ok(item);
        return BadRequest("Can't add item!");
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult> Sell(int id)
    {
        var item = await _bidCloseServices.SetAsSoldByUser(id);
        if(item != null)
            return Ok("Item Sold");
        return NotFound("Item not found");
    }


}
