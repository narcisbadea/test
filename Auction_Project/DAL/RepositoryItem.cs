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
    }
}
