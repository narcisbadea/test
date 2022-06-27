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
        var result = await _context.Bids
            .Include(b => b.User)
            .Include(b => b.Item)
            .ToListAsync();
        return result; 
    }


    public async Task<Bid> GetBid(int id)
    {
        var BidList = await _context.Bids
            .Include(b => b.User)
            .Include(b => b.Item)
            .ToListAsync();
        var result = BidList.Find(r => r.Id == id); 
        return result;
    }

      public async Task<int> DeleteBid(int id)
    {
        var ToDelete = await _context.Bids.FirstOrDefaultAsync(bid=>bid.Id==id);
        
        if (ToDelete != null)
        {
            _context.Bids.Remove(ToDelete);
            await _context.SaveChangesAsync();
            return id;
        }
        return 0;
     
    }

    public async Task<bool> PostBid(BidRequest toPost)
    {
        var user = await _context.Users.FindAsync(toPost.ID_User);
        var item = await _context.Items.FindAsync(toPost.ID_Item);
        if (item != null && user != null)
        {
            var bid = new Bid
            {
                User = user,
                Item = item,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                CurrentPrice = toPost.CurrentPrice
            };
            _context.Bids.Add(bid);
            _context.SaveChanges();
            return true; 
        } 
        return false;
    }
      
    public async void UpdateBid(BidDTO bid,int id)
    {
        var ToReplace = await _context.Bids.FindAsync(id);
        if (ToReplace != null)
        {
            var user = await _context.Users.FindAsync(bid.IdNextUser);
            if(user != null)
            {
                ToReplace.User = user;
                ToReplace.Updated = DateTime.UtcNow;
                ToReplace.CurrentPrice = bid.Price;
                _context.SaveChanges();
            }

        }

    }
}


