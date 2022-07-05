using Auction_Project.DAL;
using Auction_Project.DataBase;
using Auction_Project.Models.Bids;
using Auction_Project.Models.Items;
using Auction_Project.Services.UserService;
using AutoMapper;
using Microsoft.EntityFrameworkCore;



namespace Auction_Project.Services.BidService;

public class BidServices
{
    private readonly IRepository<Bid> _repository;
    private readonly IRepository<Item> _repositoryItem;
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IRepositoryBids _repositoryBids;
    private readonly IUserService _userServices;

    public BidServices(IUserService userServices, IRepository<Bid> repository, IRepository<Item> repositoryItem ,AppDbContext context, IMapper mapper, IRepositoryBids repositoryBids)
    {
        _repository = repository;
        _context = context;
        _mapper = mapper;
        _repositoryBids = repositoryBids;
        _repositoryItem = repositoryItem;
        _userServices = userServices;
    }

    public async Task<List<BidResponseDTO>> Get()
      {
        var result = await _repositoryBids.Get();

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
        var item = await _repositoryItem.GetById(toPost.ItemId);
        //var currentUser = await _userServices.GetMe();
        if (item != null)
        {
            // if (item.endTime > DateTime.UtcNow)
            // {
            var bid = new Bid()
            {
                Item = item,
                //User = currentUser,
                BidPrice = toPost.BidPrice,
                bidTime = DateTime.UtcNow

            }; //BidRequestDTO

            var lastPrice = await _repositoryBids.Get();
            if (lastPrice.Count != 0)
            {
                var x = lastPrice.OrderBy(b => b.BidPrice).Last().BidPrice;
                if (x < bid.BidPrice)
                {
                    await _repository.Post(bid);
                    return true;
                }
            }
            else
            {
                if (item.Price <= bid.BidPrice)
                {
                    await _repository.Post(bid);
                    return true;
                }
            }
            //}
        }
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