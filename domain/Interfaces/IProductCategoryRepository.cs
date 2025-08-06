using domain.Entities;

namespace ProductApi.Domain.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task<ProductCategory> AddAsync(ProductCategory category);
        Task<ProductCategory> GetByIdAsync(int id);
        Task<IEnumerable<ProductCategory>> GetAllAsync();
        Task<ProductCategory> UpdateAsync(ProductCategory category);
        Task<bool> DeleteAsync(int id);
    }
}