using Auction_Project.Models.Users;
using Auction_Project.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auction_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {

        private readonly IUserService _userService;

        public AdminUserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("get-list/{nr}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<UserResponseDTO>>> Get(int nr)
        {
            var response = _userService.GetAllClientsByPage(nr);
            if(response != null)
                return Ok(response);
            return BadRequest("No users found");
        }

        [HttpDelete("ban-user/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserResponseDTO>> Ban(string id)
        {
            var response = await _userService.BanUser(id);
            if (response != null)
                return Ok("User has been banned.");
            return BadRequest("User matching criteria not found.");
        }

    }
}
