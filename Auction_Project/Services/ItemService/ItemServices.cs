using Auction_Project.DataBase;
using Auction_Project.Models.Items;
using Auction_Project.Services.BidService;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace Auction_Project.Services.ItemService;

public class ItemsServices
{
    private readonly AppDbContext _context;
    private readonly IRepository<Item> _repository;
    private readonly BidServices _bidService;
    private readonly IMapper _mapper;

    public ItemsServices(AppDbContext context, IRepository<Item> repository, IMapper mapper)
    {
        _context = context;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ItemResponseDTO>> Get()
    {
        var result = await _context.Items.ToListAsync();

        var response = new List<ItemResponseDTO>();
        foreach (var item in result)
        {
            response.Add(_mapper.Map<ItemResponseDTO>(item));
        }
        return response;
    }

    public async Task<ItemResponseDTO> GetById(int id)
    {
        return _mapper.Map<ItemResponseDTO>(await _repository.GetById(id));
    }

    public async Task<ItemResponseDTO> Post(ItemRequestDTO item)
    {
        var itemMapped = _mapper.Map<Item>(item);

        return _mapper.Map<ItemResponseDTO>(await _repository.Post(itemMapped));
    }

    public async Task<ItemResponseDTO> Update(ItemRequestForUpdateDTO item)
    {
        var itemMapped = _mapper.Map<Item>(item);

        return _mapper.Map<ItemResponseDTO>(await _repository.Update(itemMapped));
    }
    public async Task<Item> UpdateSold(bool soldStatus, int id)
    {
        /*var Sold = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
        if (Sold!= null)
        {
            Sold.IsSold= soldStatus;
            await _context.SaveChangesAsync();
            return Sold;
        }*/
        return null;
    }
}

