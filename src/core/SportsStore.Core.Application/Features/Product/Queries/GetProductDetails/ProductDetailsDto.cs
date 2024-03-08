namespace SportsStore.Core.Application.Features.Product.Queries.GetProductDetails;

public class ProductDetailsDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public decimal Price { get; set; }

    public DateTimeOffset? DateCreated { get; set; }
    public DateTimeOffset? DateModified { get; set; }
}
