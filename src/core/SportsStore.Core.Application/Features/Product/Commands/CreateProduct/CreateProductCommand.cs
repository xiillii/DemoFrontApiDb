﻿using MediatR;

namespace SportsStore.Core.Application.Features.Product.Commands.CreateProduct;

public class CreateProductCommand : IRequest<int>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public decimal Price { get; set; } = decimal.Zero;
}
