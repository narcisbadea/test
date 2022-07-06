using Auction_Project.DAL;
using Auction_Project.DataBase;
using Auction_Project.Models.Bids;
using Auction_Project.Models.Items;
using AutoMapper;
using Hangfire;

namespace Auction_Project.Services.BidService
{
    public class BidCloseServices : IBidCloseServices
    {
        private readonly IRepositoryItem _repositoryItem;
        private readonly IRepositoryUser _repositoryUser;
        private readonly IRepository<Item> _repositoryItemGeneric;
        private readonly IRepositoryBids _repositoryBid;
        private readonly IMapper _mapper;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public BidCloseServices(IRepositoryBids repositoryBid, IRepositoryItem repositoryItem, IMapper mapper, IBackgroundJobClient backgroundJobClient, IRepositoryUser repositoryUser)
        {
            _repositoryBid = repositoryBid;
            _repositoryItem = repositoryItem;
            _mapper = mapper;
            _backgroundJobClient = backgroundJobClient;
            _repositoryUser = repositoryUser;
        }

        public async Task<ItemRequestIsAvailableDTO> SetApproved(int idItem)
        {
            //var userSearched = await _repositoryBid.GetUserIdFromBid(idItem);

            var itemSearched = await _repositoryItem.GetById(idItem);

            if (itemSearched == null)
                return null;
            

            //var getEndTime = (DateTime)itemSearched.endTime;

           // System.TimeSpan durationTimeToAsSold = getEndTime.Subtract(DateTime.UtcNow);

            itemSearched.IsAvailable = true;

            await _repositoryItemGeneric.Update(itemSearched);

            _backgroundJobClient.Schedule(() => SetAsSold(itemSearched), TimeSpan.FromSeconds(5));//durationTimeToAsSold);

            return _mapper.Map<ItemRequestIsAvailableDTO>(itemSearched);
        }

        public async Task SetAsSold(Item itemSearched)
        {
            itemSearched.IsAvailable = false;
            itemSearched.IsSold = true;

            var userWinned = _repositoryBid.GetUserIdFromBid(itemSearched.Id);

            itemSearched.winningBidId = userWinned.Id;

            await _repositoryItemGeneric.Update(itemSearched);

        }
        
    }
}
