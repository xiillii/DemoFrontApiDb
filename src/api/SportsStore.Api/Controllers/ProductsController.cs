using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Core.Application.Features.Product.Commands.CreateProduct;
using SportsStore.Core.Application.Features.Product.Commands.DeleteProduct;
using SportsStore.Core.Application.Features.Product.Queries.GetProductDetails;
using SportsStore.Core.Application.Features.Product.Queries.GetProducts;

namespace SportsStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<ProductDto>>> GetList()
        {
            var products = await _mediator.Send(new GetProductsQuery());

            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ProductDetailsDto>> GetProductDetails(int id)
        {
            var product = await _mediator.Send(new GetProductDetailsQuery(id));

            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> CreateProduct(CreateProductCommand request)
        {
            var response = await _mediator.Send(request);

            return CreatedAtAction(nameof(GetProductDetails), new { id = response }, null);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _mediator.Send(new DeleteProductCommand(id));

            return Ok();
        }
    }
}
