using Auction_Project.DAL;
using Auction_Project.Models.Pictures;
using AutoMapper;

namespace Auction_Project.Services.PictureService
{
    public class PictureService : IPictureService
    {
        private readonly IRepositoryPictures _repositoryPictures;
        private readonly IMapper _mapper;

        public PictureService(IRepositoryPictures repositoryPictures, IMapper mapper)
        {
            _repositoryPictures = repositoryPictures;
            _mapper = mapper;
        }

        public async Task<PictureResponseDTO> GetById(int id)
        {
            var pic = await _repositoryPictures.GetById(id);
            var response = _mapper.Map<PictureResponseDTO>(pic);
            return response;
        }

        public async Task<PictureResponseDTO> PostPicture(PictureRequestDTO pic)
        {
            string uploads = Path.Combine(Directory.GetCurrentDirectory(), "pictures");
            System.IO.Directory.CreateDirectory(uploads);
            if (pic.Image != null && pic.Description != null)
            {
                string filePath = Path.Combine(uploads, pic.Image.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await pic.Image.CopyToAsync(fileStream);
                }
                var result = await _repositoryPictures.Post(new Picture { Description = pic.Description, ImageAddress = filePath });
                var response = _mapper.Map<PictureResponseDTO>(result);
                return response;
            }
            return null;
        }

        public async Task<List<PictureResponseDTO>> PostPictures(List<PictureRequestDTO> pics)
        {
            var listofDTOs = new List<PictureResponseDTO>();
            foreach(var picture in pics)
            {
                listofDTOs.Add(await PostPicture(picture));
            }
            return listofDTOs;
           
        }
    }
}
