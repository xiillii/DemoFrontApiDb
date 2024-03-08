using AutoMapper;
using SportsStore.Core.Application.Features.Product.Commands.CreateProduct;
using SportsStore.Core.Application.Features.Product.Queries.GetProductDetails;
using SportsStore.Core.Application.Features.Product.Queries.GetProducts;
using SportsStore.Core.Domain;

namespace SportsStore.Core.Application.MappingProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductDto, Product>().ReverseMap();
        CreateMap<Product, ProductDetailsDto>();

        CreateMap<CreateProductCommand, Product>();
    }
}
