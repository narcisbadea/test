using Auction_Project.Models.Items;
using Auction_Project.Services.ItemService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    //[Authorize]
    public async Task<ActionResult<IEnumerable<ItemResponseForClientDTO>>> Get()
    {
        if(await _itemService.GetUser()!= null)
            return Ok(await _itemService.GetUser());
        return NotFound("No items in list.");
        //trebuie sa vada pretul curent daca s-a biduit pe item
    }

    [HttpGet("{id}")]
    //[Authorize]
    public async Task<ActionResult<IEnumerable<ItemResponseDTO>>> GetById(int id)
    {
        if (await _itemService.GetById(id) != null)
            return Ok(await _itemService.GetById(id));
        return NotFound("Item not found.");
    }

    [HttpPost]
    //[Authorize]
    public async Task<ActionResult<ItemRequestDTO>> Post(ItemRequestDTO toPost)
    {
        var item = _itemService.PostClient(toPost);
        if(item != null)
            return Ok(item);
        return BadRequest();
    }

    [HttpPut]
    //[Authorize]
    public async Task<ActionResult<ItemRequestDTO>> Update(ItemRequestForUpdateDTO toUpdate)
    {
        var item = await _itemService.Update(toUpdate);
        if (item != null)
            return Ok(item);
        return BadRequest();
    }


}
