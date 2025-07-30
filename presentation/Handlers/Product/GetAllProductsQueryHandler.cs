using MediatR;
using ProductApi.Application.DTOs.Product;
using ProductApi.Application.Queries.Product;
using ProductApi.Domain.Interfaces;
using AutoMapper;

namespace ProductApi.Application.Handlers.Product
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductReadDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductReadDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductReadDto>>(products);
        }
    }
} 