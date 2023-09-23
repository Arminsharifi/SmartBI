using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SmartBi.Presentation.MVC.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}