using Auction_Project.Models.Pictures;

namespace Auction_Project.DAL
{
    public interface IRepositoryPictures
    {
        Task<Picture?> GetById(int id);
        Task<Picture?> Post(Picture pic);
    }
}
