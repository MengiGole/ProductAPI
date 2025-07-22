using ProductApi.Application.DTOs.ProductCategory;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProductApi.Application.Interfaces
{
    public interface IProductCategoryService
    {
        Task<ProductCategoryReadDto> CreateAsync(ProductCategoryCreateDto dto);
        Task<IEnumerable<ProductCategoryReadDto>> GetAllAsync();
        Task<ProductCategoryReadDto> GetByIdAsync(int id);
        Task<ProductCategoryReadDto> UpdateAsync(int id, ProductCategoryUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
