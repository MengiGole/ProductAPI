using MediatR;
using ProductApi.Application.Commands.Product;
using ProductApi.Application.DTOs.Product;
using ProductApi.Domain.Interfaces;
using domain.Entities;

namespace ProductApi.Application.Handlers.Product
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductReadDto>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductReadDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new domain.Entities.Product  // Use fully qualified name to avoid namespace conflict
            {
                Name = request.ProductCreateDto.Name,
                SKU = request.ProductCreateDto.SKU,
                CategoryId = request.ProductCreateDto.CategoryId,
                ProductGroupId = request.ProductCreateDto.ProductGroupId
            };

            var created = await _productRepository.AddAsync(product);

            return new ProductReadDto
            {
                Id = created.Id,
                Name = created.Name,
                SKU = created.SKU,
                CategoryId = created.CategoryId,
                Price = request.ProductCreateDto.Price,
                Stock = request.ProductCreateDto.Stock,
                Description = request.ProductCreateDto.Description,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}