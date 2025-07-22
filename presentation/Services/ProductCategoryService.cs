using ProductApi.Application.DTOs.ProductCategory;
using ProductApi.Application.Interfaces;
using ProductApi.Domain.Interfaces;

namespace ProductApi.Application.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        public Task<ProductCategoryReadDto> CreateAsync(ProductCategoryCreateDto dto)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ProductCategoryReadDto>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductCategoryReadDto> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductCategoryReadDto> UpdateAsync(int id, ProductCategoryUpdateDto dto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
