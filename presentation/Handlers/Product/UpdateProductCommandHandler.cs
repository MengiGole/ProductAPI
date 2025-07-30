using MediatR;
using ProductApi.Application.Commands.Product;
using ProductApi.Application.DTOs.Product;
using ProductApi.Domain.Interfaces;

namespace ProductApi.Application.Handlers.Product
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductReadDto>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductReadDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null) return null;

            product.Name = request.ProductUpdateDto.Name;
            product.SKU = request.ProductUpdateDto.SKU;
            product.CategoryId = request.ProductUpdateDto.CategoryId;

            var updated = await _productRepository.UpdateAsync(product);
            return new ProductReadDto 
            { 
                Id = updated.Id, 
                Name = updated.Name, 
                SKU = updated.SKU,
                CategoryId = updated.CategoryId,
                Price = request.ProductUpdateDto.Price,
                Stock = request.ProductUpdateDto.Stock,
                Description = request.ProductUpdateDto.Description,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
} 