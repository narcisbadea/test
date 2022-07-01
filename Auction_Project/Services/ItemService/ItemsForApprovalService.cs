using Auction_Project.DataBase;
using Auction_Project.Models.Items;
using Microsoft.EntityFrameworkCore;


namespace Auction_Project.Services.ItemService;

public class ItemsForApprovalService
{
    private readonly IRepository<ItemsForApproval> _repository;
    private readonly AppDbContext _context;

    public ItemsForApprovalService(IRepository<ItemsForApproval> repository, AppDbContext context)
    {
        _repository = repository;
        _context = context;
    }

    public async Task<IEnumerable<ItemsForApproval>> Get()
    {
        return await _repository.Get();
    }

    public async Task<ItemsForApproval> GetById(int id)
    {
        var BidList = await _context.ItemsForApproval
            .ToListAsync();
        var result = BidList.Find(r => r.Id == id);
        return result;
    }

    public async Task<ItemsForApproval> Delete(int id)
    {
        return await _repository.Delete(id);
    }

    public async Task<ItemsForApproval> Post(ItemsForApproval toPost)
    {
        return await _repository.Post(toPost);
    }

    public async Task<ItemsForApproval> Update(ItemsForApproval item)
    {
       return await _repository.Update(item);
    }

}
