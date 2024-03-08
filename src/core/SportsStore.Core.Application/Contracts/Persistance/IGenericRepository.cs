namespace SportsStore.Core.Application.Contracts.Persistance;

public interface IGenericRepository<T> where T : class
{
    Task<IReadOnlyList<T>> GetAsync();
    Task<T?> GetByIdAsync(int id);
    Task CreateAsync(T entity);    
    Task DeleteAsync(T entity);
}