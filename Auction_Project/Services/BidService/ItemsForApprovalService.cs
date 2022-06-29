using Auction_Project.DataBase;
using Auction_Project.Models.Bids;
using Microsoft.EntityFrameworkCore;


namespace Auction_Project.Services.BidService;

public class ItemsForApprovalService
{
    private readonly IRepository<ItemsForApproval> _context2;
    private readonly AppDbContext _context;

    public ItemsForApprovalService(IRepository<ItemsForApproval> context2, AppDbContext context)
    {
        _context2 = context2;
        _context = context;
    }

    public async Task<IEnumerable<ItemsForApproval>> Get()
    {
        return await _context2.Get();
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
        return await _context2.Delete(id);
    }

    public async Task<bool> Post(ItemsForApproval toPost)
    {
        await _context2.Post(toPost);
        return true;
    }
}
