using Cargo.Application.Contracts.Percistance;
using Cargo.Domain.Base;
using Cargo.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Cargo.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> 
        where T : BaseEntity
    {
        protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .FirstAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
