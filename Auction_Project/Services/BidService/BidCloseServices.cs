using Auction_Project.DAL;
using Auction_Project.Models.Items;
using Auction_Project.Services.EmailService;
using AutoMapper;
using Hangfire;

namespace Auction_Project.Services.BidService
{
    public class BidCloseServices : IBidCloseServices
    {
        private readonly IRepositoryItem _repositoryItem;
        private readonly IMapper _mapper;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IEmailService _emailService;
        private readonly IRepositoryBids _repositoryBids;

        public BidCloseServices(IRepositoryItem repositoryItem, IMapper mapper, IBackgroundJobClient backgroundJobClient, IEmailService emailService, IRepositoryBids repositoryBids)
        {

            _repositoryItem = repositoryItem;
            _mapper = mapper;
            _backgroundJobClient = backgroundJobClient;
            _emailService = emailService;
            _repositoryBids = repositoryBids;
        }

        public async Task<ItemRequestAvailableDTO?> SetApproved(int idItem)
        {



            var itemSearched = await _repositoryItem.GetById(idItem);

            if (itemSearched == null)
                return null;



            var updatedItem = await _repositoryItem.Enable(itemSearched.Id);

            if (updatedItem == null)
                return null;


            if(itemSearched.EndTime > 1)
                _backgroundJobClient.Schedule(() => SetAsSold(updatedItem), TimeSpan.FromSeconds((double)itemSearched.EndTime));


            return _mapper.Map<ItemRequestAvailableDTO>(updatedItem);
        }

        public async Task SetAsSold(Item itemSearched)
        { 
            var userUpdated = await _repositoryItem.UpdateToSold(itemSearched.Id);

            if (userUpdated != null)
            {
                var user = await _repositoryBids.GetUserIdFromBid(itemSearched.Id);

                if (user != null)
                    _emailService.Send(user.Email, "WINNER", $"Ai castigat {itemSearched.Name}. \nFelicitari!!! ");
            }


        }
        
    }
}
