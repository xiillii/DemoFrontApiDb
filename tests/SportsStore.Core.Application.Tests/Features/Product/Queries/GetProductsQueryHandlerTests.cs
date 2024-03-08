using SportsStore.Core.Application.Tests.Moqs;

namespace SportsStore.Core.Application.Tests.Features.Product.Queries;

public class GetProductsQueryHandlerTests
{
    private readonly Mock<IProductRepository> _mockRepo;
    private readonly IMapper _mapper;

    public GetProductsQueryHandlerTests()
    {
        _mockRepo = MockProductRepository.GetMockRepository();

        var mapperConfig = new MapperConfiguration(c => c.AddProfile<ProductProfile>());
        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetProductsTest()
    {
        // arrange
        var handler = new GetProductsQueryHandler(_mapper, _mockRepo.Object);

        // act
        var result = await handler.Handle(new GetProductsQuery(), CancellationToken.None);

        // assert
        result.ShouldBeOfType<List<ProductDto>>();
        result.Count.ShouldBe(6);
    }
}
