using Auction_Project.DataBase;
using Auction_Project.Models.Items;
using Microsoft.EntityFrameworkCore;

namespace Auction_Project.DAL
{

    public class RepositoryItem :IRepositoryItem
    {
        private readonly AppDbContext _context;
        private readonly IRepositoryBids _repositoryBids;

        public RepositoryItem(AppDbContext context, IRepositoryBids repositoryBids)
        {
            _context = context;
            _repositoryBids = repositoryBids;
        }


        public async Task<List<Item>> Get()
        {
            return await _context.Items.Include(i => i.Gallery).ToListAsync();
        }

        public async Task<Item> GetById(int id)
        {
            return await _context.Items.Include(i => i.Gallery).FirstOrDefaultAsync(item=>item.Id == id);
        }

        public async Task<Item?> Enable(int id)
        {
            var toEnable = await _context.Items.Include(i => i.Gallery).FirstOrDefaultAsync(item => item.Id == id);
            if (toEnable != null)
            {
                toEnable.Available = true;

                _context.Items.Update(toEnable);
                await _context.SaveChangesAsync();
                return toEnable;
            }
            return null;
        }

        public async Task<Item?> UpdateToSold(int id)
        {
            var item = await _context.Items.Include(i => i.Gallery).FirstOrDefaultAsync(item => item.Id == id);
            if (item != null)
            {
                item.Available = false;
                item.IsSold = true;
          
                var user = await _repositoryBids.GetUserIdFromBid(id);

                if (user != null)
                {
                    item.winningBidId = user.Id;

                    _context.Items.Update(item);

                }

                await _context.SaveChangesAsync();
                return item;
            }
            return null;
        }

        public async Task<Item?> Disable(int id)
        {
            var toDisable = await _context.Items.Include(i => i.Gallery).FirstOrDefaultAsync(item => item.Id == id);
            if (toDisable != null)
            {
                toDisable.Available = false;

                _context.Items.Update(toDisable);
                await _context.SaveChangesAsync();
                return toDisable;
            }
            return null;
        }
    }
}
