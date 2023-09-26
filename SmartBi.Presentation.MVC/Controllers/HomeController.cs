using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartBI.DAL.EfCore.Contexts;

namespace SmartBi.Presentation.MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //await AddSomeBusiness();
            return View();
        }
    }
}