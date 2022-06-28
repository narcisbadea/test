using Auction_Project.Models.BannedUser;
using Auction_Project.Models.Bid;
using Auction_Project.Models.Item;
using Auction_Project.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Auction_Project.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<BannedUser> BannedUsers { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Item> Items { get; set; }

    }
}
