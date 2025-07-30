using MediatR;
using ProductApi.Application.DTOs.Product;
using ProductApi.Application.Queries.Product;
using ProductApi.Domain.Interfaces;
using System.Linq;

namespace ProductApi.Application.Handlers.Product
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductReadDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductReadDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => new ProductReadDto 
            { 
                Id = p.Id, 
                Name = p.Name, 
                SKU = p.SKU,
                CategoryId = p.CategoryId,
                Price = 0, // TODO: Add price to Product entity
                Stock = 0, // TODO: Add stock to Product entity
                Description = "", // TODO: Add description to Product entity
                CreatedAt = DateTime.UtcNow
            });
        }
    }
} 