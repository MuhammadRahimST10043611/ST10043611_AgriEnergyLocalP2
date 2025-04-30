using ProgAgriP2New.Models;
using ProgAgriP2New.Models.ViewModels;
using ProgAgriP2New.Repositories;

namespace ProgAgriP2New.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPasswordValidationService _passwordValidationService;

        public EmployeeService(IEmployeeRepository employeeRepository, IPasswordValidationService passwordValidationService)
        {
            _employeeRepository = employeeRepository;
            _passwordValidationService = passwordValidationService;
        }

        public async Task<Employee> GetByIdAsync(int employeeId)
        {
            return await _employeeRepository.GetByIdAsync(employeeId);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<(bool success, string errorMessage)> AddAsync(EmployeeViewModel employeeViewModel)
        {
            // Validate password
            if (!_passwordValidationService.IsValidPassword(employeeViewModel.Password, out string errorMessage))
            {
                return (false, errorMessage);
            }

            // Check if email is already in use
            var existingEmployee = await _employeeRepository.GetByEmailAsync(employeeViewModel.Email);
            if (existingEmployee != null)
            {
                return (false, "Email is already in use.");
            }

            var employee = new Employee
            {
                Name = employeeViewModel.Name,
                Email = employeeViewModel.Email,
                Password = employeeViewModel.Password
            };

            await _employeeRepository.AddAsync(employee);
            return (true, string.Empty);
        }

        public async Task<(bool success, string errorMessage)> UpdateAsync(EmployeeViewModel employeeViewModel)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeViewModel.EmployeeId);

            if (employee == null)
            {
                return (false, "Employee not found.");
            }

            // Validate password if it changed
            if (employee.Password != employeeViewModel.Password &&
                !_passwordValidationService.IsValidPassword(employeeViewModel.Password, out string errorMessage))
            {
                return (false, errorMessage);
            }

            // If email changed, check if the new email is available
            if (employee.Email != employeeViewModel.Email)
            {
                var existingEmployee = await _employeeRepository.GetByEmailAsync(employeeViewModel.Email);
                if (existingEmployee != null && existingEmployee.EmployeeId != employeeViewModel.EmployeeId)
                {
                    return (false, "Email is already in use.");
                }
            }

            employee.Name = employeeViewModel.Name;
            employee.Email = employeeViewModel.Email;
            employee.Password = employeeViewModel.Password;

            await _employeeRepository.UpdateAsync(employee);
            return (true, string.Empty);
        }

        public async Task DeleteAsync(int employeeId)
        {
            await _employeeRepository.DeleteAsync(employeeId);
        }
    }
}