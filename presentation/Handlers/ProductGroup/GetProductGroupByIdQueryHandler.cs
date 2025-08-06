using MediatR;
using ProductApi.Application.Queries.ProductGroup;
using ProductApi.Application.DTOs.ProductGroup;
using AutoMapper;
using infrastructure.Data;

namespace ProductApi.Application.Handlers.ProductGroup
{
    public class GetProductGroupByIdQueryHandler : IRequestHandler<GetProductGroupByIdQuery, ProductGroupReadDto>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public GetProductGroupByIdQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductGroupReadDto> Handle(GetProductGroupByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductGroups.FindAsync(new object[] { request.Id }, cancellationToken);
            return entity == null ? null : _mapper.Map<ProductGroupReadDto>(entity);
        }
    }
}