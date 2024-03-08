using Microsoft.EntityFrameworkCore;
using SportsStore.Core.Application.Contracts.Persistance;
using SportsStore.Core.Domain;
using SportsStore.Infrastructure.Persistence.DatabaseContext;

namespace SportsStore.Infrastructure.Persistence.Repositories;

public class ProductRepositoryImpl : GenericRepositoryImpl<Product>, IProductRepository
{
    public ProductRepositoryImpl(EFDatabaseContext context) : base(context)
    {
        
    }

    public async Task<bool> IsProductUnique(string name)
    {
        var notUnique = await _context.Products.AnyAsync(p => p.Name == name);

        return !notUnique;
    }
}
