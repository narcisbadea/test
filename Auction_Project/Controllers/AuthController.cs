﻿using Auction_Project.DataBase;
using Auction_Project.Models.Users;
using Auction_Project.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

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

        [HttpPut("change-password")]
        public async Task<ActionResult<bool>> ChangePassword(UserChangePasswordDTO user)
        {
            var updated = await _userService.ChangePassword(user);
            if (updated)
            {
                return Ok(updated);
            }
            return BadRequest(updated);
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