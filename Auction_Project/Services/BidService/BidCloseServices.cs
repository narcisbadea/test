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
            int durationToBeSold = 0;
            var itemSearched = await _repositoryItem.GetById(idItem);

            if (itemSearched == null)
                return null;

            if(itemSearched.endTime > DateTime.UtcNow)
                durationToBeSold = (int)(itemSearched.endTime - DateTime.UtcNow).GetValueOrDefault().Minutes;

            if (itemSearched.endTime <= DateTime.UtcNow)
                return null;
            /*
            if(itemSearched.endTime <= DateTime.UtcNow)
            {
                await _repositoryItem.Disable(itemSearched.Id);
                return _mapper.Map<ItemRequestIsAvailableDTO>(updatedItem);
            }
            */
            Console.WriteLine($"End Time is: {durationToBeSold}");
           

            var updatedItem = await _repositoryItem.Enable(itemSearched.Id);

            _backgroundJobClient.Schedule(() => SetAsSold(updatedItem), TimeSpan.FromMinutes(durationToBeSold)); //durationTimeToAsSold);//durationTimeToAsSold);

            return _mapper.Map<ItemRequestIsAvailableDTO>(updatedItem);
        }

        public async Task SetAsSold(Item itemSearched)
        { 
            

            await _repositoryItem.UpdateToSold(itemSearched.Id);

        }
        
    }
}
