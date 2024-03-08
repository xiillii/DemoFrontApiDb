using AutoMapper;
using SportsStore.MvcClient.Models.Products;
using SportsStore.MvcClient.Services.Base;

namespace SportsStore.MvcClient.MappingProfiles
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<ProductDto, ProductViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, ProductViewModel>().ReverseMap();
        }
    }
}
