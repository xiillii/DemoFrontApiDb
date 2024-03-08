using Microsoft.EntityFrameworkCore;
using SportsStore.Core.Domain;
using SportsStore.Core.Domain.Common;

namespace SportsStore.Infrastructure.Persistence.DatabaseContext;

public class EFDatabaseContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public EFDatabaseContext(DbContextOptions<EFDatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDatabaseContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>().Where(e => e.State is EntityState.Added or EntityState.Modified))
        {
            entry.Entity.DateModified = DateTime.UtcNow;

            if (entry.State is EntityState.Added)
            {
                entry.Entity.DateCreated = DateTime.UtcNow;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
