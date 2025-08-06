using MediatR;
using ProductApi.Application.Commands.ProductCategory;
using ProductApi.Application.DTOs.ProductCategory;
using AutoMapper;
using infrastructure.Data;
using domain.Entities;

namespace application.Handlers.ProductCategory
{
    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, ProductCategoryReadDto>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateProductCategoryCommandHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductCategoryReadDto> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<domain.Entities.ProductCategory>(request.Dto);
            _context.ProductCategories.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ProductCategoryReadDto>(entity);
        }
    }
}