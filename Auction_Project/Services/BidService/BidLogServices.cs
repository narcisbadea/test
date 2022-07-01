using Auction_Project.DataBase;
using Auction_Project.Models.Bids;
using Auction_Project.Models.Extras;
using Microsoft.EntityFrameworkCore;



namespace Auction_Project.Services.BidService;

public class BidLogServices 
{
    private readonly IRepository<BidLog> _repository;
    private readonly AppDbContext _context;

    public BidLogServices(IRepository<BidLog> repository, AppDbContext context)
    {
        _repository = repository;
        _context = context;
    }

    public async Task<List<BidResponse>> Get()
    {
        var result = await _context.BidLogs
            .Include(b => b.User)
            .Include(b => b.Item)
            .ToListAsync();
        var response = new List<BidResponse>();
        foreach (var item in result)
        {
            response.Add(new BidResponse(item));
        }
        return response;
    }

    public async Task<List<BidResponseUser>> GetUser()
    {
        var result = await _context.Bids
            .Include(b => b.Item)
            .ToListAsync();
        var response = new List<BidResponseUser>();
        foreach (var item in result)
        {
            response.Add(new BidResponseUser(item));
        }
        return response;
    }

    public async Task<Bid> GetById(int id)
    {
        var BidList = await _context.Bids
            .Include(b => b.User)
            .Include(b => b.Item)
            .ToListAsync();
        var result = BidList.Find(r => r.Id == id);
        return result;
    }

    public async Task<BidLog> Delete(int id)
    {
        return await _repository.Delete(id);
    }

    public async Task<bool> Post(Bid toPost)
    {
        
        var temp = _context.Bids.FirstOrDefault(i=>i.Id==toPost.Id);
        if (temp != null)
        {   
            _context.BidLogs.AddAsync(new BidLog(temp));
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> Update(BidDTO bid, int id)
    {
        var ToReplace = await _context.Bids
            .Include(b => b.User)
            .Include(b => b.Item)
            .FirstOrDefaultAsync(b => b.Id == id);
        if (ToReplace != null)
        {
            var user = await _context.Users.FindAsync(bid.IdNextUser);
            if (user != null)
            {
                ToReplace.User = user;
                ToReplace.Updated = DateTime.UtcNow;
                ToReplace.CurrentPrice = bid.Price;
                await _context.SaveChangesAsync();
                return true;
            }
        }
        return false;
    }
}