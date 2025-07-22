using ProductApi.Application.DTOs.Product;
using ProductApi.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApi.Application.Services
{
    public class ProductService : IProductService
    {
        public Task<ProductReadDto> CreateAsync(ProductCreateDto dto)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ProductReadDto>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductReadDto> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductReadDto> UpdateAsync(int id, ProductUpdateDto dto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
