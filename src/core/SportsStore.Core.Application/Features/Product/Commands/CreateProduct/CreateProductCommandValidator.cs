using FluentValidation;
using SportsStore.Core.Application.Contracts.Persistance;

namespace SportsStore.Core.Application.Features.Product.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandValidator(IProductRepository productRepository)
    {
        _productRepository = productRepository;

        RuleFor(p => p.Name).NotNull()
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .MaximumLength(70)
            .WithMessage("{PropertyName} must be fewer than 70 characters");
        RuleFor(p => p).MustAsync(IsNameUnique)
            .WithMessage("Product name already exists");
        RuleFor(p => p.Category).NotNull()
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .MaximumLength(70)
            .WithMessage("{PropertyName} must be fewer than 70 characters");
        RuleFor(p => p.Price).NotNull()
            .WithMessage("{PropertyName} is required")
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greather than Zero");
    }

    private async Task<bool> IsNameUnique(CreateProductCommand command, CancellationToken cancellationToken)
    {
        return await _productRepository.IsProductUnique(command.Name);
    }
}
