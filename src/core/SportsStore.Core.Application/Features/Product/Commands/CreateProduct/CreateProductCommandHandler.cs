using AutoMapper;
using MediatR;
using SportsStore.Core.Application.Contracts.Persistance;
using SportsStore.Core.Application.Exceptions;

namespace SportsStore.Core.Application.Features.Product.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // validate incoming data
        var validator = new CreateProductCommandValidator(_productRepository);

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid product data", validationResult);
        }

        // convert dto to entity
        var productToCreate = _mapper.Map<Domain.Product>(request);

        // impact the database
        await _productRepository.CreateAsync(productToCreate);

        // return identifier
        return productToCreate.Id;
    }
}
