using ProgAgriP2New.Models;

namespace ProgAgriP2New.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int productId);
        Task<IEnumerable<Product>> GetByFarmerIdAsync(int farmerId);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<(IEnumerable<Product> Products, int TotalCount)> GetFilteredProductsAsync(int? farmerId, string category, DateTime? startDate, DateTime? endDate, int pageSize, int pageNumber, string sortOrder = "desc");
        Task<IEnumerable<string>> GetDistinctCategoriesAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product); // New method
        Task DeleteAsync(int productId); // New method
    }
}