using Auction_Project.DAL;
using Auction_Project.Models.Users;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auction_Project.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepositoryUser _repositoryUser;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public UserService(RoleManager<Role> roleManager, IMapper mapper, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, IRepositoryUser repositoryUser) 
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
            _repositoryUser = repositoryUser;
            _roleManager = roleManager;
        }

        public List<UserResponseDTO> GetAll()
        {
            List<UserResponseDTO> response = new List<UserResponseDTO>();
            foreach (var user in _repositoryUser.GetUsers())
            {
                var usr = _mapper.Map<UserResponseDTO>(user);
                var userN = _repositoryUser.GetById(user.Id);
                response.Add(usr);
            }
            return response;
        }

        public async Task<bool> ChangeUserRole(UserRoleDTO role)
        {
            var rolesDoesNotExist = !await _roleManager.RoleExistsAsync(role.RoleName);
            var roles = await _userManager.GetUsersInRoleAsync(role.RoleName);
            
            if (rolesDoesNotExist || roles.Count == 0)
            {
                await AddRoles(role.RoleName);
            }
            var user = _userManager.Users.FirstOrDefault(u => u.Id == role.Id);

            IdentityResult? result = null;
            result = await _userManager.AddToRoleAsync(user, role.RoleName);
            if (result == null)
            {
                return false;
            }

            return true;

        }
        private async Task<IdentityResult> AddRoles(string roleName)
        {
            var role = new Role { Id = Guid.NewGuid().ToString(), Name = roleName };
            var result = await _roleManager.CreateAsync(role);
            return result;
        }

        public async Task<string?> VeryfyData(UserRegisterDTO user)
        {
            var usernameUsed = await _repositoryUser.GetByName(user.UserName);
            var error = "";
            if (usernameUsed != null)
            {
                error += "Username already used!\n";
            }
            if (!IsValidEmail(user.Email))
            {
                error += "Email is not valid!\n";
            }
            if (!IsValidCNP(user.Cnp))
            {
                error += "CNP is not valid!\n";
            }
            if (AgeFromCnp(user.Cnp) < 18)
            {
                error += "Underage!\n";
            }
            if(error != "") return error;
            return null;
        }


        public string GetMyName()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return result;
        }


        public async Task<User> GetMe()
        {
            var id =  GetMyId().Result;
            return _repositoryUser.GetById(id);
        }

        public async Task<string> GetMyId()
        {
            var user = await _repositoryUser.GetByName(GetMyName());
            return user.Id;
        }

        public string GetMyRole()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            }
            return result;
        }

        public bool IsValidCNP(string cnp)
        {
            int[] c = new int[13];
            if (cnp.Trim().Length != 13)
            {
                return false;
            }
            if (cnp.Trim() == "0000000000000")
            {
                return false;
            }
            for (int i = 0; i <= 12; i++)
            {
                try
                {
                    c[i] = System.Convert.ToInt32(cnp.Substring(i, 1));
                }
                catch (Exception)
                {
                    return false;
                }
            }
            int sum = c[0] * 2 + c[1] * 7 + c[2] * 9 + c[3] * 1 + c[4] * 4 + c[5] * 6 + c[6] * 3 + c[7] * 5 + c[8] * 8 + c[9] * 2 + c[10] * 7 + c[11] * 9;
            int control = sum % 11;
            if (control == 10)
            {
                control = 1;
            }
            if (control != c[12])
            {
                return false;
            }
            return true;
        }

        public bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public int AgeFromCnp(string cnp)
        {
            int y = Convert.ToInt32(cnp.Substring(1, 2));
            if(Convert.ToInt32(cnp.Substring(0,1)) < 5){
                y = 1900 + y;
            }
            else
            {
                y = 2000 + y;
            }
            int m = Convert.ToInt32(cnp.Substring(3, 2));
            int d = Convert.ToInt32(cnp.Substring(5, 2));
            DateTime bd = new DateTime(y, m, d);
            TimeSpan span = DateTime.Now - bd;
            DateTime zeroTime = new DateTime(1, 1, 1);
            return (zeroTime + span).Year - 1;
        }

        public async Task<bool> CheckPassword(UserLoginDTO user)
        {
            var userFind = await _repositoryUser.GetByName(user.UserName);

            var wrongPassword = !await _userManager.CheckPasswordAsync(userFind, user.Password);
            if (user == null || wrongPassword)
            {
                return false;
            }
            return true;
        }

        public async Task<JwtSecurityToken> GenerateToken(UserLoginDTO userLogin)
        {
            var user = await _repositoryUser.GetByName(userLogin.UserName);
            var userRoles = await _repositoryUser.GetRoles(user);

            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            authClaims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var token = new JwtSecurityToken(
                _configuration["JWT:ValidIssuer"],
                _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
            return token;
        }

        public async Task<UserResponseDTO?> AddUser(UserRegisterDTO model)
        {
            var puser = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                Created = DateTime.UtcNow,
                IsActive = true,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Cnp = model.Cnp
            };

            var result = await _userManager.CreateAsync(puser, model.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(error => error.Description);
                return null;
            }

            var user = await _repositoryUser.GetByName(puser.UserName);

            return _mapper.Map<UserResponseDTO>(user);
        }

        public async Task<bool> ChangePassword(UserChangePasswordDTO dto)
        {
            var user = GetMe();
            if (user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user.Result, dto.oldPassword, dto.newPassword);
                return result.Succeeded;
            }
            return false;
        }
    }
}