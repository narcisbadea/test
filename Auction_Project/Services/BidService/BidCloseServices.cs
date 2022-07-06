using Auction_Project.DAL;
using Auction_Project.DataBase;
using Auction_Project.Models.Bids;
using Auction_Project.Models.Items;
using AutoMapper;

namespace Auction_Project.Services.BidService
{
    public class BidCloseServices : IBidCloseServices
    {
        private readonly IRepositoryItem _repositoryItem;
        private readonly IRepositoryBids _repositoryBid;
        private readonly IMapper _mapper;

        public BidCloseServices(IRepositoryBids repositoryBid, IRepositoryItem repositoryItem, IMapper mapper)
        {
            _repositoryBid = repositoryBid;
            _repositoryItem = repositoryItem;
            _mapper = mapper;
        }
        public async Task SetItemAvabilityToTrue(int id)
        {
            var itemSearched = await _repositoryItem.GetById(id);

            itemSearched.IsAvailable = true;

            await _repositoryItem.UpdateItem(itemSearched);

           
        }

        public async Task SetItemAsSold(int id)
        {
            var itemSearched = await _repositoryItem.GetById(id);
            
            itemSearched.IsSold = true;
            itemSearched.IsAvailable = false;
            //itemSearched.winningBid = null;//await _repositoryBid.GetUserIdFromBid(id);

            await _repositoryItem.UpdateItem(itemSearched);
        }

    }
}
