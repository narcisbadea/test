using Auction_Project.Models.Items;

namespace Auction_Project.Services.BidService
{
    public interface IBidCloseServices
    {
        // Task<ItemRequestAvailableDTO> SetApproved(int idItem);
        Task<ItemRequestAvailableDTO> SetApproved(int idItem);
        Task SetAsSold(Item itemSearched);
        Task<Item> SetAsSoldByUser(int id);
    }
}