using MediatR;

namespace SportsStore.Core.Application.Features.Product.Queries.GetProducts;

public record GetProductsQuery : IRequest<List<ProductDto>>;

