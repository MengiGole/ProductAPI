using MediatR;
using ProductApi.Application.Commands.ProductCategory;
using infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ProductApi.Application.Handlers.ProductCategory
{
    public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand, bool>
    {
        private readonly AppDbContext _context;
        public DeleteProductCategoryCommandHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductCategories.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null) return false;
            _context.ProductCategories.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}