using Auction_Project.DataBase;
using Auction_Project.Models.Bids;
using Auction_Project.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Auction_Project.DAL;

public class RepositoryBids : IRepositoryBids
{

    private readonly AppDbContext _context;

    public RepositoryBids(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Bid>> Get()
    {
        return await _context.Bids.Include(b => b.Item).Include(u=>u.User).ToListAsync();
    }
    
    public async Task<User> GetUserIdFromBid(int idItem)
    {

        var bid = await _context.Bids
            .Include(i => i.Item)
            .Include(u => u.User)
            .Where(u => u.Item.Id == idItem)
            .OrderBy(b => b.bidTime)
            .LastOrDefaultAsync();

        if (bid == null)
            return null;
        return bid.User;


    }

    public async Task<Bid> GetOne(int id)
    {
        return await _context.Bids.Include(b => b.Item).Include(u => u.User).FirstOrDefaultAsync(res=>res.Id == id);
    }

    public async Task<List<Bid>> GetForOneItem(int id)
    {
        var BidList = await _context.Bids.Include(b => b.Item).Include(u => u.User).ToListAsync();
        var result = BidList.FindAll(b => b.Item.Id == id);

        return result;
    }
}
