using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsStore.Core.Domain;

namespace SportsStore.Infrastructure.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(
            new Product
            {
                Id = 1,
                Name = "Kayak",
                Description = "A boat for one person",
                Category = "Watersports",
                Price = 123.23M,
            },
            new Product
            {
                Id = 2,
                Name = "Lifejacket",
                Description = "Protective and fashionable",
                Category = "Watersports",
                Price = 48M,
            },
            new Product
            {
                Id = 3,
                Name = "Corneer flags",
                Description = "Giving your playing field that professional touch",
                Category = "Soccer",
                Price = 34.23M,
            }
        );

        builder.Property(p => p.Name).IsRequired().HasMaxLength(70);
        builder.Property(p => p.Category).IsRequired().HasMaxLength(70);
        builder.Property(p => p.Price).IsRequired();
    }
}
