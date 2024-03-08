using MediatR;

namespace SportsStore.Core.Application.Features.Product.Commands.DeleteProduct;

public record DeleteProductCommand(int Id) : IRequest<Unit>;

