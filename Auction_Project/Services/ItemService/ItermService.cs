using Auction_Project.DataBase;
using Auction_Project.Models.Items;
using Microsoft.EntityFrameworkCore;

namespace Auction_Project.Services.ItemService;

public class ItemsServices
{ 
    private readonly AppDbContext _context;
    private readonly IRepository<Item> _repository;

    public ItemsServices(AppDbContext context, IRepository<Item> repository)
    {
        _context = context;
        _repository = repository;
    }

    public async Task<Item> Delete(int id) 
    {
        // delete
        return await _repository.Delete(id);
    }

    public async Task<IEnumerable<ItemResponse>> Get()
    {
        var result = await _context.Items.ToListAsync();
        
        var response = new List<ItemResponse>();
        foreach (var item in result)
        {
            response.Add(new ItemResponse(item));
        }
        return response;
    }

    public async Task<Item>GetById(int id)
    {
        return await _repository.GetById(id);
    }
     
    public async Task<Item> Post(Item item)
    {
        return await _repository.Post(item);
    }
    public async Task<Item> Update(Item item)
    {
        return await _repository.Update(item);

    }
}

