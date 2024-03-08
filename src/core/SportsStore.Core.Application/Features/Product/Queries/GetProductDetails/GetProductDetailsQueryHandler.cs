using AutoMapper;
using MediatR;
using SportsStore.Core.Application.Contracts.Persistance;
using SportsStore.Core.Application.Exceptions;

namespace SportsStore.Core.Application.Features.Product.Queries.GetProductDetails;

public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, ProductDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetProductDetailsQueryHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<ProductDetailsDto> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
    {
        // query database
        var product = await _productRepository.GetByIdAsync(request.Id) 
            ?? throw new NotFoundException(nameof(Domain.Product), request.Id);

        // convert object to dto
        var data = _mapper.Map<ProductDetailsDto>(product);

        // return result
        return data;
    }
}
