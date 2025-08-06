using MediatR;
using ProductApi.Application.Commands.ProductGroup;
using infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ProductApi.Application.Handlers.ProductGroup
{
    public class DeleteProductGroupCommandHandler : IRequestHandler<DeleteProductGroupCommand, bool>
    {
        private readonly AppDbContext _context;
        public DeleteProductGroupCommandHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteProductGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductGroups.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null) return false;
            _context.ProductGroups.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}