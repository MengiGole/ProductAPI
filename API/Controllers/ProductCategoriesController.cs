using Microsoft.AspNetCore.Mvc;
using ProductApi.Application.Interfaces;
using ProductApi.Application.DTOs.ProductCategory;
using System.Threading.Tasks;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoryService _service;
        public ProductCategoriesController(IProductCategoryService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCategoryCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _service.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _service.GetByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductCategoryUpdateDto dto)
        {
            var category = await _service.UpdateAsync(id, dto);
            if (category == null) return NotFound();
            return Ok(category);
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