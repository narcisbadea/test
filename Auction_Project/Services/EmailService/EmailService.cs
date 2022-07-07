using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;


namespace Auction_Project.Services.EmailService;

public class EmailService : IEmailService
{
    private readonly SmtpClient _smtp;
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
        // send email
        _smtp = new SmtpClient();
        _smtp.Connect(configuration["Email:Host"], int.Parse(configuration["Email:Port"]), SecureSocketOptions.StartTls);
        _smtp.Authenticate(configuration["Email:Login"], configuration["Email:Password"]);
    }
    public void Send(string to, string subject, string body)
    {
        // create message
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_configuration["Email:Login"]));
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = subject;
        //email.Body = new TextPart(TextFormat.Html) { Text = html };
        email.Body = new TextPart(TextFormat.Plain) { Text = body };

        _smtp.Send(email);
        _smtp.Disconnect(true);
    }
}
