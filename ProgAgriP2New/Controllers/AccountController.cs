using ProgAgriP2New.Models.ViewModels;
using ProgAgriP2New.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProgAgriP2New.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var (success, role, userId) = await _authService.ValidateLoginAsync(model.Email, model.Password, model.UserType);

                if (success)
                {
                    // Store session data
                    HttpContext.Session.SetString("UserType", role);
                    HttpContext.Session.SetInt32("UserId", userId);
                    HttpContext.Session.SetString("UserEmail", model.Email);

                    if (role == "Farmer")
                    {
                        return RedirectToAction("Index", "Farmer");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Employee");
                    }
                }

                ModelState.AddModelError("", "Invalid login attempt");
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}