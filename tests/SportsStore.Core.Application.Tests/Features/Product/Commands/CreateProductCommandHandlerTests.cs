using SportsStore.Core.Application.Tests.Moqs;

namespace SportsStore.Core.Application.Tests.Features.Product.Commands;

public class CreateProductCommandHandlerTests
{
    private readonly Mock<IProductRepository> _mockRepo;
    private readonly IMapper _mapper;

    public CreateProductCommandHandlerTests()
    {
        _mockRepo = MockProductRepository.GetMockRepository();

        var mapperConfig = new MapperConfiguration(c => c.AddProfile<ProductProfile>());
        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task CreateProductSuccessTest()
    {
        // arrange
        var handler = new CreateProductCommandHandler(_mapper, _mockRepo.Object);
        var request = new CreateProductCommand
        {
            Name = "New Product",
            Description = "Description",
            Category = "Category",
            Price = 12.32M,
        };

        // act
        var result = await handler.Handle(request, CancellationToken.None);

        // assert
        result.ShouldBeOfType<int>();
        result.ShouldBeGreaterThan(0);
    }

    [Fact]
    public void CreateProductBadResquestTest()
    {
        // arrange
        var handler = new CreateProductCommandHandler(_mapper, _mockRepo.Object);
        var request = new CreateProductCommand
        {
            Name = "New Product",
            Price = 0,
        };

        // act & assert
        Should.Throw<BadRequestException>(async () => await handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public void CreateProductNameNotUniqueBadResquestTest()
    {
        // arrange
        var handler = new CreateProductCommandHandler(_mapper, _mockRepo.Object);
        var request = new CreateProductCommand
        {
            Name = "Product 1",
            Description = "Description",
            Category = "Category",
            Price = 12.32M,
        };

        // act & assert
        Should.Throw<BadRequestException>(async () => await handler.Handle(request, CancellationToken.None));
    }
}
