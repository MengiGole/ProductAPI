using Microsoft.AspNetCore.Mvc;
using MediatR;
using ProductApi.Application.Commands.ProductGroup;
using ProductApi.Application.Queries.ProductGroup;
using ProductApi.Application.DTOs.ProductGroup;

namespace ProductApi.Controllers.CQRS
{
    [ApiController]
    [Route("api/cqrs/[controller]")]
    public class ProductGroupsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductGroupsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductGroupCreateDto dto)
        {
            var command = new CreateProductGroupCommand(dto);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProductGroupsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProductGroupByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductGroupUpdateDto dto)
        {
            var command = new UpdateProductGroupCommand(id, dto);
            var result = await _mediator.Send(command);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProductGroupCommand(id);
            var success = await _mediator.Send(command);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}