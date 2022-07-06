using Auction_Project.DAL;
using Auction_Project.DataBase;
using Auction_Project.Models.Bids;
using Auction_Project.Models.Items;
using Auction_Project.Models.Pictures;
using Auction_Project.Models.Users;
using Auction_Project.Services.BidService;
using Auction_Project.Services.PictureService;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace Auction_Project.Services.ItemService;

public class ItemsServices
{
    private readonly AppDbContext _context;
    private readonly IRepository<Item> _repositoryItems;
    private readonly IRepositoryItem _repositoryItemCustom;
    private readonly IRepositoryBids _repositoryBids;
    private readonly IRepositoryPictures _repositoryPictures;
    private readonly IMapper _mapper;

    public ItemsServices(AppDbContext context, IRepository<Item> repository, IMapper mapper, IRepositoryBids repositoryBids, IRepositoryPictures repositoryPictures, IRepositoryItem repositoryItemCustom)
    {
        _context = context;
        _repositoryItems = repository;
        _mapper = mapper;
        _repositoryBids = repositoryBids;
        _repositoryPictures = repositoryPictures;
        _repositoryItemCustom = repositoryItemCustom;
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
        var items = await _repositoryItemCustom.Get();
        var bids = await _repositoryBids.Get();

        var response = new List<ItemResponseForClientDTO>();

        foreach (var item in items)
        {
            var lastBid = bids.Where(i => i.Item.Id == item.Id).OrderBy(b => b.bidTime).LastOrDefault();
            if (lastBid != null)
            {
                var itemResponse = _mapper.Map<ItemResponseDTO>(lastBid.Item);
                var userResponse = _mapper.Map<UserResponseDTO>(lastBid.User);
                var res = new BidResponseDTO
                {
                    ItemResponse = itemResponse,
                    UserResponse = userResponse,
                    BidPrice = lastBid.BidPrice
                };

                var listGalleryIds = new List<int>();
                if (item.Gallery.Count > 0)
                {
                    foreach (var pic in item.Gallery)
                    {
                        listGalleryIds.Add(pic.Id);
                    }
                }
                else
                {
                    listGalleryIds.Add(-1);
                }

                response.Add(new ItemResponseForClientDTO
                {

                        Name = item.Name,

                        Desc = item.Desc,

                        InitialPrice = item.Price,

                        endTime = item.endTime,

                        Gallery = listGalleryIds,
                    
                        LastBidUserFirstName = res.UserResponse.FirstName,

                        LastBidPrice = res.BidPrice
                });
            }
            else
            {
                var listGalleryIds = new List<int>();
                if (item.Gallery.Count > 0)
                {
                    foreach (var pic in item.Gallery)
                    {
                        listGalleryIds.Add(pic.Id);
                    }
                }
                else
                {
                    listGalleryIds.Add(-1);
                }
                response.Add(new ItemResponseForClientDTO
                {

                    Name = item.Name,

                    Desc = item.Desc,

                    InitialPrice = item.Price,

                    endTime = item.endTime,

                    Gallery = listGalleryIds,

                    LastBidUserFirstName = "No bidder yet",

                    LastBidPrice = 0
                });
            }
        }
        return response;
    }
   
    public async Task<IEnumerable<ItemResponseForAdminDTO>> GetAdmin()
    {
        var items = await _repositoryItemCustom.Get();
        var bids = await _repositoryBids.Get();

        var response = new List<ItemResponseForAdminDTO>();

        foreach (var item in items)
        {
            var lastBid = bids.Where(i => i.Item.Id == item.Id).OrderBy(b => b.bidTime).LastOrDefault();
            if (lastBid != null)
            {
                var itemResponse = _mapper.Map<ItemResponseDTO>(lastBid.Item);
                var userResponse = _mapper.Map<UserResponseDTO>(lastBid.User);
                var res = new BidResponseDTO
                {
                    ItemResponse = itemResponse,
                    UserResponse = userResponse,
                    BidPrice = lastBid.BidPrice
                };

                var listGalleryIds = new List<int>();
                if (item.Gallery.Count > 0)
                {
                    foreach (var pic in item.Gallery)
                    {
                        listGalleryIds.Add(pic.Id);
                    }
                }
                else
                {
                    listGalleryIds.Add(-1);
                }

                response.Add(new ItemResponseForAdminDTO
                {

                        Name = item.Name,

                        Desc = item.Desc,

                        InitialPrice = item.Price,

                        endTime = item.endTime,

                        Gallery = listGalleryIds,
                    
                        BidsOnItem = bids.FindAll(bid=>bid.Item.Id==item.Id)
                });
            }
            else
            {
                var listGalleryIds = new List<int>();
                if (item.Gallery.Count > 0)
                {
                    foreach (var pic in item.Gallery)
                    {
                        listGalleryIds.Add(pic.Id);
                    }
                }
                else
                {
                    listGalleryIds.Add(-1);
                }
                response.Add(new ItemResponseForAdminDTO
                {

                    Name = item.Name,

                    Desc = item.Desc,

                    InitialPrice = item.Price,

                    endTime = item.endTime,

                    Gallery = listGalleryIds,

                    BidsOnItem = null
                });
            }
        }
        return response;
    }

    public async Task<IEnumerable<ItemResponseForClientDTO>> GetUserByPage(int nr)
    {
        var list = await GetUser();
        var maxPage = list.ToList().Count /  5;
        if (list.ToList().Count % 5 > 0)
        {
            maxPage++;
        }
        if (nr <= maxPage)
        {
            var result = list.ToList().GetRange(5 * nr - 5, 5 - ((nr * 5) - list.ToList().Count));
            return result;
        }
        else
        {
            return null;
        }
    }

    public async Task<IEnumerable<ItemResponseForAdminDTO>> GetAdminByPage(int nr)
    {
        var list = await GetAdmin();
        var maxPage = list.ToList().Count / 5;
        if(list.ToList().Count % 5 > 0)
        {
            maxPage++;
        }
        if (nr <= maxPage)
        {
            var result = list.ToList().GetRange(5 * nr - 5, 5 - ((nr * 5) - list.ToList().Count));
            return result;
        }
        else
        {
            return null;
        }
        
    }

    public async Task<ItemResponseForClientDTO> GetByIdForUser(int id)
    {
        var item = await _repositoryItemCustom.GetById(id);
        var bids = await _repositoryBids.Get();

        if (item != null)
        {
            var lastBid = bids.Where(i => i.Item.Id == item.Id).OrderBy(b => b.bidTime).LastOrDefault();
            if (lastBid != null)
            {
                var itemResponse = _mapper.Map<ItemResponseDTO>(lastBid.Item);
                var userResponse = _mapper.Map<UserResponseDTO>(lastBid.User);
                var res = new BidResponseDTO
                {
                    ItemResponse = itemResponse,
                    UserResponse = userResponse,
                    BidPrice = lastBid.BidPrice
                };
                var listGalleryIds = new List<int>();
                if (item.Gallery.Count > 0)
                {
                    foreach (var pic in item.Gallery)
                    {
                        listGalleryIds.Add(pic.Id);
                    }
                }
                else
                {
                    listGalleryIds.Add(-1);
                }
                var response = new ItemResponseForClientDTO
                {

                    Name = item.Name,

                    Desc = item.Desc,

                    InitialPrice = item.Price,

                    endTime = item.endTime,

                    Gallery = listGalleryIds,

                    LastBidUserFirstName = res.UserResponse.FirstName,

                    LastBidPrice = res.BidPrice
                };
                return response;
            }
            else
            {
                var listGalleryIds = new List<int>();
                if (item.Gallery.Count > 0)
                {
                    foreach (var pic in item.Gallery)
                    {
                        listGalleryIds.Add(pic.Id);
                    }
                }
                else
                {
                    listGalleryIds.Add(-1);
                }
                var response = new ItemResponseForClientDTO
                {

                    Name = item.Name,

                    Desc = item.Desc,

                    InitialPrice = item.Price,

                    endTime = item.endTime,

                    Gallery = listGalleryIds,

                    LastBidUserFirstName = "No bidder yet",

                    LastBidPrice = 0
                };
                return response;
            }
        }
        return null;
    }
    
    public async Task<ItemResponseDTO> GetById(int id)
    {
        return _mapper.Map<ItemResponseDTO>(await _repositoryItems.GetById(id));
    }

    public async Task<bool> PostClient(ItemRequestDTO item)
    {
        var picList = new List<Picture>();

        foreach (var gallryId in item.GalleryIds)
        {
            picList.Add(await _repositoryPictures.GetById(gallryId));
        }

        var toPost = new Item
        {

            Name = item.Name,

            IsSold = false,

            IsAvailable = false,

            Desc = item.Desc,

            Price = item.Price,

            winningBidId = null,

            endTime = item.EndTime,

            postedTime = DateTime.UtcNow,

            Gallery = picList
        };

        if (await _repositoryItems.Post(toPost) != null)
            return true;
        return false;
    }

    public async Task<bool> PostAdmin(ItemRequestDTO item)
    {
        var picList= new List<Picture>();

        foreach(var gallryId in item.GalleryIds)
        {
            picList.Add(await _repositoryPictures.GetById(gallryId));
        }

        var toPost = new Item
        {

            Name = item.Name,

            IsSold = false,

            IsAvailable = true,

            Desc = item.Desc,

            Price = item.Price,

            winningBidId = null,

            endTime = item.EndTime,

            postedTime = DateTime.UtcNow,

            Gallery = picList
        };

        if (await _repositoryItems.Post(toPost) != null)
            return true;
        return false;
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

    public async Task<Item> Disable(int id)
    {
        return await _repositoryItemCustom.Disable(id);
    }

}

