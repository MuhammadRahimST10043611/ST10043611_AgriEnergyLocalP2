using ProgAgriP2New.Data;
using ProgAgriP2New.Models;
using Microsoft.EntityFrameworkCore;

namespace ProgAgriP2New.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            return await _context.Products
                .Include(p => p.Farmer)
                .FirstOrDefaultAsync(p => p.ProductId == productId);
        }

        public async Task<IEnumerable<Product>> GetByFarmerIdAsync(int farmerId)
        {
            return await _context.Products
                .Where(p => p.FarmerId == farmerId)
                .Include(p => p.Farmer)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.Include(p => p.Farmer).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetFilteredProductsAsync(int? farmerId, string category, DateTime? startDate, DateTime? endDate)
        {
            var query = _context.Products.Include(p => p.Farmer).AsQueryable();

            if (farmerId.HasValue && farmerId.Value > 0)
            {
                query = query.Where(p => p.FarmerId == farmerId.Value);
            }

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category == category);
            }

            if (startDate.HasValue)
            {
                query = query.Where(p => p.ProductionDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(p => p.ProductionDate <= endDate.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<string>> GetDistinctCategoriesAsync()
        {
            return await _context.Products.Select(p => p.Category).Distinct().ToListAsync();
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        // New method to update a product
        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        // New method to delete a product
        public async Task DeleteAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}