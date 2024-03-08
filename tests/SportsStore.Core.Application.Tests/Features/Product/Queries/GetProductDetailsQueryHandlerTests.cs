using SportsStore.Core.Application.Tests.Moqs;

namespace SportsStore.Core.Application.Tests.Features.Product.Queries;

public class GetProductDetailsQueryHandlerTests
{
    private readonly Mock<IProductRepository> _mockRepo;
    private readonly IMapper _mapper;

    public GetProductDetailsQueryHandlerTests()
    {
        _mockRepo = MockProductRepository.GetMockRepository();

        var mapperConfig = new MapperConfiguration(c => c.AddProfile<ProductProfile>());
        _mapper = mapperConfig.CreateMapper();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    public async Task GetProductByIdSuccessTest(int id)
    {
        // arrange
        var handler = new GetProductDetailsQueryHandler(_mapper, _mockRepo.Object);

        // act
        var result = await handler.Handle(new GetProductDetailsQuery(id), CancellationToken.None);

        // assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<ProductDetailsDto>();
        result.Id.ShouldBe(id);
    }

    [Theory]
    [InlineData(11)]
    [InlineData(22)]
    [InlineData(59)]
    public void GetProductByIdNotFoundTest(int id)
    {
        // arrange
        var handler = new GetProductDetailsQueryHandler(_mapper, _mockRepo.Object);

        // act & assert
        Should.Throw<NotFoundException>(async () => await handler.Handle(new GetProductDetailsQuery(id), CancellationToken.None));
    }
}
