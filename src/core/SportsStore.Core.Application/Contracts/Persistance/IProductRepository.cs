using SportsStore.Core.Domain;

namespace SportsStore.Core.Application.Contracts.Persistance;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<bool> IsProductUnique(string name);
}