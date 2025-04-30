using ProgAgriP2New.Models;
using ProgAgriP2New.Models.ViewModels;

namespace ProgAgriP2New.Services
{
    public interface IFarmerService
    {
        Task<Farmer> GetByIdAsync(int farmerId);
        Task<IEnumerable<Farmer>> GetAllAsync();
        Task<(bool success, string errorMessage)> AddAsync(FarmerViewModel farmerViewModel);
        Task<(bool success, string errorMessage)> UpdateAsync(FarmerViewModel farmerViewModel);
        Task DeleteAsync(int farmerId);
    }
}