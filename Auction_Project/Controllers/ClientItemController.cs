using Auction_Project.Models.Items;
using Auction_Project.Services.ItemService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Auction_Project.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientItemController : ControllerBase
{
    private readonly ItemsServices _itemService;

    public ClientItemController(ItemsServices itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<ItemResponseForClientDTO>>> Get()
    {
        var got = await _itemService.GetUser();
        if (got!=null)
            return Ok(got);
        return NotFound("No items in list.");
        //trebuie sa vada pretul curent daca s-a biduit pe item
    }

    [HttpGet("/page/{nr}")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<ItemResponseForClientDTO>>> Get(int nr)
    {
        var got = await _itemService.GetUserByPage(nr);
        if (got != null)
            return Ok(got);
        return NotFound("No items in list.");
        //trebuie sa vada pretul curent daca s-a biduit pe item
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<ItemResponseForClientDTO>> GetById(int id)
    {
        var got = await _itemService.GetByIdForUser(id);
        if (got != null)
            return Ok(got);
        return NotFound("Item not found.");
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ItemRequestDTO>> Post(ItemRequestDTO toPost)
    {
        var item = await _itemService.PostClient(toPost);
        if (item != null)
            return Ok(item);
        return BadRequest();
    }

    [HttpPut]
    [Authorize]
    public async Task<ActionResult<ItemRequestDTO>> Update(ItemRequestForUpdateDTO toUpdate)
    {
        var item = await _itemService.Update(toUpdate);
        if (item != null)
            return Ok(item);
        return BadRequest();
    }


}
