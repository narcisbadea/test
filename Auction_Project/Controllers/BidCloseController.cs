using Auction_Project.Models.Items;
using Auction_Project.Services.BidService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auction_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidCloseController : ControllerBase
    {

        private readonly IBidCloseServices _bidCloseServices;

        public BidCloseController(IBidCloseServices bidCloseServices)
        {
            _bidCloseServices = bidCloseServices;
        }

        [HttpGet]
        public async Task<ActionResult> ApproveItem(int idItem)
        {

            var approvedItem = await _bidCloseServices.SetApproved(idItem);


            /*if(approvedItem == null)
                return NotFound();*/

            return Ok(approvedItem);

        }


    }
}
