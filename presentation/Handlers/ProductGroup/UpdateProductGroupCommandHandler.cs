using MediatR;
using ProductApi.Application.Commands.ProductGroup;
using ProductApi.Application.DTOs.ProductGroup;
using AutoMapper;
using infrastructure.Data;
using domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProductApi.Application.Handlers.ProductGroup
{
    public class UpdateProductGroupCommandHandler : IRequestHandler<UpdateProductGroupCommand, ProductGroupReadDto>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UpdateProductGroupCommandHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductGroupReadDto> Handle(UpdateProductGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductGroups.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null) return null;
            _mapper.Map(request.Dto, entity);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ProductGroupReadDto>(entity);
        }
    }
}