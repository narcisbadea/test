using Auction_Project.DataBase;
using Auction_Project.Models;

namespace Auction_Project.Services;

public class BidServices
{
    private readonly AppDbContext _context;

    public BidServices(AppDbContext context)
    {
        _context = context;
    }

    public List<Bid> GetBid()
    {

        if (_context.Bids == null)
            return null;
        return _context.Bids.ToList();
    
    }


}


