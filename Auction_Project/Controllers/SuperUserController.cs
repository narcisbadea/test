using Auction_Project.DataBase;
using Auction_Project.Models.Bids;
using Auction_Project.Models.Items;
using Auction_Project.Models.Users;
using Auction_Project.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Auction_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperUserController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Bid> _bidRepository;

        private readonly IUserService _userService;
        private readonly IAdminService _adminService;

        //private readonly AppDbContext _context;

        public SuperUserController(IRepository<User> userRepository, IRepository<Bid> bidRepository,/* AppDbContext context,*/ IUserService userService, IAdminService adminService)
        {
            _userRepository = userRepository;
            _bidRepository = bidRepository;
            //_context = context;
            _userService = userService;
            _adminService = adminService;
        }

        //Admin
        [HttpGet("get-admins")]
        public async Task<ActionResult> GetAdmins()
        {
            var users = await _userRepository.Get();

            if (users == null)
                return NotFound($"Users are not found");

            return Ok(users.Where(users => users.IsAdmin == true).ToList());
        }
        
        [HttpGet("get-admin-by-id")]
        public async Task<ActionResult> GetAdmin(int id)
        {
            var admin = await _userRepository.GetById(id);

            if (admin == null)
                return NotFound($"Admin with id {id} is not found");

            return Ok(admin);
        }

        //User
        [HttpGet("get-users")]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _userRepository.Get();

            if (users == null)
                return NotFound($"Users are not found");

            return Ok(users.Where(users => users.IsAdmin == false).ToList());
        }

        [HttpGet("get-user-by-id")]
        public async Task<ActionResult> GetUser(int id)
        {
            var user = await _userRepository.GetById(id);

            if(user == null)
                return NotFound($"User with id {id} not found");
            return Ok(user);
        }

        [HttpGet("get-banned-users")]
        public async Task<ActionResult> GetBannedUsers()
        {
            var bannedUsers = await _adminService.GetBannedUsers();

            if (bannedUsers is null)
                return NotFound("There is no banned users!");

            /*
            var users = await _context.BannedUsers
                .Include(u => u.User)
                .Include(a => a.Admin)
                .ToListAsync();*/
            return Ok(bannedUsers);
        }
        [HttpGet("get-banned-user-by-id")]
        public async Task<ActionResult> GetBannedUser(int id) 
        {
            var bannedUser = await _adminService.GetBannedUser(id);

            if (bannedUser is null)
                return NotFound("Banned user is not found");

            return Ok(bannedUser);
        }

        [HttpPost("set-user")]
        public async Task<ActionResult> SetUser(UserDTOUpdate userRequested, bool setAdmin)
        {
            var generatedPassword = _userService.GenerateRandomPasswordString();

            _userService.IsValidCNP(userRequested.Cnp);
            _userService.CreatePasswordHash(generatedPassword, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                UserName = userRequested.UserName,
                Email = userRequested.Email,
                Password = passwordHash,
                PwSalt = passwordSalt,
                FirstName = userRequested.FirstName,
                LastName = userRequested.LastName,
                Cnp = userRequested.Cnp,
                IsAdmin = setAdmin
            };

            await _userRepository.Post(user);
            return Ok(user);
        }

        [HttpDelete("remove-user-by-id")]
        public async Task<ActionResult> RemoveUser(int id)
        {
            await _userRepository.Delete(id);

            if(id == 0)
                return NotFound();

            return Ok($"User with id {id} is deleted");
        }

        [HttpPost("ban-user")]
        public async Task<ActionResult> BanUser(int id)
        {
            var bannedUser = await _adminService.AddBannedUser(id, 2);

            if(bannedUser is null)
                return NotFound("The user is not found!");

            return Ok($"Banned user with id {id}");
        }

        [HttpPut("update-user")]
        public async Task<ActionResult> UpdateUser(int userId, UserDTOUpdate userRequested, bool setAdmin)
        {
            var searchUser = await _userRepository.GetById(userId);
            //var generatedPassword = _userService.GenerateRandomPasswordString();

            //_userService.CreatePasswordHash(generatedPassword, out byte[] passwordHash, out byte[] passwordSalt);
            if (userRequested is null)
                return NotFound("User not found!");


            searchUser.UserName = userRequested.UserName;
            //Password = passwordHash,
            //PwSalt = passwordSalt,
            searchUser.Email = userRequested.Email;
            searchUser.FirstName = userRequested.FirstName;
            searchUser.LastName = userRequested.LastName;
            searchUser.Cnp = userRequested.Cnp;
            searchUser.Updated = DateTime.UtcNow;
            searchUser.IsAdmin = setAdmin;
            
            await _userRepository.Update(searchUser);
            return Ok(searchUser);
        }

        //Bid
        [HttpGet("get-bids")]
        public async Task<ActionResult> GetBids()
        {
            var bids = await _bidRepository.Get();

            if (bids is null)
                return NotFound("There is no bids");

            return Ok(bids);
        }

        [HttpGet("get-bid-by-id")]
        public async Task<ActionResult> GetBid(int id)
        {
            var bid = await _bidRepository.GetById(id);

            if (bid is null)
                return NotFound($"Bid with id {id} is not found!");

            return Ok(bid);
        }

        [HttpPost("set-bid")]
        public async Task<ActionResult> SetBid(Bid bidRequested)
        {
            var bid = new Bid
            {
                User = bidRequested.User,
                Item = bidRequested.Item,
                CurrentPrice = bidRequested.CurrentPrice,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
            };

            await _bidRepository.Post(bid);
            return Ok(bid);
        }

        //Item
        [HttpGet("get-items")]
        public async Task<ActionResult> GetItems() => NotFound("Not implemented");

        [HttpGet("get-item")]
        public async Task<ActionResult> GetItem(int id) => NotFound("Not implemented");

        [HttpPost("set-item")]
        public async Task<ActionResult> SetItem(Item item) => NotFound("Not implemented");

    }
}
