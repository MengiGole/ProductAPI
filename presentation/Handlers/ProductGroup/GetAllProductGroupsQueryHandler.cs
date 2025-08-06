using MediatR;
using ProductApi.Application.Queries.ProductGroup;
using ProductApi.Application.DTOs.ProductGroup;
using AutoMapper;
using infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ProductApi.Application.Handlers.ProductGroup
{
    public class GetAllProductGroupsQueryHandler : IRequestHandler<GetAllProductGroupsQuery, IEnumerable<ProductGroupReadDto>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllProductGroupsQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductGroupReadDto>> Handle(GetAllProductGroupsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context.ProductGroups.ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<ProductGroupReadDto>>(entities);
        }
    }
}