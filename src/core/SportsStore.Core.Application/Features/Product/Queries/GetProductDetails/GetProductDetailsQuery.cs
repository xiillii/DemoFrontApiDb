using MediatR;

namespace SportsStore.Core.Application.Features.Product.Queries.GetProductDetails;

public record GetProductDetailsQuery(int Id) : IRequest<ProductDetailsDto>;
