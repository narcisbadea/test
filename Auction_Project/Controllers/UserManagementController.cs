using Auction_Project.Models.Users;
using Auction_Project.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auction_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserManagementController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<UserResponseDTO>> GetUsers()
        {
            var users = _userService.GetAll();
            if (users == null)
            {
                NotFound("Users not found");
            }
            return Ok(users);
        }
        [HttpGet("roles")]
        public async Task<ActionResult<List<string>>> GetRolesById(string userID)
        {
            var roles = await _userService.GetUserRolesById(userID);
            if(roles != null)
            {
                return Ok(roles);
            }
            return BadRequest();
        }


        [HttpPost]
        [Authorize (Roles = "root")]
        public async Task<ActionResult> AddRoleAsync(UserRoleDTO role)
        {
            if( !await _userService.ChangeUserRole(role))
            {
                return BadRequest("Can't set this role!");
            }
            return Ok("New role added!");
        }
    }
}
