using Auction_Project.DataBase;
using Auction_Project.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace Auction_Project.DAL
{
    public class RepositoryUser : IRepositoryUser
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _dbContext;


        public RepositoryUser(UserManager<User> userManager, AppDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
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

        public async Task<User> BanUser(User user)
        {
            var temp = await _userManager.FindByIdAsync(user.Id);
            if (temp != null)
            {
                var result = await _userManager.UpdateAsync(temp);
                return temp;
            }
            return null;
        }

    }

}
