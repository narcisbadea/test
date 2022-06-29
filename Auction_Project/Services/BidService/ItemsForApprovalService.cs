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

    public async Task<List<ItemsForApproval>> Get()
    {
        return null;
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

    public async Task<bool> Post(BidRequest toPost)
    {
        var user = await _context.Users.FindAsync(toPost.ID_User);
        var item = await _context.Items.FindAsync(toPost.ID_Item);
        if (item != null && user != null)
        {
            var bid = new Bid
            {
                User = user,
                Item = item,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                CurrentPrice = toPost.CurrentPrice
            };
            var lastPrice = await _context.Bids
                .Include(b => b.Item)
                .Where(b => b.Item.Id == item.Id)
                .ToListAsync();
            if (lastPrice.Count != 0)
            {
                var x = lastPrice.OrderBy(b => b.CurrentPrice).Last().CurrentPrice;
                if (x < bid.CurrentPrice)
                {
                    await _context.Bids.AddAsync(bid);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            else
            {
                if (item.Price <= bid.CurrentPrice)
                {
                    await _context.Bids.AddAsync(bid);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
        }
        return false;
    }
}
