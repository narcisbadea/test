using Auction_Project.DataBase;
using Auction_Project.Models.Users;
using Auction_Project.Services.UserService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auction_Project.Authenticate
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly AppDbContext _dbContext;

        public AuthController(IUserService userService, AppDbContext dbContext, UserManager<User> userModel, IConfiguration configuration)
        {
            _userService = userService;
            _dbContext = dbContext;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserResponseDTO>> Register(UserRegisterDTO request)
        {
            
            var error = await _userService.VeryfyData(request);
            if (error != null)
            {
                return BadRequest(error);
            }
            var result = await _userService.AddUser(request);
            await _dbContext.SaveChangesAsync();
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO request)
        {

            if (!await _userService.CheckPassword(request))
            {
                return BadRequest();
            }

            var token = await _userService.GenerateToken(request);

            return Ok(new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            });
        } 
    }
}