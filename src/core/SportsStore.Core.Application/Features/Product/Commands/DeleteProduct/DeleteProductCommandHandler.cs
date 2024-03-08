using MediatR;
using SportsStore.Core.Application.Contracts.Persistance;
using SportsStore.Core.Application.Exceptions;

namespace SportsStore.Core.Application.Features.Product.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        // Get the database
        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product == null)
        {
            throw new NotFoundException(nameof(Domain.Product), request.Id);
        }

        // impact the database
        await _productRepository.DeleteAsync(product);

        return Unit.Value;
    }
}
