using Auction_Project.Models.Items;

namespace Auction_Project.DAL
{
    public interface IRepositoryItem
    {
        Task<List<Item>> GetAll();
        Task<Item> GetById(int id);
        Task<Item> SetItem(Item item);
        Task<Item> UpdateItem(Item request);
    }
}