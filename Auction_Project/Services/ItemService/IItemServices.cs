using Auction_Project.Models.Items;

namespace Auction_Project.Services.ItemService
{
    public interface IItemServices
    {
        Task<Item> Disable(int id);
        Task<IEnumerable<ItemResponseForAdminDTO>> GetAdmin();
        Task<IEnumerable<ItemResponseForAdminDTO>> GetAdminByPage(int nr);
        Task<IEnumerable<ItemResponseDTO>> GetAdminByPageUnapproved(int nr);
        Task<ItemResponseDTO> GetById(int id);
        Task<ItemResponseForClientDTO> GetByIdForUser(int id);
        Task<IEnumerable<ItemResponseDTO>> GetUnapprovedForAdmin();
        Task<IEnumerable<ItemResponseForClientDTO>> GetUser();
        Task<IEnumerable<ItemResponseForClientDTO>> GetUserByPage(int nr);
        Task<bool> PostAdmin(ItemRequestDTO item);
        Task<bool> PostClient(ItemRequestDTO item);
        Task<bool> Update(ItemRequestForUpdateDTO item);
        Task<Item> UpdateSold(int id);
    }
}