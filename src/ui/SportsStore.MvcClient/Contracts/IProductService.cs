using SportsStore.MvcClient.Models.Products;
using SportsStore.MvcClient.Services.Base;

namespace SportsStore.MvcClient.Contracts;

public interface IProductService
{
    Task<List<ProductViewModel>> GetProducts();
    Task<ProductViewModel> GetProduct(int id);
    Task<Response<int>> CreateProduct(ProductViewModel product);
    Task<Response> DeleteProduct(int id);
}
