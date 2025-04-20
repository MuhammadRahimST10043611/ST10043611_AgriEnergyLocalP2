using ProgAgriP2New.Models;
using ProgAgriP2New.Models.ViewModels;
using ProgAgriP2New.Repositories;

namespace ProgAgriP2New.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IFarmerRepository _farmerRepository;

        public ProductService(IProductRepository productRepository, IFarmerRepository farmerRepository)
        {
            _productRepository = productRepository;
            _farmerRepository = farmerRepository;
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            return await _productRepository.GetByIdAsync(productId);
        }

        // New method to get product by ID as ViewModel
        public async Task<ProductViewModel> GetByIdAsViewModelAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
                return null;

            var farmer = await _farmerRepository.GetByIdAsync(product.FarmerId);

            return new ProductViewModel
            {
                ProductId = product.ProductId,
                FarmerId = product.FarmerId,
                FarmerName = farmer?.Name ?? "Unknown",
                Name = product.Name,
                Category = product.Category,
                ProductionDate = product.ProductionDate
            };
        }

        public async Task<IEnumerable<ProductViewModel>> GetByFarmerIdAsync(int farmerId)
        {
            var products = await _productRepository.GetByFarmerIdAsync(farmerId);
            return products.Select(p => new ProductViewModel
            {
                ProductId = p.ProductId,
                FarmerId = p.FarmerId,
                FarmerName = p.Farmer?.Name ?? "Unknown",
                Name = p.Name,
                Category = p.Category,
                ProductionDate = p.ProductionDate
            }).ToList();
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => new ProductViewModel
            {
                ProductId = p.ProductId,
                FarmerId = p.FarmerId,
                FarmerName = p.Farmer?.Name ?? "Unknown",
                Name = p.Name,
                Category = p.Category,
                ProductionDate = p.ProductionDate
            }).ToList();
        }

        public async Task<ProductFilterViewModel> GetFilteredProductsAsync(int? farmerId, string category, DateTime? startDate, DateTime? endDate)
        {
            var products = await _productRepository.GetFilteredProductsAsync(farmerId, category, startDate, endDate);
            var farmers = await _farmerRepository.GetAllAsync();
            var categories = await _productRepository.GetDistinctCategoriesAsync();

            return new ProductFilterViewModel
            {
                FarmerId = farmerId,
                Category = category,
                StartDate = startDate,
                EndDate = endDate,
                Products = products.Select(p => new ProductViewModel
                {
                    ProductId = p.ProductId,
                    FarmerId = p.FarmerId,
                    FarmerName = p.Farmer?.Name ?? "Unknown",
                    Name = p.Name,
                    Category = p.Category,
                    ProductionDate = p.ProductionDate
                }).ToList(),
                Farmers = farmers.ToList(),
                Categories = categories.ToList()
            };
        }

        public async Task<IEnumerable<string>> GetDistinctCategoriesAsync()
        {
            return await _productRepository.GetDistinctCategoriesAsync();
        }

        public async Task AddAsync(int farmerId, string name, string category, DateTime productionDate)
        {
            var product = new Product
            {
                FarmerId = farmerId,
                Name = name,
                Category = category,
                ProductionDate = productionDate
            };

            await _productRepository.AddAsync(product);
        }

        // Method for updating a product
        public async Task UpdateAsync(ProductViewModel productViewModel)
        {
            var product = await _productRepository.GetByIdAsync(productViewModel.ProductId);

            if (product != null)
            {
                // Only update fields that should be editable
                product.Name = productViewModel.Name;
                product.Category = productViewModel.Category;
                product.ProductionDate = productViewModel.ProductionDate;

                await _productRepository.UpdateAsync(product);
            }
        }

        // Method for deleting a product
        public async Task DeleteAsync(int productId)
        {
            await _productRepository.DeleteAsync(productId);
        }
    }
}