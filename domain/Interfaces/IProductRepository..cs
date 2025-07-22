namespace ProductApi.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> AddAsync(Product product);
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
    }
}