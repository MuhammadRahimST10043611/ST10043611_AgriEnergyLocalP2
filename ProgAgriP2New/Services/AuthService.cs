using ProgAgriP2New.Repositories;

namespace ProgAgriP2New.Services
{
    public class AuthService : IAuthService
    {
        private readonly IFarmerRepository _farmerRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public AuthService(IFarmerRepository farmerRepository, IEmployeeRepository employeeRepository)
        {
            _farmerRepository = farmerRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<(bool success, string role, int userId)> ValidateLoginAsync(string email, string password, string userType)
        {
            if (userType == "Farmer")
            {
                var isValid = await _farmerRepository.ValidateCredentialsAsync(email, password);
                if (isValid)
                {
                    var farmer = await _farmerRepository.GetByEmailAsync(email);
                    return (true, "Farmer", farmer.FarmerId);
                }
            }
            else if (userType == "Employee")
            {
                var isValid = await _employeeRepository.ValidateCredentialsAsync(email, password);
                if (isValid)
                {
                    var employee = await _employeeRepository.GetByEmailAsync(email);
                    return (true, "Employee", employee.EmployeeId);
                }
            }
            return (false, string.Empty, 0);
        }
    }
}