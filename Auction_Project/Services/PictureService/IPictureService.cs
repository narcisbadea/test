using Auction_Project.Models.Pictures;

namespace Auction_Project.Services.PictureService
{
    public interface IPictureService
    {
        Task<PictureResponseDTO> GetById(int id);
        Task<PictureResponseDTO> PostPicture(PictureRequestDTO pic);
        Task<List<PictureResponseDTO>> PostPictures(List<PictureRequestDTO> pics);
    }
}
