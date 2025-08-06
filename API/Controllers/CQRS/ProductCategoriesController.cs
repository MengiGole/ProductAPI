using Microsoft.AspNetCore.Mvc;
using MediatR;
using ProductApi.Application.Commands.ProductCategory;
using ProductApi.Application.Queries.ProductCategory;
using ProductApi.Application.DTOs.ProductCategory;

namespace ProductApi.Controllers.CQRS
{
    [ApiController]
    [Route("api/cqrs/[controller]")]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCategoryCreateDto dto)
        {
            var command = new CreateProductCategoryCommand(dto);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProductCategoriesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProductCategoryByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductCategoryUpdateDto dto)
        {
            var command = new UpdateProductCategoryCommand(id, dto);
            var result = await _mediator.Send(command);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProductCategoryCommand(id);
            var success = await _mediator.Send(command);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}