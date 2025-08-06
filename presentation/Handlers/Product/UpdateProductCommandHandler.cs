using AutoMapper;
using MediatR;
using ProductApi.Application.Commands.Product;
using ProductApi.Application.DTOs.Product;
using ProductApi.Domain.Interfaces;

namespace ProductApi.Application.Handlers.Product
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductReadDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductReadDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null) return null;

            // Map the update DTO into the existing product entity
            _mapper.Map(request.ProductUpdateDto, product);

            var updated = await _productRepository.UpdateAsync(product);

            // Map updated product entity to the read DTO
            var productReadDto = _mapper.Map<ProductReadDto>(updated);

            return productReadDto;
        }
    }
}
