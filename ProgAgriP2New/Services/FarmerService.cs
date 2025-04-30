using ProgAgriP2New.Models;
using ProgAgriP2New.Models.ViewModels;
using ProgAgriP2New.Repositories;

namespace ProgAgriP2New.Services
{
    public class FarmerService : IFarmerService
    {
        private readonly IFarmerRepository _farmerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPasswordValidationService _passwordValidationService;

        public FarmerService(
            IFarmerRepository farmerRepository,
            IProductRepository productRepository,
            IPasswordValidationService passwordValidationService)
        {
            _farmerRepository = farmerRepository;
            _productRepository = productRepository;
            _passwordValidationService = passwordValidationService;
        }

        public async Task<Farmer> GetByIdAsync(int farmerId)
        {
            return await _farmerRepository.GetByIdAsync(farmerId);
        }

        public async Task<IEnumerable<Farmer>> GetAllAsync()
        {
            return await _farmerRepository.GetAllAsync();
        }

        public async Task<(bool success, string errorMessage)> AddAsync(FarmerViewModel farmerViewModel)
        {
            // Validate password
            if (!_passwordValidationService.IsValidPassword(farmerViewModel.Password, out string errorMessage))
            {
                return (false, errorMessage);
            }

            // Check if email is already in use
            var existingFarmer = await _farmerRepository.GetByEmailAsync(farmerViewModel.Email);
            if (existingFarmer != null)
            {
                return (false, "Email is already in use.");
            }

            var farmer = new Farmer
            {
                Name = farmerViewModel.Name,
                Email = farmerViewModel.Email,
                Password = farmerViewModel.Password,
                Address = farmerViewModel.Address,
                PhoneNumber = farmerViewModel.PhoneNumber
            };

            await _farmerRepository.AddAsync(farmer);
            return (true, string.Empty);
        }

        public async Task<(bool success, string errorMessage)> UpdateAsync(FarmerViewModel farmerViewModel)
        {
            var farmer = await _farmerRepository.GetByIdAsync(farmerViewModel.FarmerId);

            if (farmer == null)
            {
                return (false, "Farmer not found.");
            }

            // Validate password if it changed
            if (farmer.Password != farmerViewModel.Password &&
                !_passwordValidationService.IsValidPassword(farmerViewModel.Password, out string errorMessage))
            {
                return (false, errorMessage);
            }

            // If email changed, check if the new email is available
            if (farmer.Email != farmerViewModel.Email)
            {
                var existingFarmer = await _farmerRepository.GetByEmailAsync(farmerViewModel.Email);
                if (existingFarmer != null && existingFarmer.FarmerId != farmerViewModel.FarmerId)
                {
                    return (false, "Email is already in use.");
                }
            }

            farmer.Name = farmerViewModel.Name;
            farmer.Email = farmerViewModel.Email;
            farmer.Password = farmerViewModel.Password;
            farmer.Address = farmerViewModel.Address;
            farmer.PhoneNumber = farmerViewModel.PhoneNumber;

            await _farmerRepository.UpdateAsync(farmer);
            return (true, string.Empty);
        }

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