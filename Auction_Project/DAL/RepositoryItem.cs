using Auction_Project.DataBase;
using Auction_Project.Models.Items;
using Microsoft.AspNetCore.Mvc;

namespace Auction_Project.DAL
{
    public class RepositoryItem : IRepositoryItem
    {
        private readonly AppDbContext _appDbContext;

        public RepositoryItem(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Item>> GetAll()
        {
            var itemList = _appDbContext.Items.ToList();
            return itemList;
        }

        public async Task<Item> SetItem(Item item)
        {
            _appDbContext.Items.Add(item);
            await _appDbContext.SaveChangesAsync();
            return item;
        }

        public async Task<Item> GetById(int id)
        {
            var dbItem = _appDbContext.Items.FirstOrDefault(e => e.Id == id);

            if (dbItem == null)
                return null;

            return dbItem;
        }

            public async Task<Item> UpdateItem(Item request)
        {
            var dbItem = _appDbContext.Items.FirstOrDefault(i => i.Id == request.Id);
            //await _appDbContext.Items.FirstOrDefault(i => i.Id == request.Id);

            if (dbItem == null)
                return null;

            dbItem.Name = request.Name;
            dbItem.IsSold = request.IsSold;
            dbItem.Desc = request.Desc;
            dbItem.Price = request.Price;

            _appDbContext.Update(dbItem);
            await _appDbContext.SaveChangesAsync();

            return dbItem;

        }
    }
}
