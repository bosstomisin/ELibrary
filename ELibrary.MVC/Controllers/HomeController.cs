using ELibrary.Models;
using ELibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ELibrary.MVC.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {

        }

        public IActionResult Index()
        {
            var most = new MostPopularViewModel();
            var newest = new NewReleaseViewModel();
            
            var book1 = new BookViewModel();
            var book2 = new BookViewModel();
            var book3 = new BookViewModel();
            var book4 = new BookViewModel();
            var book5 = new BookViewModel();
            
            most.Books = new[] {book1, book2, book3, book4, book5};
            newest.Books = new[] {book1, book2, book3, book4, book5};
            
            var model = new HomeViewModel
            {
                NewRelease = newest,
                MostPopular = most
            };
            
            return View(model);
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
