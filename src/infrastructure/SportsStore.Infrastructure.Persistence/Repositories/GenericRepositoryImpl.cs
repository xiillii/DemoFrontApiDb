using Microsoft.EntityFrameworkCore;
using SportsStore.Core.Application.Contracts.Persistance;
using SportsStore.Core.Domain.Common;
using SportsStore.Infrastructure.Persistence.DatabaseContext;

namespace SportsStore.Infrastructure.Persistence.Repositories;

public class GenericRepositoryImpl<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly EFDatabaseContext _context;

    public GenericRepositoryImpl(EFDatabaseContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        var res = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        return res;
    }
}
