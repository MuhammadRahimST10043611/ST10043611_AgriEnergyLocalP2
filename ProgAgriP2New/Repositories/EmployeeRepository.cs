using ProgAgriP2New.Data;
using ProgAgriP2New.Models;
using Microsoft.EntityFrameworkCore;

namespace ProgAgriP2New.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> GetByIdAsync(int employeeId)
        {
            return await _context.Employees.FindAsync(employeeId);
        }

        public async Task<Employee> GetByEmailAsync(string email)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateCredentialsAsync(string email, string password)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Email == email);
            return employee != null && employee.Password == password;
        }
    }
}