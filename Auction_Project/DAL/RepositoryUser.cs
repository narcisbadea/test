using Auction_Project.DataBase;
using Auction_Project.Models.Users;

namespace Auction_Project.DAL
{
    public class RepositoryUser : IRepositoryUser
    {
        private readonly AppDbContext _dbContext;

        public RepositoryUser(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
