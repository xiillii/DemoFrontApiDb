using SportsStore.Core.Domain.Common;

namespace SportsStore.Core.Domain;

public class Product : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public decimal Price { get; set; }
}
