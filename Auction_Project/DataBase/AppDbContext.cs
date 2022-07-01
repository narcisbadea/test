using Auction_Project.Models.BannedUsers;
using Auction_Project.Models.Bids;
using Auction_Project.Models.Extras;
using Auction_Project.Models.Items;
using Auction_Project.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Auction_Project.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<BannedUser> BannedUsers { get; set; }
     
        public DbSet<Item> Items { get; set; }

        public DbSet<Bid> Bids { get; set; }

        public DbSet<BidLibrary> BidLibraries { get; set; }
    }
}
