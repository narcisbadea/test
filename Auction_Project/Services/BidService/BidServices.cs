using Auction_Project.DataBase;
using Auction_Project.Models.Bids;
using Microsoft.EntityFrameworkCore;



namespace Auction_Project.Services.BidService;

public class BidServices
{
    private readonly IRepository<Bid> _context2;
    private readonly AppDbContext _context;

    public BidServices(IRepository<Bid> context2 ,AppDbContext context)
    {
        _context2 = context2;
        _context = context;
    }

    public async Task<List<BidResponse>> Get()
      {
          var result = await _context.Bids
              .Include(b => b.User)
              .Include(b => b.Item)
              .ToListAsync();
          var response=new List<BidResponse>();
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
          var response=new List<BidResponseUser>();
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

    public async Task<Bid> Delete(int id)
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
            var lastPrice= await _context.Bids
                .Include(b=>b.Item)
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
                if(item.Price <= bid.CurrentPrice)
                {
                    await _context.Bids.AddAsync(bid);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
        }
        return false;
    }

    public async Task<bool> Update(BidDTO bid, int id)
    {
        var ToReplace = await _context.Bids
            .Include(b=>b.User)
            .Include(b=>b.Item)
            .FirstOrDefaultAsync(b=>b.Id==id);
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