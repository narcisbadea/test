namespace Auction_Project.Models.Users
{
    public class UserLoginResponseDTO
    {
        public string token { get; set; }
        public UserResponseDTO userResponse { get; set; }
        
        public List<string> roles { get; set; }
    }
}
