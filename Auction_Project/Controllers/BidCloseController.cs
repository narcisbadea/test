using Auction_Project.Services.BidService;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auction_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidCloseController : ControllerBase
    {
        private readonly IBidCloseServices _bidCloseServices;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public BidCloseController(IBidCloseServices bidCloseServices, IBackgroundJobClient backgroundJobClient)
        {
            _bidCloseServices = bidCloseServices;
            _backgroundJobClient = backgroundJobClient;
        }

        [HttpPost("SetTimerToCloseBid")]
        public async Task<ActionResult> SetTimerToCloseBid(int id)
        { 

            //_backgroundJobClient.Schedule(() => _bidCloseServices.SetItemAsSold(id), TimeSpan.FromSeconds(5));
            //_backgroundJobClient.Enqueue(() => _bidCloseServices.SetItemAsSold(id));


            return Ok();
        }
    }
}
