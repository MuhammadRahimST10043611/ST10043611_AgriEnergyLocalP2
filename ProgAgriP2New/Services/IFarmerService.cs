using ProgAgriP2New.Models;
using ProgAgriP2New.Models.ViewModels;

namespace ProgAgriP2New.Services
{
    public interface IFarmerService
    {
        Task<Farmer> GetByIdAsync(int farmerId);
        Task<IEnumerable<Farmer>> GetAllAsync();
        Task AddAsync(FarmerViewModel farmerViewModel);
        Task UpdateAsync(FarmerViewModel farmerViewModel);  // New method
        Task DeleteAsync(int farmerId);  // New method
    }
}