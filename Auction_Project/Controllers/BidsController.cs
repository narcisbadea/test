using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Auction_Project.DataBase;
using Auction_Project.Services;
using Auction_Project.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Auction_Project.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidsController : ControllerBase
    {

        private readonly BidServices _bidServices;

        public BidsController(BidServices bidServices)
        {
            _bidServices = bidServices;
        }


        // GET: api/<BidsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bid>>> Get()
        {
            var bids = await _bidServices.GetBids();
            if (bids.Count == 0)
                return NotFound("List is empty");
            return bids;
        }
         
        // GET api/<BidsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bid>> GetById(int id)
        {
            var bid = await _bidServices.GetBid(id);

            if (bid != null)
                return Ok(bid);
            else
                return NotFound("Bid not found");
        }

        // POST api/<BidsController>
        [HttpPost]
        public async Task<ActionResult<Bid>> Post(Bid bid)
        {
            _bidServices.PostBid(bid);
            return CreatedAtAction(nameof(Get), new { id = bid.Id }, bid);
        }

        // PUT api/<BidsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id)
        {

            return Ok();
        }

        // DELETE api/<BidsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var bid = await _bidServices.GetBid(id);
            if (bid != null)
            {
                await _bidServices.DeleteBid(id);
                return Ok("Bid removed");
            }
            return NotFound("Bid not found");
        }
    }
}
