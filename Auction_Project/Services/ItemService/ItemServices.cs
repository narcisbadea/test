using Auction_Project.DataBase;
using Auction_Project.Models.Items;
using Auction_Project.Services.BidService;
using Microsoft.EntityFrameworkCore;

namespace Auction_Project.Services.ItemService;

public class ItemsServices
{
    private readonly AppDbContext _context;
    private readonly IRepository<Item> _repository;
    private readonly BidServices _bidService;

    public ItemsServices(AppDbContext context, IRepository<Item> repository)
    {
        _context = context;
        _repository = repository;
    }

  

    public async Task<Item> GetById(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task<Item> Post(ItemRequestDTO item)
    {
        return await _repository.Post(new Item());
    }

    public async Task<Item> Update(ItemRequestDTO item, int id)
    {
        var ToReplace = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
        if (ToReplace != null)
        {
           /* //ToReplace { item.IsSold,item.Available,item.Desc,item.Price,item.ImagesAddress};
            ToReplace.Desc = item.Desc;
            ToReplace.Price = item.Price;
            ToReplace.IsSold = item.IsSold;
            ToReplace.Available = item.Available;
            ToReplace.ImagesAddress = item.ImagesAddress;
            ToReplace.Updated = DateTime.UtcNow;
            await _context.SaveChangesAsync();*/
            return ToReplace;
        }
        return null;
    }
    public async Task<Item> UpdateSold(bool soldStatus, int id)
    {
        var Sold = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
        if (Sold!= null)
        {
            Sold.IsSold= soldStatus;
            await _context.SaveChangesAsync();
            return Sold;
        }
        return null;
    }
}

