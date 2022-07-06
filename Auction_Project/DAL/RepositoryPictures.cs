using Auction_Project.DataBase;
using Auction_Project.Models.Pictures;

namespace Auction_Project.DAL
{
    public class RepositoryPictures : IRepositoryPictures
    {
        private readonly AppDbContext _context;

        public RepositoryPictures(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Picture?> GetById(int id)
        {
            return _context.Pictures.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Picture?> Post(Picture pic)
        {
            var response = await _context.Pictures.AddAsync(pic);
            await _context.SaveChangesAsync();
            return response.Entity;
        }

    }
}
