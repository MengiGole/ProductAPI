using Microsoft.AspNetCore.Mvc;
using MediatR;
using ProductApi.Application.Commands.Product;
using ProductApi.Application.Queries.Product;
using ProductApi.Application.DTOs.Product;

namespace ProductApi.Controllers.CQRS
{
    [ApiController]
    [Route("api/cqrs/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto dto)
        {
            var command = new CreateProductCommand(dto);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProductsQuery();
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProductByIdQuery(id);
            var product = await _mediator.Send(query);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductUpdateDto dto)
        {
            var command = new UpdateProductCommand(id, dto);
            var product = await _mediator.Send(command);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand(id);
            var success = await _mediator.Send(command);
            if (!success) return NotFound();
            return NoContent();
        }
    }
} 