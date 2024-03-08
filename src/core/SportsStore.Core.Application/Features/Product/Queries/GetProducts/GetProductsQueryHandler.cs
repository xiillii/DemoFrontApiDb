using AutoMapper;
using MediatR;
using SportsStore.Core.Application.Contracts.Persistance;

namespace SportsStore.Core.Application.Features.Product.Queries.GetProducts;

public class GetProductsQueryHandler(IMapper mapper,
                                     IProductRepository productRepository) 
    : IRequestHandler<GetProductsQuery, List<ProductDto>>
{
    private readonly IMapper _mapper = mapper;
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var products = await _productRepository.GetAsync();

        // convert data object to DTO
        var data = _mapper.Map<List<ProductDto>>(products);

        // return the results
        return data;
    }
}
