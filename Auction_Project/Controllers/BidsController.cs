﻿using Microsoft.AspNetCore.Mvc;
using Auction_Project.Services.BidService;
using Auction_Project.Models.Bids;

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
        public async Task<ActionResult<IEnumerable<BidResponse>>> Get()
        {
            var bids = await _bidServices.Get();
            if (bids.Count == 0)
                return NotFound("List is empty");
            return Ok(bids);
        }
         
        // GET api/<BidsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BidResponse>> GetById(int id)
        {
            var bid = await _bidServices.GetById(id);

            if (bid != null)
                return Ok(new BidResponse (bid));
            return NotFound("Bid not found");
        }

        // POST api/<BidsController>
        [HttpPost]
        public async Task<ActionResult<Bid>> Post(BidRequest bid)
        {
            if(await _bidServices.Post(bid)) 
                return CreatedAtAction(nameof(Get), bid);
            return BadRequest();
        }

        // PUT api/<BidsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(BidDTO bid, int id)
        {
            var status = await _bidServices.Update(bid, id);
            if (status)
                return Ok(bid);
            return BadRequest();
        }

        // DELETE api/<BidsController>/5
        [HttpDelete("{id}")]
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