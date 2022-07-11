using Auction_Project.DAL;
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
        private readonly IEmailService _emailService;
        private readonly IRepositoryBids _repositoryBids;
        private readonly IRepositoryUser _repositoryUser;

        public BidCloseServices(IRepositoryItem repositoryItem, IMapper mapper, IBackgroundJobClient backgroundJobClient, IEmailService emailService, IRepositoryBids repositoryBids, IRepositoryUser repositoryUser)
        {

            _repositoryItem = repositoryItem;
            _mapper = mapper;
            _backgroundJobClient = backgroundJobClient;
            _emailService = emailService;
            _repositoryBids = repositoryBids;
            _repositoryUser = repositoryUser;
        }

        public async Task<ItemRequestAvailableDTO?> SetApproved(int idItem)
        {
            var itemSearched = await _repositoryItem.GetById(idItem);

            if (itemSearched == null)
                return null;

            var updatedItem = await _repositoryItem.Enable(itemSearched.Id);

            if (updatedItem == null)
                return null;

            if (itemSearched.EndTime > 1)
                _backgroundJobClient.Schedule(() => SetAsSold(updatedItem), TimeSpan.FromSeconds((double)itemSearched.EndTime));

            return _mapper.Map<ItemRequestAvailableDTO>(updatedItem);
        }

        public async Task SetAsSold(Item itemSearched)
        {     
            var lastUserBidded = await _repositoryBids.GetUserIdFromBid(itemSearched.Id);

            if(lastUserBidded == null)
            {
                var ownerEmailUser = _repositoryUser.GetById(itemSearched.OwnerUserId);

                _emailService.Send(ownerEmailUser.Email, "A EXPIRAT PERIOADA DE LICITATIE", $"Salut! A expirat perioada de licitatie pentru itemul {itemSearched.Name}, \n Nimeni nu a licitat pentru itemul tau. ");

            } else if(lastUserBidded != null)
            {
                 var itemSold = await _repositoryItem.UpdateToSold(itemSearched.Id);

                _emailService.Send(lastUserBidded.Email, "WINNER", $"Ai castigat {itemSold.Name}. \nFelicitari!!! ");
            }

        }

        public async Task<Item> SetAsSoldByAdmin(int id)
        {
            var item = await _repositoryItem.GetById(id);

            if (item != null)
            {
                await SetAsSold(item);
                return item;

            }
            return null;
        }
        public async Task<Item> SetAsSoldByUser(int id)
        {
            var item = await _repositoryItem.GetById(id);

            if (item != null)
            {
                await SetAsSold(item);
                return item;

            }
            return null;
        }


    }
}
