using Auction_Project.DataBase;
using Auction_Project.Models.Items;
using Microsoft.EntityFrameworkCore;

namespace Auction_Project.DAL
{

    public class RepositoryItem :IRepositoryItem
    {
        private readonly AppDbContext _context;

        public RepositoryItem(AppDbContext context)
        {
            _context = context;
        }


        public async Task<List<Item>> Get()
        {
            return await _context.Items.Include(i => i.Gallery).ToListAsync();
        }

        public async Task<Item> GetById(int id)
        {
            return await _context.Items.Include(i => i.Gallery).FirstOrDefaultAsync(item=>item.Id == id);
        }


        public async Task<Item> Disable(int id)
        {
            var toDisable = await _context.Items.Include(i => i.Gallery).FirstOrDefaultAsync(item => item.Id == id);
            if (toDisable != null)
            {
                toDisable.IsAvailable = false;

                _context.Items.Update(toDisable);
                await _context.SaveChangesAsync();
                return toDisable;
            }
            return null;
        }
    }
}
