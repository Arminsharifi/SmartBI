using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartBi.Presentation.MVC.Models;
using SmartBI.Application.Interfaces;

namespace SmartBi.Presentation.MVC.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(LoginViewModel loginViewModel)
        {
            return RedirectToAction("Index", "Auth");
        }
    }
}