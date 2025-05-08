using ProgAgriP2New.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ProgAgriP2New.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // New Landing page action
        public IActionResult Landing()
        {
            return View();
        }

        public IActionResult Index()
        {
            // Check if user is logged in
            if (HttpContext.Session.GetString("UserType") == "Farmer")
            {
                return RedirectToAction("Index", "Farmer");
            }
            else if (HttpContext.Session.GetString("UserType") == "Employee")
            {
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}