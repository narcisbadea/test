using Auction_Project.Models.Bids;

namespace Auction_Project.DAL
{
    public interface IRepositoryBids
    {
        public Task<List<Bid>> Get();
        public Task<Bid> GetOne(int id);   
    }
}
