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

    public async Task<Item>GetById(int id)
    {
        return await _repository.GetById(id);
    }
     
    public async Task<Item> Post(Item m_item)
    {
       
         return await _repository.Post(m_item);
        
    }
    public async Task<Item> Update(Item m_item)
    {

        return await _repository.Update(m_item);

    }
}

