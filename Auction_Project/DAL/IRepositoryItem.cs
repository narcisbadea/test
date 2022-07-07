using Auction_Project.Models.Items;

namespace Auction_Project.DAL
{
    public interface IRepositoryItem
    {
        Task<List<Item>> Get();
        Task<Item> GetById(int id);

        Task<Item> Enable(int id);

        Task<Item> Disable(int id);
        Task<Item> UpdateToSold(int id);
    }
}
