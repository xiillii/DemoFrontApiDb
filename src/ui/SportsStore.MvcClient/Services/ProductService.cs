using AutoMapper;
using SportsStore.MvcClient.Contracts;
using SportsStore.MvcClient.Models.Products;
using SportsStore.MvcClient.Services.Base;

namespace SportsStore.MvcClient.Services;

public class ProductService : BaseHttpService, IProductService
{
    private readonly IMapper _mapper;

    public ProductService(IClient client, IMapper mapper) : base(client)
    {
        _mapper = mapper;
    }

    public async Task<Response<int>> CreateProduct(ProductViewModel product)
    {
        try
        {
            var createProductCommand = _mapper.Map<CreateProductCommand>(product);

            // TODO: implement the ID in the result
            await _client.ProductsPOSTAsync(createProductCommand);

            return new Response<int>
            {
                Success = true,                
            };
        }
        catch (ApiException ex)
        {

            return ConvertApiExceptions<int>(ex);
        }


        
    }

    public async Task<Response> DeleteProduct(int id)
    {
        try
        {
            await _client.ProductsDELETEAsync(id);
            return new Response
            {
                Success = true,
            };
        }
        catch (ApiException ex)
        {

            return ConvertApiExceptions(ex);
        }
    }

    public async Task<ProductViewModel> GetProduct(int id)
    {
        var product = await _client.ProductsGETAsync(id);

        return _mapper.Map<ProductViewModel>(product);
    }

    public async Task<List<ProductViewModel>> GetProducts()
    {
        var products = await _client.ProductsAllAsync();

        return _mapper.Map<List<ProductViewModel>>(products);
    }
}
