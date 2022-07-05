using Microsoft.AspNetCore.Mvc;
using Auction_Project.Services.BidService;
using Auction_Project.Models.Bids;
using Auction_Project.Services.UserService;
using Microsoft.AspNetCore.Authorization;

namespace Auction_Project.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidsController : ControllerBase
    {

        private readonly BidServices _bidServices;

        private readonly IUserService _userServices;


        public BidsController(BidServices bidServices, IUserService userServices)
        {
            _bidServices = bidServices;
            _userServices = userServices;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<BidResponseDTO>>> Get()
        {
            var bids = await _bidServices.Get();
            if (bids.Count == 0)
                return NotFound("List is empty");
            return Ok(bids);
        }
         

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<BidResponseDTO>> GetById(int id)
        {
            var bid = await _bidServices.GetById(id);

            if (bid != null)
                return Ok(bid);
            return NotFound("Bid not found");
        }

        // POST api/<BidsController>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Bid>> Post(BidRequestDTO bid)
        {
            if(await _bidServices.Post(bid)) 
                return CreatedAtAction(nameof(Get), bid);
            return BadRequest();
            // de pus bids for approval
        }
     

        // PUT api/<BidsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(BidRequestDTO bid, int id)
        {
           /* var status = await _bidServices.Update(bid, id);
            if (status)
                return Ok(bid);*/
            return BadRequest();
        }

        // DELETE api/<BidsController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var bid = await _bidServices.GetById(id);
            if (bid != null)
            {
                await _bidServices.Delete(id);
                return Ok("Bid removed");
            }
            return NotFound("Bid not found");
        }
    }
}
