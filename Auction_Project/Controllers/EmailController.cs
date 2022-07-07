using Auction_Project.Services.EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auction_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult>postEmail(string to, string subject, string body)
        {
            _emailService.Send(to, subject, body);
            return Ok();
        } 
    }
}
