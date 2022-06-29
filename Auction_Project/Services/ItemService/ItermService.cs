using Auction_Project.DataBase;
using Auction_Project.Models.Items;
using Microsoft.EntityFrameworkCore;

namespace Auction_Project.Services.ItemService;

public class ItemsServices
{ 
    private readonly AppDbContext _context;
    private readonly IRepository<Item> _context2;

    public ItemsServices(AppDbContext context, IRepository<Item> context2)
    {
        _context = context;
        _context2 = context2;
    }

    public async Task<Item> Delete(int id) 
    {
        // delete
        return await _context2.Delete(id);
    }

    public async Task<Item>GetById(int id)
    {
        return await _context2.GetById(id);
    }

}

