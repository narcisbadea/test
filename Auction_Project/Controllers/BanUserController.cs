using Auction_Project.Models.BannedUsers;
using Auction_Project.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auction_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class BanUserController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public BanUserController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("get-list-banned-user")]
        public async Task<ActionResult<IEnumerable<BannedUser>>> GetBannedUsers()
        {
            var bannedUsers = await _adminService.GetBannedUsers();
            if(bannedUsers.Count == 0)
            {
                return NotFound();
            }

            return bannedUsers;
        }

        [HttpGet("get-banned-user/id")]
        public async Task<ActionResult<BannedUser>> GetBannedUser(int id)
        {
            var getBannedUser =  await _adminService.GetBannedUser(id);

            if(getBannedUser == null)
            {
                return NotFound();
            }

            return getBannedUser;
        }

        [HttpPost("ban-user/id")]
        public async Task<ActionResult<BannedUser>> BanUser(int userId, int adminId)
        {
            var user = await _adminService.GetUnbannedUser(userId);

            if(user != null)
            {
   
                await _adminService.AddBannedUser(user, adminId);
                return Ok($"User with id {userId} is banned permanently");
            }
            
            return NotFound();
        }
        
        [HttpPost("unban-user/id")]
        public async Task<ActionResult<BannedUser>> UnbanUser(int userId, int adminId)
        {
            var user = await _adminService.UnbanUser(userId, adminId);

            if (user == null)
                return NotFound($"User with id {userId} isn't banned");

            await _adminService.DeleteBannedUser(userId);

            return Ok("User unbanned!");
        }
        

        [HttpDelete("delete-user/id")]
        public async Task<ActionResult<BannedUser>> DeleteBannedUser(int id)
        {
            var removeBannedUser = await _adminService.GetBannedUser(id);

            if(removeBannedUser != null)
            {
                await _adminService.DeleteBannedUser(id);
                return Ok($"User with id {id} is unbanned ");
            }

            return NotFound("User not found");

        }
    }
}
