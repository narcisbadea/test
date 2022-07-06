using Auction_Project.Models.Bids;
using Auction_Project.Models.Items;
using Auction_Project.Models.Pictures;
using Auction_Project.Models.Users;
using AutoMapper;

namespace Auction_Project.Models.Base;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap(typeof(Bid), typeof(BidRequestDTO)).ReverseMap();
        CreateMap(typeof(Bid), typeof(BidResponseDTO)).ReverseMap();
        CreateMap(typeof(Item), typeof(ItemRequestDTO)).ReverseMap();
        CreateMap(typeof(Item), typeof(ItemResponseDTO)).ReverseMap();
        CreateMap(typeof(Item), typeof(ItemRequestForUpdateDTO)).ReverseMap();
        CreateMap(typeof(Picture), typeof(PictureRequestDTO)).ReverseMap();
        CreateMap(typeof(Picture), typeof(PictureResponseDTO)).ReverseMap();
        CreateMap(typeof(User), typeof(UserBannedDTO)).ReverseMap();
        CreateMap(typeof(User), typeof(UserLoginDTO)).ReverseMap();
        CreateMap(typeof(User), typeof(UserRegisterDTO)).ReverseMap();
        CreateMap(typeof(User), typeof(UserResponseDTO)).ReverseMap();
        CreateMap(typeof(User), typeof(UserSettingsDTO)).ReverseMap();
        
    }
}
