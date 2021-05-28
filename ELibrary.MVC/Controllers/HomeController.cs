using ELibrary.Core.Abstractions;
using ELibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ELibrary.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly IConfiguration _config;

        public HomeController(IJwtTokenGenerator tokenGenerator, IConfiguration config)
        {
            _tokenGenerator = tokenGenerator;
            _config = config;
        }

        public IActionResult Index()
        {
            var roles = new[] { "Admin" };
            var token = _tokenGenerator.GenerateToken("Raphael", "566768", "raphael", _config, roles);
            ViewBag.token = token;
            return View();
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
