using MediatR;
using ProductApi.Application.DTOs.Product;
using ProductApi.Application.Queries.Product;
using ProductApi.Domain.Interfaces;
using AutoMapper;

namespace ProductApi.Application.Handlers.Product
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductReadDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductReadDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null) return null;

            return _mapper.Map<ProductReadDto>(product);
        }
    }
} 