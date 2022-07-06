using Auction_Project.Models.Users;
using System.IdentityModel.Tokens.Jwt;

namespace Auction_Project.Services.UserService
{
    public interface IUserService
    {
        Task<string?> VeryfyData(UserRegisterDTO user);

        Task<bool> CheckPassword(UserLoginDTO user);

        Task<JwtSecurityToken> GenerateToken(UserLoginDTO user);

        Task<UserResponseDTO?> AddUser(UserRegisterDTO model);

        Task<bool> ChangePassword(UserChangePasswordDTO dto);

        List<UserResponseDTO> GetAll();
        Task<bool> ChangeUserRole(UserRoleDTO role);
        string GetMyName();

        string GetMyRole();

        bool IsValidCNP(string cnp);

        bool IsValidEmail(string email);

        int AgeFromCnp(string cnp);
        Task<User> GetMe();
    }
}
