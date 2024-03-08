using SportsStore.Core.Application.Features.Product.Commands.DeleteProduct;
using SportsStore.Core.Application.Tests.Moqs;

namespace SportsStore.Core.Application.Tests.Features.Product.Commands;

public class DeleteProductCommandHandlerTests
{
    private readonly Mock<IProductRepository> _mockRepo;
    private readonly IMapper _mapper;

    public DeleteProductCommandHandlerTests()
    {
        _mockRepo = MockProductRepository.GetMockRepository();

        var mapperConfig = new MapperConfiguration(c => c.AddProfile<ProductProfile>());
        _mapper = mapperConfig.CreateMapper();
    }

    [Theory]
    [InlineData(1)]
    public async Task DeleteProductSuccessTest(int id)
    {
        // arrange
        var handler = new DeleteProductCommandHandler(_mockRepo.Object);

        // act
        await handler.Handle(new DeleteProductCommand(id), CancellationToken.None);
    }

    [Theory]
    [InlineData(100)]
    public void DeleteProductNotFoundTest(int id)
    {
        // arrange
        var handler = new DeleteProductCommandHandler(_mockRepo.Object);

        // act
        Should.Throw<NotFoundException>(async () => await handler.Handle(new DeleteProductCommand(id), CancellationToken.None));
    }
}
