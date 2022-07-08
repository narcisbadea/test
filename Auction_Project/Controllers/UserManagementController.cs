using Auction_Project.Models.Users;
using Auction_Project.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auction_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "root")]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserManagementController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<UserResponseDTO> GetUsers()
        {
            var users = _userService.GetAll();
            if (users == null)
            {
                NotFound();
            }
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult> AddRoleAsync(UserRoleDTO role)
        {
            if( !await _userService.ChangeUserRole(role))
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
