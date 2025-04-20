using ProgAgriP2New.Data;
using ProgAgriP2New.Models;
using Microsoft.EntityFrameworkCore;

namespace ProgAgriP2New.Repositories
{
    public class FarmerRepository : IFarmerRepository
    {
        private readonly ApplicationDbContext _context;

        public FarmerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Farmer> GetByIdAsync(int farmerId)
        {
            return await _context.Farmers
                .Include(f => f.Products)
                .FirstOrDefaultAsync(f => f.FarmerId == farmerId);
        }

        public async Task<Farmer> GetByEmailAsync(string email)
        {
            return await _context.Farmers.FirstOrDefaultAsync(f => f.Email == email);
        }

        public async Task<IEnumerable<Farmer>> GetAllAsync()
        {
            return await _context.Farmers
                .Include(f => f.Products)
                .ToListAsync();
        }

        public async Task AddAsync(Farmer farmer)
        {
            await _context.Farmers.AddAsync(farmer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Farmer farmer)
        {
            _context.Farmers.Update(farmer);
            await _context.SaveChangesAsync();
        }

        // New method to delete a farmer
        public async Task DeleteAsync(int farmerId)
        {
            var farmer = await _context.Farmers.FindAsync(farmerId);
            if (farmer != null)
            {
                _context.Farmers.Remove(farmer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ValidateCredentialsAsync(string email, string password)
        {
            var farmer = await _context.Farmers.FirstOrDefaultAsync(f => f.Email == email);
            return farmer != null && farmer.Password == password;
        }
    }
}