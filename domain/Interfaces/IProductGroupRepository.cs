namespace ProductApi.Domain.Interfaces
{
    public interface IProductGroupRepository
    {
        Task<ProductGroup> AddAsync(ProductGroup group);
        Task<ProductGroup> GetByIdAsync(int id);
        Task<IEnumerable<ProductGroup>> GetAllAsync();
        Task<ProductGroup> UpdateAsync(ProductGroup group);
        Task<bool> DeleteAsync(int id);
    }
}