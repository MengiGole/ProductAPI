using ProductApi.Application.DTOs.Product;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProductApi.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductReadDto> CreateAsync(ProductCreateDto dto);
        Task<IEnumerable<ProductReadDto>> GetAllAsync();
        Task<ProductReadDto> GetByIdAsync(int id);
        Task<ProductReadDto> UpdateAsync(int id, ProductUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
