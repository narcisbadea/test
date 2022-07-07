using Auction_Project.DAL;
using Auction_Project.DataBase;
using Auction_Project.Models.Bids;
using Auction_Project.Models.Items;
using Auction_Project.Services.EmailService;
using Auction_Project.Services.UserService;
using AutoMapper;
using Hangfire;

namespace Auction_Project.Services.BidService
{
    public class BidCloseServices : IBidCloseServices
    {
        private readonly IRepositoryItem _repositoryItem;
        private readonly IMapper _mapper;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IRepositoryBids _repositoryBids;

        public BidCloseServices(IRepositoryItem repositoryItem, IMapper mapper, IBackgroundJobClient backgroundJobClient, IUserService userService, IEmailService emailService, IRepositoryBids repositoryBids)
        {

            _repositoryItem = repositoryItem;
            _mapper = mapper;
            _backgroundJobClient = backgroundJobClient;
            _userService = userService;
            _emailService = emailService;
            _repositoryBids = repositoryBids;
        }

        public async Task<ItemRequestIsAvailableDTO> SetApproved(int idItem)
        {
            //var userSearched = await _repositoryBid.GetUserIdFromBid(idItem);
            int durationToBeSold = 0;
            var itemSearched = await _repositoryItem.GetById(idItem);

            if (itemSearched == null)
                return null;

            //if(itemSearched.endTime > DateTime.UtcNow)
                durationToBeSold = (int)(itemSearched.endTime - DateTime.UtcNow).GetValueOrDefault().Minutes;

            //if (itemSearched.endTime <= DateTime.UtcNow)
            //    return null;
            


            var updatedItem = await _repositoryItem.Enable(itemSearched.Id);


            _backgroundJobClient.Schedule(() => SetAsSold(updatedItem), TimeSpan.FromSeconds(10)); //durationTimeToAsSold);//durationTimeToAsSold);

            return _mapper.Map<ItemRequestIsAvailableDTO>(updatedItem);
        }

        public async Task SetAsSold(Item itemSearched)
        { 
            

            await _repositoryItem.UpdateToSold(itemSearched.Id);
            var user = await _repositoryBids.GetUserIdFromBid(itemSearched.Id);
            var email = user.Email;
            _emailService.Send(email, "WINNER", $"Ai castigat {itemSearched.Name}. \nFelicitari!!! ");

        }
        
    }
}
