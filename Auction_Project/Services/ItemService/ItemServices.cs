using Auction_Project.DAL;
using Auction_Project.DataBase;
using Auction_Project.Models.Bids;
using Auction_Project.Models.Items;
using Auction_Project.Models.Users;
using Auction_Project.Services.BidService;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace Auction_Project.Services.ItemService;

public class ItemsServices
{
    private readonly AppDbContext _context;
    private readonly IRepository<Item> _repositoryItems;
    private readonly IRepositoryBids _repositoryBids;
    private readonly BidServices _bidService;
    private readonly IMapper _mapper;

    public ItemsServices(AppDbContext context, IRepository<Item> repository, IMapper mapper, BidServices bidService, IRepositoryBids repositoryBids)
    {
        _context = context;
        _repositoryItems = repository;
        _mapper = mapper;
        _bidService = bidService;
        _repositoryBids = repositoryBids;
    }

    public async Task<IEnumerable<ItemResponseDTO>> Get()
    {
        var result = await _repositoryItems.Get();

        var response = new List<ItemResponseDTO>();
        foreach (var item in result)
        {
            response.Add(_mapper.Map<ItemResponseDTO>(item));
        }
        return response;
    }

    public async Task<IEnumerable<ItemResponseForClientDTO>> GetUser()
    {
        var items = await _repositoryItems.Get();
        var bids = await _repositoryBids.Get();

        var response = new List<ItemResponseForClientDTO>();

        foreach (var item in items)
        {
            var lastBid =bids.Where(i => i.Item.Id == item.Id).Last();
            var itemResponse = _mapper.Map<ItemResponseDTO>(lastBid.Item);
            var userResponse = _mapper.Map<UserResponseDTO>(lastBid.User);
            var res = new BidResponseDTO
            {
                ItemResponse = itemResponse,
                UserResponse = userResponse,
                BidPrice = lastBid.BidPrice
            };

            response.Add(new ItemResponseForClientDTO
            {
                ItemResponse = _mapper.Map<ItemResponseDTO>(item),
                BidResponseList = res
            });
        }
        return response;
    }

    public async Task<ItemResponseDTO> GetById(int id)
    {
        return _mapper.Map<ItemResponseDTO>(await _repositoryItems.GetById(id));
    }

    public async Task<ItemResponseDTO> PostAdmin(ItemRequestDTO item)
    {
        var itemMapped = _mapper.Map<Item>(item);

        return _mapper.Map<ItemResponseDTO>(await _repositoryItems.Post(itemMapped));
    }
    
    public async Task<ItemResponseDTO> PostClient(ItemRequestDTO item)
    {
        foreach(var gallryId in item.GalleryIds)
        {

        }

        return ;
    }

    public async Task<bool> Update(ItemRequestForUpdateDTO item)
    {
        var itemMapped = _mapper.Map<Item>(item);

        if(await _repositoryItems.Update(itemMapped)!=null)
            return true;
        return false;
    }
    public async Task<Item> UpdateSold(int id)
    {
        var Sold = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
        if (Sold!= null)
        {
            Sold.IsSold= true;
            await _context.SaveChangesAsync();
            return Sold;
        }
        return null;
    }
}

