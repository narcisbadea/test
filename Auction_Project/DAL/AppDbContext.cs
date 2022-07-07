
using Auction_Project.Models.Bids;
using Auction_Project.Models.Items;
using Auction_Project.Models.Pictures;
using Auction_Project.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auction_Project.DataBase
{
    public class AppDbContext : IdentityDbContext<User, Role, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedUsers(builder);
            this.SeedRoles(builder);
            this.SeedUserRoles(builder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }

        public DbSet<Bid> Bids { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        private void SeedUsers(ModelBuilder builder)
        {
            User user = new User
            {
                Id = "b5d9114f-c911-49b4-af7c-137ce9488dd7",
                UserName = "root",
                Email = "root@gmail.com",
                Cnp = "2881211259754",
                FirstName = "root",
                LastName = "root",
                NormalizedUserName = "ROOT",
                NormalizedEmail = "ROOT@GMAIL.COM"
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Root*1234");
            builder.Entity<User>().HasData(user);
        }
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
                new Role() { Id = "feadea3e-34b7-44a1-bafd-134749c706dc", Name = "root", NormalizedName = "ROOT" },
                new Role() { Id = "b1a678cf-d7a2-415a-9a8f-52d51e067e88", Name = "Admin", NormalizedName = "ADMIN" });
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "feadea3e-34b7-44a1-bafd-134749c706dc", UserId = "b5d9114f-c911-49b4-af7c-137ce9488dd7" },
                new IdentityUserRole<string>() { RoleId = "b1a678cf-d7a2-415a-9a8f-52d51e067e88", UserId = "b5d9114f-c911-49b4-af7c-137ce9488dd7" }
                );
        }
    }
}