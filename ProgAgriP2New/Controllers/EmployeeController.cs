using ProgAgriP2New.Models.ViewModels;
using ProgAgriP2New.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProgAgriP2New.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IFarmerService _farmerService;

        public EmployeeController(IProductService productService, IFarmerService farmerService)
        {
            _productService = productService;
            _farmerService = farmerService;
        }

        public async Task<IActionResult> Index()
        {
            // Check if user is authenticated as an employee
            var userType = HttpContext.Session.GetString("UserType");

            if (userType != "Employee")
            {
                return RedirectToAction("Login", "Account");
            }

            var viewModel = await _productService.GetFilteredProductsAsync(null, null, null, null);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int? farmerId, string category, DateTime? startDate, DateTime? endDate)
        {
            // Check if user is authenticated as an employee
            var userType = HttpContext.Session.GetString("UserType");

            if (userType != "Employee")
            {
                return RedirectToAction("Login", "Account");
            }

            var viewModel = await _productService.GetFilteredProductsAsync(farmerId, category, startDate, endDate);
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
                await _farmerService.AddAsync(model);
                return RedirectToAction("ManageFarmers");
            }

            return View(model);
        }

        // New methods for managing farmers
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
                await _farmerService.UpdateAsync(model);
                return RedirectToAction("ManageFarmers");
            }

            return View(model);
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
    }
}