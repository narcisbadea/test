using Auction_Project.Models.Pictures;

namespace Auction_Project.DAL
{
    public interface IRepositoryPicture
    {
        Task<Picture> CreatePicture(Picture Picture);
        Task<Picture> DeletePicture(int id);
        Task<List<Picture>> GetAllPicture();
        Task<Picture> GetPictureById(int id);
        Task<Picture> UpdatePicture(Picture PictureUpdated);
    }
}