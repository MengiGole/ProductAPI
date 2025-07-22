using ProductApi.Application.DTOs.ProductGroup;
using ProductApi.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApi.Application.Services
{
    public class ProductGroupService : IProductGroupService
    {
        public Task<ProductGroupReadDto> CreateAsync(ProductGroupCreateDto dto)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ProductGroupReadDto>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductGroupReadDto> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductGroupReadDto> UpdateAsync(int id, ProductGroupUpdateDto dto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
