using Auction_Project.Models.Items;

namespace Auction_Project.Services.BidService
{
    public interface IBidCloseServices
    {
        // Task<ItemRequestIsAvailableDTO> SetApproved(int idItem);
        Task<ItemRequestIsAvailableDTO> SetApproved(int idItem);
    }
}