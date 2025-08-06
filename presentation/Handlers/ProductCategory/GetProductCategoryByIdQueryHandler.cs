using MediatR;
using ProductApi.Application.Queries.ProductCategory;
using ProductApi.Application.DTOs.ProductCategory;
using AutoMapper;
using infrastructure.Data;

namespace ProductApi.Application.Handlers.ProductCategory
{
    public class GetProductCategoryByIdQueryHandler : IRequestHandler<GetProductCategoryByIdQuery, ProductCategoryReadDto>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public GetProductCategoryByIdQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductCategoryReadDto> Handle(GetProductCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductCategories.FindAsync(new object[] { request.Id }, cancellationToken);
            return entity == null ? null : _mapper.Map<ProductCategoryReadDto>(entity);
        }
    }
}