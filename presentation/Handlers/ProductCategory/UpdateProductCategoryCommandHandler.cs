using MediatR;
using ProductApi.Application.Commands.ProductCategory;
using ProductApi.Application.DTOs.ProductCategory;
using AutoMapper;
using infrastructure.Data;
using domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProductApi.Application.Handlers.ProductCategory
{
    public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand, ProductCategoryReadDto>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UpdateProductCategoryCommandHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductCategoryReadDto> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductCategories.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null) return null;
            _mapper.Map(request.Dto, entity);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ProductCategoryReadDto>(entity);
        }
    }
}