
using Auction_Project.DAL;
using Auction_Project.Models.Bids;
using Auction_Project.Models.Items;
using AutoMapper;
using Ganss.Excel;

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

    public async Task<IEnumerable<BidResponseForAdminDTO>> GetListOfBidsForItem(int id)
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

        return bidDTO;
    }

    public async Task<string> ExportToExcel(int id)
    {
        var bids = await GetListOfBidsForItem(id);

        string uploads = Path.Combine(Directory.GetCurrentDirectory(), "BidListExcel");
        System.IO.Directory.CreateDirectory(uploads);



        if (bids != null)
        {
            var hostItem = bids.OrderBy(b => b.Price).First().ItemIdForBid.ToString();
            string filePath = Path.Combine(uploads, hostItem);

            new ExcelMapper().Save(filePath + ".xlsx", bids, hostItem);

            return filePath;
        }

        return null;
    }


}

