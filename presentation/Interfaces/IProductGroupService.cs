using ProductApi.Application.DTOs.ProductGroup;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProductApi.Application.Interfaces
{
    public interface IProductGroupService
    {
        Task<ProductGroupReadDto> CreateAsync(ProductGroupCreateDto dto);
        Task<IEnumerable<ProductGroupReadDto>> GetAllAsync();
        Task<ProductGroupReadDto> GetByIdAsync(int id);
        Task<ProductGroupReadDto> UpdateAsync(int id, ProductGroupUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
