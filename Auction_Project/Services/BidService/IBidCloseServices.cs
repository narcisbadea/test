using Auction_Project.Models.Items;

namespace Auction_Project.Services.BidService
{
    public interface IBidCloseServices
    {
        /*    Task SetItemAsSold(int id);
            Task SetItemAvabilityToTrue(int id);*/
        Task<ItemRequestIsAvailableDTO> SetApproved(int id);
    }
}