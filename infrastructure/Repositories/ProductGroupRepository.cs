using ProductApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using domain.Entities;
using infrastructure.Data;

namespace ProductApi.Infrastructure.Repositories
{
    public class ProductGroupRepository : IProductGroupRepository
    {
        private readonly AppDbContext _context;
        public ProductGroupRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductGroup> AddAsync(ProductGroup group)
        {
            _context.ProductGroups.Add(group);
            await _context.SaveChangesAsync();
            return group;
        }

        public async Task<ProductGroup> GetByIdAsync(int id)
        {
            return await _context.ProductGroups.FindAsync(id);
        }

        public async Task<IEnumerable<ProductGroup>> GetAllAsync()
        {
            return await _context.ProductGroups.ToListAsync();
        }

        public async Task<ProductGroup> UpdateAsync(ProductGroup group)
        {
            _context.ProductGroups.Update(group);
            await _context.SaveChangesAsync();
            return group;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var group = await _context.ProductGroups.FindAsync(id);
            if (group == null) return false;
            _context.ProductGroups.Remove(group);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 