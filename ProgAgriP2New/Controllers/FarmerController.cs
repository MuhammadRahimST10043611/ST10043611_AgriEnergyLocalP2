using ProgAgriP2New.Models;
using ProgAgriP2New.Models.ViewModels;
using ProgAgriP2New.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProgAgriP2New.Controllers
{
    public class FarmerController : Controller
    {
        private readonly IProductService _productService;
        private readonly IFarmerService _farmerService;

        public FarmerController(IProductService productService, IFarmerService farmerService)
        {
            _productService = productService;
            _farmerService = farmerService;
        }

        public async Task<IActionResult> Index(int pageSize = 20, int pageNumber = 1, string sortOrder = "desc")
        {
            // Check if user is authenticated as a farmer
            var userType = HttpContext.Session.GetString("UserType");
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userType != "Farmer" || !userId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            var viewModel = await _productService.GetFilteredProductsAsync(
                userId.Value, null, null, null, pageSize, pageNumber, sortOrder);
            return View(viewModel);
        }

        public IActionResult AddProduct()
        {
            // Check if user is authenticated as a farmer
            var userType = HttpContext.Session.GetString("UserType");
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userType != "Farmer" || !userId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(string name, string category, DateTime productionDate)
        {
            // Check if user is authenticated as a farmer
            var userType = HttpContext.Session.GetString("UserType");
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userType != "Farmer" || !userId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            await _productService.AddAsync(userId.Value, name, category, productionDate);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditProduct(int id)
        {
            // Check if user is authenticated as a farmer
            var userType = HttpContext.Session.GetString("UserType");
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userType != "Farmer" || !userId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            // Get product as ViewModel instead of as Product entity
            var product = await _productService.GetByIdAsViewModelAsync(id);

            // Check that this product belongs to the current farmer
            if (product == null || product.FarmerId != userId.Value)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(int productId, string name, string category, DateTime productionDate)
        {
            // Check if user is authenticated as a farmer
            var userType = HttpContext.Session.GetString("UserType");
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userType != "Farmer" || !userId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            // Get the product to verify ownership
            var product = await _productService.GetByIdAsViewModelAsync(productId);

            // Verify ownership
            if (product == null || product.FarmerId != userId.Value)
            {
                return Forbid();
            }

            // Update the product model
            var updatedProduct = new ProductViewModel
            {
                ProductId = productId,
                FarmerId = userId.Value,
                Name = name,
                Category = category,
                ProductionDate = productionDate
            };

            await _productService.UpdateAsync(updatedProduct);
            return RedirectToAction("Index");
        }

        /*
            public async Task<IActionResult> DeleteProduct(int id)
            {
                // Check if user is authenticated as a farmer
                var userType = HttpContext.Session.GetString("UserType");
                var userId = HttpContext.Session.GetInt32("UserId");

                if (userType != "Farmer" || !userId.HasValue)
                {
                    return RedirectToAction("Login", "Account");
                }

                // Get product to verify ownership
                var product = await _productService.GetByIdAsViewModelAsync(id);

                // Check that this product belongs to the current farmer
                if (product == null || product.FarmerId != userId.Value)
                {
                    return NotFound();
                }

                await _productService.DeleteAsync(id);
                return RedirectToAction("Index");
            }
        */


        [HttpGet]
        public async Task<IActionResult> AllProducts(string category = null,
         DateTime? startDate = null, DateTime? endDate = null,
         int pageSize = 20, int pageNumber = 1, string sortOrder = "desc")
        {
            // Check if user is authenticated as a farmer
            var userType = HttpContext.Session.GetString("UserType");
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userType != "Farmer" || !userId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            // Get all categories
            var categories = await _productService.GetDistinctCategoriesAsync();

            // Get all products (excluding current farmer's products)
            var productFilter = await _productService.GetFilteredProductsAsync(
                null, category, startDate, endDate, pageSize, pageNumber, sortOrder);

            var products = productFilter.Products.Where(p => p.FarmerId != userId.Value).ToList();
            productFilter.Products = products;

            // Get contact information for each farmer
            var farmerIds = products.Select(p => p.FarmerId).Distinct().ToList();
            var farmerContacts = new Dictionary<int, FarmerViewModel>();

            foreach (var farmerId in farmerIds)
            {
                var farmer = await _farmerService.GetByIdAsync(farmerId);
                if (farmer != null)
                {
                    farmerContacts[farmerId] = new FarmerViewModel
                    {
                        Email = farmer.Email,
                        PhoneNumber = farmer.PhoneNumber
                    };
                }
            }

            // Pass data to view
            ViewBag.FarmerContacts = farmerContacts;
            ViewBag.Categories = categories;
            ViewBag.SelectedCategory = category;
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            ViewBag.PageSize = pageSize;
            ViewBag.CurrentPage = pageNumber;
            ViewBag.SortOrder = sortOrder;

            return View(productFilter);
        }

        [HttpPost]
        [ActionName("AllProducts")]
        public async Task<IActionResult> AllProductsPost(string category,
            DateTime? startDate, DateTime? endDate, int pageSize = 20, string sortOrder = "desc")
        {
            // Redirect to the GET method with the filter parameters (reset to page 1)
            return RedirectToAction("AllProducts",
                new { category, startDate, endDate, pageSize, pageNumber = 1, sortOrder });
        }
    }
}
