using Auction_Project.Models.Bids;
using Auction_Project.Models.Users;

namespace Auction_Project.DAL
{
    public interface IRepositoryBids
    {
        Task<List<Bid>> Get();
        Task<List<Bid>> GetForOneItem(int id);

        Task<User> GetUserIdFromBid(int id);
        Task<Bid> GetOne(int id);   
    }
}
