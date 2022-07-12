using Auction_Project.Models.Bids;

namespace Auction_Project.Services.BidService
{
    public interface IBidServices
    {
        Task<Bid> Delete(int id);
        Task<List<BidResponseDTO>> Get();
        Task<BidResponseDTO> GetById(int id);
        Task<bool> Post(BidRequestDTO toPost);
    }
}