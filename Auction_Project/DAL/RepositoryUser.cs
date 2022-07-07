using Auction_Project.DataBase;
using Auction_Project.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace Auction_Project.DAL
{
    public class RepositoryUser : IRepositoryUser
    {
        private readonly UserManager<User> _userManager;


        public RepositoryUser( UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public User? GetById(string id)
        {
            return _userManager.Users.FirstOrDefault(u => u.Id == id);
        }

        public async Task<User> GetByName(string UserName)
        {
            return await _userManager.FindByNameAsync(UserName);
        }

        public async Task<IList<string>> GetRoles(User user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public List<User> GetUsers()
        {
            return _userManager.Users.ToList();
        }
    }
}
