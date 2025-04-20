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

        public async Task<IActionResult> Index()
        {
            // Check if user is authenticated as a farmer
            var userType = HttpContext.Session.GetString("UserType");
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userType != "Farmer" || !userId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            var products = await _productService.GetByFarmerIdAsync(userId.Value);
            return View(products);
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
        public async Task<IActionResult> AllProducts(string category = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            // Check if user is authenticated as a farmer
            var userType = HttpContext.Session.GetString("UserType");
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userType != "Farmer" || !userId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            // Get all categories first - this is important to show all possible categories
            var categories = await _productService.GetDistinctCategoriesAsync();

            // Get all products (excluding current farmer's products)
            var productFilter = await _productService.GetFilteredProductsAsync(null, category, startDate, endDate);
            var products = productFilter.Products.Where(p => p.FarmerId != userId.Value).ToList();

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
            ViewBag.Categories = categories; // Use all possible categories, not just the filtered ones
            ViewBag.SelectedCategory = category;
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;

            return View(products);
        }
        
        [HttpPost]
        [ActionName("AllProducts")]
        public async Task<IActionResult> AllProductsPost(string category, DateTime? startDate, DateTime? endDate)
        {
            // Redirect to the GET method with the filter parameters
            return RedirectToAction("AllProducts", new { category, startDate, endDate });
        }
    }
}
