using Auction_Project.Models.BannedUsers;

namespace Auction_Project.Services.UserService
{
    public interface IAdminService
    {
        Task<BannedUser> AddBannedUser(int id, int adminId);
        Task<BannedUser> UnbanUser(int id, int adminId);
        Task<int> DeleteBannedUser(int id);
        Task<BannedUser> GetBannedUser(int id);
        Task<List<BannedUser>> GetBannedUsers();
        Task<int> GetUnbannedUser(int id);
    }
}