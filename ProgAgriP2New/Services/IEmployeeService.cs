using ProgAgriP2New.Models;
using ProgAgriP2New.Models.ViewModels;

namespace ProgAgriP2New.Services
{
    public interface IEmployeeService
    {
        Task<Employee> GetByIdAsync(int employeeId);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<(bool success, string errorMessage)> AddAsync(EmployeeViewModel employeeViewModel);
        Task<(bool success, string errorMessage)> UpdateAsync(EmployeeViewModel employeeViewModel);
        Task DeleteAsync(int employeeId);
    }
}