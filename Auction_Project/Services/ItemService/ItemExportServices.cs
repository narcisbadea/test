
using Auction_Project.DAL;
using Auction_Project.Models.Bids;
using Auction_Project.Models.Items;
using AutoMapper;

namespace Auction_Project.Services.ItemService;

public class ItemExportServices
{

    private readonly ItemsServices _itemServices;
    private readonly IRepositoryItem _repositoryItemCustom;
    private readonly IRepositoryBids _repositoryBids;
    readonly IMapper _mapper;


    public ItemExportServices(ItemsServices itemServices,IRepositoryItem repositoryItem, IRepositoryBids repositoryBids, IMapper mapper)
    {
        _itemServices = itemServices;
        _repositoryItemCustom = repositoryItem;
        _repositoryBids = repositoryBids;
        _mapper = mapper;
    }

    public async Task<ItemResponseForAdminDTO> GetListOfBidsForItem(int id)
    {
        var item = await _repositoryItemCustom.GetById(id);

        var bids = await _repositoryBids.Get();

        var bidDTO = new List<BidResponseForAdminDTO>();

        foreach (var bid in bids)
        {
            var bidtemp = new BidResponseForAdminDTO
            {
                UserNameForBid = bid.User.UserName,
                UserEmailForBid = bid.User.Email,

                ItemIdForBid = bid.Item.Id,
                ItemIsSold = bid.Item.IsSold,

                Price = bid.BidPrice
            };
            if(bid.Item.Id == id)
                bidDTO.Add(bidtemp);
        }

        var response = new ItemResponseForAdminDTO
        {
            Id = id,
            Name = item.Name,
            Desc = item.Desc,
            InitialPrice = item.Price,
            EndTime = item.EndTime,
            BidsOnItem = bidDTO
        };

        return response;
    }
}

