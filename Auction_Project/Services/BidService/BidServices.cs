using Auction_Project.DAL;
using Auction_Project.DataBase;
using Auction_Project.Models.Bids;
using Auction_Project.Models.Items;
using Auction_Project.Models.Users;
using Auction_Project.Services.UserService;
using AutoMapper;



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

          foreach (var bid in result)
          {
            var itemResponse = _mapper.Map<ItemResponseDTO>(bid.Item);
            var userResponse = _mapper.Map<UserResponseDTO>(bid.User);
            var bidPrice = bid.BidPrice;

            response.Add(new BidResponseDTO
             {
                  ItemResponse = itemResponse,
                  UserResponse = userResponse,
                  BidPrice = bidPrice
             });
          }
          return response;
      }
    
    public async Task<BidResponseDTO> GetById(int id)
    {
        var bid = await _repositoryBids.GetOne(id);

        var itemResponse = _mapper.Map<ItemResponseDTO>(bid.Item);
        var userResponse = _mapper.Map<UserResponseDTO>(bid.User);
        var bidPrice = bid.BidPrice;

        var result = new BidResponseDTO
        {
            ItemResponse = itemResponse,
            UserResponse = userResponse,
            BidPrice = bidPrice
        };

        return result;
    }

    public async Task<Bid> Delete(int id)
    {
        return await _repository.Delete(id);
    }

    public async Task<bool> Post(BidRequestDTO toPost)
    {
        var item = await _repositoryItem.GetById(toPost.ItemId);
        var currentUser = await _userServices.GetMe();
        if (item != null)
        {
            if (item.IsSold != true)
            {
            var bid = new Bid()
            {
                Item = item,
                User = currentUser,
                BidPrice = toPost.BidPrice,
                bidTime = DateTime.UtcNow

            }; 

            var BidsOnItem = await _repositoryBids.GetForOneItem(toPost.ItemId);
            if (BidsOnItem.Count != 0)
            {
                var x = BidsOnItem.OrderBy(b => b.BidPrice).Last().BidPrice;
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
            }
        }
        return false;
    }

}