using ProgAgriP2New.Models;
using ProgAgriP2New.Models.ViewModels;

namespace ProgAgriP2New.Services
{
    public interface IProductService
    {
        Task<Product> GetByIdAsync(int productId);
        Task<ProductViewModel> GetByIdAsViewModelAsync(int productId);  // New method
        Task<IEnumerable<ProductViewModel>> GetByFarmerIdAsync(int farmerId);
        Task<IEnumerable<ProductViewModel>> GetAllAsync();
        Task<ProductFilterViewModel> GetFilteredProductsAsync(int? farmerId, string category, DateTime? startDate, DateTime? endDate);
        Task<IEnumerable<string>> GetDistinctCategoriesAsync();
        Task AddAsync(int farmerId, string name, string category, DateTime productionDate);
        Task UpdateAsync(ProductViewModel productViewModel);  // New method
        Task DeleteAsync(int productId);  // New method
    }
}