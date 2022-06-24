using Auction_Project.DataBase;
using Auction_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Auction_Project.Services;

public class BidServices
{
    private readonly AppDbContext _context;

    public BidServices(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Bid>> GetBids()
    {
        var result = await _context.Bids.ToListAsync();
        return result; 
    }

    public async Task<Bid> GetBid(int id)
    {
        var BidList = await _context.Bids.ToListAsync();
        var result = BidList.Find(r => r.Id == id); 
        return result;
    }

    public async void PostBid(Bid toPost)
    {

        _context.Bids.Add(toPost);
        try
        {
            _context.SaveChanges();
        }
        catch(Exception e)
        {
            Console.WriteLine("Kek "+e);
        }
    }
      
   /* public Bid GetBid(int id)
    {

    }*/
}


