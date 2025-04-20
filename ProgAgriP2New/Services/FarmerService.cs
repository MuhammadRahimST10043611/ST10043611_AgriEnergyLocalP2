using ProgAgriP2New.Models;
using ProgAgriP2New.Models.ViewModels;
using ProgAgriP2New.Repositories;

namespace ProgAgriP2New.Services
{
    public class FarmerService : IFarmerService
    {
        private readonly IFarmerRepository _farmerRepository;
        private readonly IProductRepository _productRepository;

        public FarmerService(IFarmerRepository farmerRepository, IProductRepository productRepository)
        {
            _farmerRepository = farmerRepository;
            _productRepository = productRepository;
        }

        public async Task<Farmer> GetByIdAsync(int farmerId)
        {
            return await _farmerRepository.GetByIdAsync(farmerId);
        }

        public async Task<IEnumerable<Farmer>> GetAllAsync()
        {
            return await _farmerRepository.GetAllAsync();
        }

        public async Task AddAsync(FarmerViewModel farmerViewModel)
        {
            var farmer = new Farmer
            {
                Name = farmerViewModel.Name,
                Email = farmerViewModel.Email,
                Password = farmerViewModel.Password,
                Address = farmerViewModel.Address,
                PhoneNumber = farmerViewModel.PhoneNumber
            };

            await _farmerRepository.AddAsync(farmer);
        }

        // New method for updating farmer details
        public async Task UpdateAsync(FarmerViewModel farmerViewModel)
        {
            var farmer = await _farmerRepository.GetByIdAsync(farmerViewModel.FarmerId);

            if (farmer != null)
            {
                farmer.Name = farmerViewModel.Name;
                farmer.Email = farmerViewModel.Email;
                farmer.Password = farmerViewModel.Password;
                farmer.Address = farmerViewModel.Address;
                farmer.PhoneNumber = farmerViewModel.PhoneNumber;

                await _farmerRepository.UpdateAsync(farmer);
            }
        }

        // New method for deleting a farmer
        public async Task DeleteAsync(int farmerId)
        {
            // First delete all products associated with this farmer
            var products = await _productRepository.GetByFarmerIdAsync(farmerId);
            foreach (var product in products)
            {
                await _productRepository.DeleteAsync(product.ProductId);
            }

            // Then delete the farmer
            await _farmerRepository.DeleteAsync(farmerId);
        }
    }
}