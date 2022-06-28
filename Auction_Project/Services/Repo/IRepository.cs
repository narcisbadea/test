﻿using Auction_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Auction_Project.Services.Repo
{
    public interface IRepository<T> where T : class, IEntity
    {
        public Task<IEnumerable<T>> Get();
        public Task<T> GetById(int id);
        public Task<T> Delete(int id);
        public Task<T> Post(T entity);
        public Task<T> Update(T entity);
        DbSet<T> DbSet { get; }
    }
}
