namespace SportsStore.Core.Application.Tests.Moqs;

public class MockProductRepository
{
    public static Mock<IProductRepository> GetMockRepository()
    {
        var products = new List<Product>
        {
            new Product { 
                Id = 1,
                Name = "Product 1",
                Description = "Description 1",
                Category = "Category 1",
                Price = 1,
            },
            new Product {
                Id = 2,
                Name = "Product 2",
                Description = "Description 2",
                Category = "Category 1",
                Price = 2,
            },
            new Product {
                Id = 3,
                Name = "Product 3",
                Description = "Description 3",
                Category = "Category 2",
                Price = 3,
            },
            new Product {
                Id = 4,
                Name = "Product 4",
                Description = "Description 4",
                Category = "Category 3",
                Price = 1,
            },
            new Product {
                Id = 5,
                Name = "Product 5",
                Description = "Description 5",
                Category = "Category 3",
                Price = 12,
            },
            new Product {
                Id = 6,
                Name = "Product 6",
                Description = "Description 6",
                Category = "Category 3",
                Price = 23.21M,
            },
        };

        var mockRepo = new Mock<IProductRepository>();

        mockRepo.Setup(pr => pr.GetAsync()).Returns(async () =>
        {
            return await Task.FromResult(products);
        });

        mockRepo.Setup(pr => pr.GetByIdAsync(It.IsAny<int>())).Returns((int id) =>
        {
            return Task.FromResult(products.Find(p => p.Id == id));
        });

        mockRepo.Setup(pr => pr.IsProductUnique(It.IsAny<string>())).Returns((string name) =>
        {
            var item = products.Find(p => p.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));

            return Task.FromResult(item == null);
        });

        mockRepo.Setup(pr => pr.CreateAsync(It.IsAny<Product>())).Returns((Product product) =>
        {
            var id = products.OrderBy(p => p.Id).First()?.Id ?? 0 + 1;

            product.Id = id;
            products.Add(product);

            return Task.FromResult(id);
        });

        mockRepo.Setup(pr => pr.DeleteAsync(It.IsAny<Product>())).Returns((Product product) =>
        {
            products.Remove(product);

            return Task.CompletedTask;
        });



        return mockRepo;
    }
}
