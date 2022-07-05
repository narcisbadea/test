using Auction_Project.Models.Users;

namespace Auction_Project.Services.UserService
{
    public interface IUserService
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);

        string CreateToken(User user);

        string GetMyName();

        string GetMyRole();

        bool IsValidCNP(string cnp);

        bool IsValidEmail(string email);

        int AgeFromCnp(string cnp);

        bool ChangePassword(string newPasswd);
    }

}
