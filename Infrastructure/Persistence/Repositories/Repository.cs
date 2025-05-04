using Application.Constants;
using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly HayvanContext _context;

        public Repository(HayvanContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }



        public async Task DeleteAsync(T entity)
        {
            if (entity.DeletedDate == null)
            {
                entity.DeletedDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception(Messages<T>.EntityAlreadyDeleted);
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>()
                .Where(x => x.DeletedDate == null)
                .ToListAsync();
        }

        //public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        //{
        //    return await _context.Set<T>().SingleOrDefaultAsync(filter);
        //}

        //aşağıdaki metot üstteki metodun daha gelişmişidir. aşağıdaki metot başka tabloları da include edebilmemizi sağlar.
        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var include in includes)
                query = query.Include(include);

            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null && entity.DeletedDate == null)
            {
                return entity;
            }
            throw new Exception(Messages<T>.EntityNotFound);
        }

        public async Task UpdateAsync(T entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
