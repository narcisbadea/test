using Auction_Project.DataBase;
using Auction_Project.Models.Bids;
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

    public async Task<Bid> GetOne(int id)
    {
        return await _context.Bids.Include(b => b.Item).Include(u => u.User).FirstOrDefaultAsync(res=>res.Id == id);
    }

}
