using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartBi.Presentation.MVC.Models;
using SmartBI.DAL.EfCore.Contexts;
using SmartBI.Domain.Entities;
using System.Diagnostics;
using System.Security.Cryptography;

namespace SmartBi.Presentation.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SmartDbContext _smartDbContext;

        public HomeController(ILogger<HomeController> logger, SmartDbContext smartDbContext)
        {
            _logger = logger;
            _smartDbContext = smartDbContext;
        }

        public async Task<IActionResult> Index()
        {
            await AddSomeBusiness();
            return View();
        }

        private async Task AddSomeBusiness()
        {
            var res = await _smartDbContext.Businesses.Where(x => x.Id == 3).Include(X => X.Transactions).ToListAsync();
            await Console.Out.WriteLineAsync();
        }


        public static string GenerateRandomSlug()
        {
            string _characters = "0123456789";
            int SlugLength = 11;
            RandomNumberGenerator RandomGenerator = RandomNumberGenerator.Create();

            char[] result = new char[SlugLength];
            byte[] randomBytes = new byte[SlugLength];

            RandomGenerator.GetBytes(randomBytes);

            for (int i = 0; i < SlugLength; i++)
            {
                int index = randomBytes[i] % _characters.Length;
                result[i] = _characters[index];
            }

            return new string(result);
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