using MediatR;
using ProductApi.Application.Queries.ProductCategory;
using ProductApi.Application.DTOs.ProductCategory;
using AutoMapper;
using infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ProductApi.Application.Handlers.ProductCategory
{
    public class GetAllProductCategoriesQueryHandler : IRequestHandler<GetAllProductCategoriesQuery, IEnumerable<ProductCategoryReadDto>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllProductCategoriesQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductCategoryReadDto>> Handle(GetAllProductCategoriesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context.ProductCategories.ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<ProductCategoryReadDto>>(entities);
        }
    }
}