using ProductApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ProductApi.Infrastructure.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AppDbContext _context;
        public ProductCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductCategory> AddAsync(ProductCategory category)
        {
            _context.ProductCategories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<ProductCategory> GetByIdAsync(int id)
        {
            return await _context.ProductCategories.FindAsync(id);
        }

        public async Task<IEnumerable<ProductCategory>> GetAllAsync()
        {
            return await _context.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory> UpdateAsync(ProductCategory category)
        {
            _context.ProductCategories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.ProductCategories.FindAsync(id);
            if (category == null) return false;
            _context.ProductCategories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 