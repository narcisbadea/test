using Auction_Project.DataBase;
using Auction_Project.Models.Pictures;
using Microsoft.EntityFrameworkCore;

namespace Auction_Project.DAL
{
    public class RepositoryPicture : IRepositoryPicture
    {
        private readonly AppDbContext _context;


        public RepositoryPicture(AppDbContext _context)
        {
            this._context = _context;
        }


        public async Task<Picture> CreatePicture(Picture picture) 
        {
            _context.Pictures.Add(picture);
            await _context.SaveChangesAsync();
            return picture;
        }

        public async Task<Picture> DeletePicture(int id)
        {
            var picture = await _context.Pictures.FirstOrDefaultAsync(pic => pic.Id == id);
            _context.Pictures.Remove(picture);
            await _context.SaveChangesAsync();
            return picture;
        }

        public async Task<List<Picture>> GetAllPicture()
        {
            var pictureList = await _context.Pictures.ToListAsync();
            return pictureList;
        }

        public async Task<Picture> GetPictureById(int id)
        {
            var picture = await _context.Pictures.FirstOrDefaultAsync(pic => pic.Id == id);
            if (picture == null)
                return null;

            return picture;
        }

        public async Task<Picture> UpdatePicture(Picture pictureUpdated)
        {
            var picture = await _context.Pictures.FirstOrDefaultAsync(pic => pic.Id == pictureUpdated.Id);

            if (picture == null)
                return null;

            picture.Description = pictureUpdated.Description;
            picture.ImageAddress = pictureUpdated.ImageAddress;

            _context.Pictures.Update(picture);
            await _context.SaveChangesAsync();

            return pictureUpdated;

        }
    }
}
