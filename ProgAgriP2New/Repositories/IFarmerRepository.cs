using ProgAgriP2New.Models;

namespace ProgAgriP2New.Repositories
{
    public interface IFarmerRepository
    {
        Task<Farmer> GetByIdAsync(int farmerId);
        Task<Farmer> GetByEmailAsync(string email);
        Task<IEnumerable<Farmer>> GetAllAsync();
        Task AddAsync(Farmer farmer);
        Task UpdateAsync(Farmer farmer);
        Task DeleteAsync(int farmerId); // New method
        Task<bool> ValidateCredentialsAsync(string email, string password);
    }
}