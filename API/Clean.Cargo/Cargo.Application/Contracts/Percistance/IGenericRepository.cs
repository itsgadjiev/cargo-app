namespace Cargo.Application.Contracts.Percistance;

public interface IGenericRepository<T>
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task SaveChangesAsync();
}