using Auction_Project.DataBase;
using Auction_Project.Models.Bids;
using AutoMapper;
using Microsoft.EntityFrameworkCore;



namespace Auction_Project.Services.BidService;

public class BidServices
{
    private readonly IRepository<Bid> _repository;
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public BidServices(IRepository<Bid> repository ,AppDbContext context, IMapper mapper)
    {
        _repository = repository;
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<BidResponseDTO>> Get()
      {
        var result = await _context.Bids
              .Include(b => b.User)
              .Include(b => b.Item)
              .ToListAsync();

          var response=new List<BidResponseDTO>();

          foreach (var item in result)
          {
              response.Add(_mapper.Map<BidResponseDTO>(item));
          }
          return response;
      }

  /*  public async Task<List<BidResponseUser>> GetUser()
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
    }*/
    
    public async Task<BidResponseDTO> GetById(int id)
    {
        var BidList = await _context.Bids
            .Include(b => b.User)
            .Include(b => b.Item)
            .ToListAsync();
        var result = BidList.Find(r => r.Id == id);
        return _mapper.Map<BidResponseDTO>(result);
    }

    public async Task<Bid> Delete(int id)
    {
        return await _repository.Delete(id);
    }

    public async Task<bool> Post(BidRequestDTO toPost)
    {
        /*var user = await _context.Users.FindAsync(toPost.ID_User);
        var item = await _context.Items.FindAsync(toPost.ID_Item);
        if (item != null && user != null)
        {
            var bid = new Bid
            {
                User = user,
                Item = item,
                bidTime = DateTime.UtcNow,
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
        }*/
        return false;
    }

    public async Task<bool> Update(BidRequestDTO bid, int id)
    {
        /*ar ToReplace = await _context.Bids
            .Include(b=>b.User)
            .Include(b=>b.Item)
            .FirstOrDefaultAsync(b=>b.Id==id);
        if (ToReplace != null)
        {
            var user = await _context.Users.FindAsync(bid.IdNextUser);
            if (user != null)
            {
                ToReplace.User = user;
                ToReplace.bidTime = DateTime.UtcNow;
                ToReplace.CurrentPrice = bid.Price;
                await _context.SaveChangesAsync();
                return true;
            }
        }*/
        return false;
    }
}