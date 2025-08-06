using MediatR;
using ProductApi.Application.Commands.ProductGroup;
using ProductApi.Application.DTOs.ProductGroup;
using AutoMapper;
using infrastructure.Data;
using domain.Entities;

namespace ProductApi.Application.Handlers.ProductGroup
{
    public class CreateProductGroupCommandHandler : IRequestHandler<CreateProductGroupCommand, ProductGroupReadDto>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateProductGroupCommandHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductGroupReadDto> Handle(CreateProductGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<domain.Entities.ProductGroup>(request.Dto);  // Use fully qualified name
            _context.ProductGroups.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ProductGroupReadDto>(entity);
        }
    }
}