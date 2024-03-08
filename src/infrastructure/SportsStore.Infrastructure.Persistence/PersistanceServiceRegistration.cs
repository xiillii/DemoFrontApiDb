using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.Core.Application.Contracts.Persistance;
using SportsStore.Infrastructure.Persistence.DatabaseContext;
using SportsStore.Infrastructure.Persistence.Repositories;

namespace SportsStore.Infrastructure.Persistence;

public static class PersistanceServiceRegistration
{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EFDatabaseContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DbConnectionString"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepositoryImpl<>));
        services.AddScoped<IProductRepository, ProductRepositoryImpl>();

        return services;
    }
}
