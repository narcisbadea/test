namespace Auction_Project.Services.EmailService
{
    public interface IEmailService
    {
        void Send(string to, string subject, string body);
    }
}
