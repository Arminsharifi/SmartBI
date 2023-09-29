using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartBi.Presentation.MVC.Models;
using SmartBI.Application.Interfaces;
using SmartBI.Shareds.DataTransferObjects;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

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
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(LoginViewModel loginViewModel)
        {
            JwtDto? jwtDto = await _authService.AuthenticateAsync(loginViewModel.UserName, loginViewModel.Password);
            if (jwtDto is not null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.ReadJwtToken(jwtDto.Token);
                var claimsJwt = token.Claims.ToList();
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, claimsJwt.FirstOrDefault(x => x.Type == "nameid").Value)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties() { AllowRefresh = true };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);
                HttpContext.Session.Clear();
                HttpContext.Session.SetString("BearerToken", jwtDto.Token);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Error"] = "نام کاربری یا رمز عبور اشتباه است";
                return RedirectToAction("Index", "Auth");
            }
        }

        [HttpGet]
        public async Task<IActionResult> SigningOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}