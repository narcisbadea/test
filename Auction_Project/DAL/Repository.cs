using Auction_Project.Models.Base;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Auction_Project.DataBase
{
    public class Repository<T> : IRepository<T> where T : class , IModel
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        private DbSet<T> _DbSet;
        public DbSet<T> DbSet => _DbSet ??= _context.Set<T>();

        public async Task<T> Delete(int id)
        {
            var ToDelete = await DbSet.FirstOrDefaultAsync(bid => bid.Id == id);

            if (ToDelete != null)
            {
                var entity = DbSet.Remove(ToDelete).Entity;
                await _context.SaveChangesAsync();
                return entity;
            }
            return null;
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await DbSet.ToListAsync();
        }


        public async Task<T> GetById(int id)
        {
            return await DbSet.FirstOrDefaultAsync(e => e.Id == id);
        }


        public async Task<T> Post(T entity)
        {
            var result = await DbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<T> Update([NotNull] T entity)
        {
            if (entity?.Id is null || await GetById(entity.Id) is null)
            {
                return null;
            }

            entity = DbSet.Update(entity).Entity;
            await _context.SaveChangesAsync();

            return entity;
        }

    }
}