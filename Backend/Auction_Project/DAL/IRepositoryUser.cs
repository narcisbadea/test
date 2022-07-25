using Auction_Project.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace Auction_Project.DAL
{
    public interface IRepositoryUser
    {
        List<User> GetUsers();

        User? GetById(string id);

        Task<User> GetByName(string UserName);

        Task<IList<string>> GetRoles(User user);

        Task<User> BanUser(User user);
    }
}
