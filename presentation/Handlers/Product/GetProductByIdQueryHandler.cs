using MediatR;
using ProductApi.Application.DTOs.Product;
using ProductApi.Application.Queries.Product;
using ProductApi.Domain.Interfaces;

namespace ProductApi.Application.Handlers.Product
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductReadDto>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductReadDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null) return null;

            return new ProductReadDto 
            { 
                Id = product.Id, 
                Name = product.Name, 
                SKU = product.SKU,
                CategoryId = product.CategoryId,
                Price = 0, // TODO: Add price to Product entity
                Stock = 0, // TODO: Add stock to Product entity
                Description = "", // TODO: Add description to Product entity
                CreatedAt = DateTime.UtcNow
            };
        }
    }
} 