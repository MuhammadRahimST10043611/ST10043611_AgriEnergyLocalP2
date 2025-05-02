using ProgAgriP2New.Models.ViewModels;
using ProgAgriP2New.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProgAgriP2New.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IFarmerService _farmerService;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(
            IProductService productService,
            IFarmerService farmerService,
            IEmployeeService employeeService)
        {
            _productService = productService;
            _farmerService = farmerService;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? farmerId, string category,
            DateTime? startDate, DateTime? endDate, int pageSize = 20, int pageNumber = 1, string sortOrder = "desc")
                {
            // Check if user is authenticated as an employee
            var userType = HttpContext.Session.GetString("UserType");

            if (userType != "Employee")
            {
                return RedirectToAction("Login", "Account");
            }

            var viewModel = await _productService.GetFilteredProductsAsync(
                farmerId, category, startDate, endDate, pageSize, pageNumber, sortOrder);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int? farmerId, string category,
            DateTime? startDate, DateTime? endDate, int pageSize = 20, string sortOrder = "desc")
        {
            // Check if user is authenticated as an employee
            var userType = HttpContext.Session.GetString("UserType");

            if (userType != "Employee")
            {
                return RedirectToAction("Login", "Account");
            }

            // Reset to page 1 when filter changes
            var viewModel = await _productService.GetFilteredProductsAsync(
                farmerId, category, startDate, endDate, pageSize, 1, sortOrder);
            return View(viewModel);
        }
        public IActionResult AddFarmer()
        {
            // Check if user is authenticated as an employee
            var userType = HttpContext.Session.GetString("UserType");

            if (userType != "Employee")
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFarmer(FarmerViewModel model)
        {
            // Check if user is authenticated as an employee
            var userType = HttpContext.Session.GetString("UserType");

            if (userType != "Employee")
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                var (success, errorMessage) = await _farmerService.AddAsync(model);

                if (success)
                {
                    return RedirectToAction("ManageFarmers");
                }

                ViewBag.ErrorMessage = errorMessage;
            }

            return View(model);
        }

        public async Task<IActionResult> ManageFarmers()
        {
            // Check if user is authenticated as an employee
            var userType = HttpContext.Session.GetString("UserType");

            if (userType != "Employee")
            {
                return RedirectToAction("Login", "Account");
            }

            var farmers = await _farmerService.GetAllAsync();
            return View(farmers);
        }

        public async Task<IActionResult> EditFarmer(int id)
        {
            // Check if user is authenticated as an employee
            var userType = HttpContext.Session.GetString("UserType");

            if (userType != "Employee")
            {
                return RedirectToAction("Login", "Account");
            }

            var farmer = await _farmerService.GetByIdAsync(id);
            if (farmer == null)
            {
                return NotFound();
            }

            var viewModel = new FarmerViewModel
            {
                FarmerId = farmer.FarmerId,
                Name = farmer.Name,
                Email = farmer.Email,
                Password = farmer.Password,
                Address = farmer.Address,
                PhoneNumber = farmer.PhoneNumber
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditFarmer(FarmerViewModel model)
        {
            // Check if user is authenticated as an employee
            var userType = HttpContext.Session.GetString("UserType");

            if (userType != "Employee")
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                var (success, errorMessage) = await _farmerService.UpdateAsync(model);

                if (success)
                {
                    return RedirectToAction("ManageFarmers");
                }

                ViewBag.ErrorMessage = errorMessage;
            }

            return View(model);
        }

        public async Task<IActionResult> DeleteFarmer(int id)
        {
            // Check if user is authenticated as an employee
            var userType = HttpContext.Session.GetString("UserType");

            if (userType != "Employee")
            {
                return RedirectToAction("Login", "Account");
            }

            await _farmerService.DeleteAsync(id);
            return RedirectToAction("ManageFarmers");
        }

        public async Task<IActionResult> ManageEmployees()
        {
            // Check if user is authenticated as an employee
            var userType = HttpContext.Session.GetString("UserType");

            if (userType != "Employee")
            {
                return RedirectToAction("Login", "Account");
            }

            var employees = await _employeeService.GetAllAsync();
            return View(employees);
        }

        public IActionResult AddEmployee()
        {
            // Check if user is authenticated as an employee
            var userType = HttpContext.Session.GetString("UserType");

            if (userType != "Employee")
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeViewModel model)
        {
            // Check if user is authenticated as an employee
            var userType = HttpContext.Session.GetString("UserType");

            if (userType != "Employee")
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                var (success, errorMessage) = await _employeeService.AddAsync(model);

                if (success)
                {
                    return RedirectToAction("ManageEmployees");
                }

                ViewBag.ErrorMessage = errorMessage;
            }

            return View(model);
        }

        public async Task<IActionResult> EditEmployee(int id)
        {
            // Check if user is authenticated as an employee
            var userType = HttpContext.Session.GetString("UserType");

            if (userType != "Employee")
            {
                return RedirectToAction("Login", "Account");
            }

            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            var viewModel = new EmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                Email = employee.Email,
                Password = employee.Password
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(EmployeeViewModel model)
        {
            // Check if user is authenticated as an employee
            var userType = HttpContext.Session.GetString("UserType");

            if (userType != "Employee")
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                var (success, errorMessage) = await _employeeService.UpdateAsync(model);

                if (success)
                {
                    return RedirectToAction("ManageEmployees");
                }

                ViewBag.ErrorMessage = errorMessage;
            }

            return View(model);
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            // Check if user is authenticated as an employee
            var userType = HttpContext.Session.GetString("UserType");

            if (userType != "Employee")
            {
                return RedirectToAction("Login", "Account");
            }

            await _employeeService.DeleteAsync(id);
            return RedirectToAction("ManageEmployees");
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            // Check if user is authenticated as an employee
            var userType = HttpContext.Session.GetString("UserType");

            if (userType != "Employee")
            {
                return RedirectToAction("Login", "Account");
            }

            // Delete the product
            await _productService.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}