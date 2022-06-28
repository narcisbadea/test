using Auction_Project.DataBase;
using Auction_Project.Models.Users;
using Auction_Project.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Auction_Project.Authenticate
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly AppDbContext _dbContext;

        public AuthController(IUserService userService, AppDbContext dbContext)
        {
            _userService = userService;
            _dbContext = dbContext;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDTO request)
        {
            var usernameUsed = await _dbContext.Users.FirstOrDefaultAsync(user => user.UserName == request.UserName);
            if(usernameUsed != null)
            {
                return BadRequest("Username already used!");
            }
            if (!_userService.IsValidEmail(request.Email))
            {
                return BadRequest("Email is not valid!");
            }
            if (!_userService.IsValidCNP(request.Cnp))
            {
                return BadRequest("CNP is not valid!");
            }
            if(_userService.AgeFromCnp(request.Cnp) < 18)
            {
                return BadRequest("Underage!");
            }

            _userService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                UserName = request.UserName,
                Password = passwordHash,
                PwSalt = passwordSalt,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Cnp = request.Cnp,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                IsAdmin = false
            };
            var result = await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return Ok(new
            {
                result.Entity.UserName, result.Entity.Email, result.Entity.FirstName, 
                result.Entity.LastName, result.Entity.Cnp, result.Entity.Created
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDTOLogin request)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.UserName == request.UserName);
            if (user?.UserName != request.UserName)
            {
                return BadRequest("User not found.");
            }

            if (!(_userService.VerifyPasswordHash(request.Password, user.Password, user.PwSalt)))
            {
                return BadRequest("Wrong password.");
            }
            string token = _userService.CreateToken(user);
            return Ok(new
            {
                token
            });
        }  
    }
}