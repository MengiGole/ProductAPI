using ProductApi.Application.DTOs.Product;
using ProductApi.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductApi.Domain.Interfaces;
using System.Linq;

namespace ProductApi.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductReadDto> CreateAsync(ProductCreateDto dto)
        {
            var product = new Product
            {
                CategoryId = dto.CategoryId,
                Name = dto.Name!,
                SKU = dto.SKU!,
                // Add other properties as needed
            };
            var created = await _productRepository.AddAsync(product);
            return new ProductReadDto
            {
                Id = created.Id,
                CategoryId = created.CategoryId,
                Name = created.Name,
                SKU = created.SKU
                // Map other properties as needed
            };
        }

        public async Task<IEnumerable<ProductReadDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => new ProductReadDto
            {
                Id = p.Id,
                CategoryId = p.CategoryId,
                Name = p.Name,
                SKU = p.SKU
                // Map other properties as needed
            });
        }

        public async Task<ProductReadDto> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return null;
            return new ProductReadDto
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                Name = product.Name,
                SKU = product.SKU
                // Map other properties as needed
            };
        }

        public async Task<ProductReadDto> UpdateAsync(int id, ProductUpdateDto dto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return null;
            product.CategoryId = dto.CategoryId;
            product.Name = dto.Name!;
            product.SKU = dto.SKU!;
            // Update other properties as needed
            var updated = await _productRepository.UpdateAsync(product);
            return new ProductReadDto
            {
                Id = updated.Id,
                CategoryId = updated.CategoryId,
                Name = updated.Name,
                SKU = updated.SKU
                // Map other properties as needed
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }
    }
}
