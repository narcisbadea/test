
using Auction_Project.Models.Bids;
using Auction_Project.Models.Items;
using Auction_Project.Models.Pictures;
using Auction_Project.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auction_Project.DataBase
{
    public class AppDbContext : IdentityDbContext<User, Role, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }

        public DbSet<Bid> Bids { get; set; }

        public DbSet<Picture> Pictures { get; set; }
    }
}
