using System.Linq;
using ProductApi.Application.DTOs.ProductCategory;
using ProductApi.Application.Interfaces;
using ProductApi.Domain.Interfaces;

namespace ProductApi.Application.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _categoryRepository;
        public ProductCategoryService(IProductCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ProductCategoryReadDto> CreateAsync(ProductCategoryCreateDto dto)
        {
            var category = new ProductCategory
            {
                GroupId = dto.GroupId,
                Name = dto.Name!,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow
            };
            var created = await _categoryRepository.AddAsync(category);
            return new ProductCategoryReadDto
            {
                Id = created.Id,
                GroupId = created.GroupId,
                Name = created.Name,
                Description = created.Description,
                CreatedAt = created.CreatedAt
            };
        }

        public async Task<IEnumerable<ProductCategoryReadDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(c => new ProductCategoryReadDto
            {
                Id = c.Id,
                GroupId = c.GroupId,
                Name = c.Name,
                Description = c.Description,
                CreatedAt = c.CreatedAt
            });
        }

        public async Task<ProductCategoryReadDto> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return null;
            return new ProductCategoryReadDto
            {
                Id = category.Id,
                GroupId = category.GroupId,
                Name = category.Name,
                Description = category.Description,
                CreatedAt = category.CreatedAt
            };
        }

        public async Task<ProductCategoryReadDto> UpdateAsync(int id, ProductCategoryUpdateDto dto)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return null;
            category.GroupId = dto.GroupId;
            category.Name = dto.Name!;
            category.Description = dto.Description;
            var updated = await _categoryRepository.UpdateAsync(category);
            return new ProductCategoryReadDto
            {
                Id = updated.Id,
                GroupId = updated.GroupId,
                Name = updated.Name,
                Description = updated.Description,
                CreatedAt = updated.CreatedAt
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _categoryRepository.DeleteAsync(id);
        }
    }
}
