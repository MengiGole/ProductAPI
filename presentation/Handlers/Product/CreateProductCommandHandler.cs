using AutoMapper;
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
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductReadDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // Map from DTO to Entity
            var productEntity = _mapper.Map<domain.Entities.Product>(request.ProductCreateDto);


            // Save to database
            var createdProduct = await _productRepository.AddAsync(productEntity);

            // Map Entity back to ReadDto
            var productReadDto = _mapper.Map<ProductReadDto>(createdProduct);

            return productReadDto;
        }
    }
}
