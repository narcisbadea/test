using Auction_Project.Models.Items;

namespace Auction_Project.DAL
{
    public interface IRepositoryItem
    {
        public Task<List<Item>> Get();
        public Task<Item> GetById(int id);
    }
}
