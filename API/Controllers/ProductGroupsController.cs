using Microsoft.AspNetCore.Mvc;
using ProductApi.Application.Interfaces;
using ProductApi.Application.DTOs.ProductGroup;
using System.Threading.Tasks;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductGroupsController : ControllerBase
    {
        private readonly IProductGroupService _service;
        public ProductGroupsController(IProductGroupService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductGroupCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var groups = await _service.GetAllAsync();
            return Ok(groups);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var group = await _service.GetByIdAsync(id);
            if (group == null) return NotFound();
            return Ok(group);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductGroupUpdateDto dto)
        {
            var group = await _service.UpdateAsync(id, dto);
            if (group == null) return NotFound();
            return Ok(group);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
} 