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
            var book1 = new BookViewModel();
            var book2 = new BookViewModel();
            var book3 = new BookViewModel();
            var book4 = new BookViewModel();
            
            var mostPopularBooks = new[] {book1, book2, book3, book4};
            var newestBooks = new[] {book1, book2, book3, book4};
            var categories = new[] { new CategoryViewModel(), new CategoryViewModel(), new CategoryViewModel(), new CategoryViewModel(), new CategoryViewModel(), new CategoryViewModel(), new CategoryViewModel() };
            
            var model = new HomeViewModel
            {
                MostPopularBooks = mostPopularBooks,
                NewestBooks = newestBooks,
                Categories = categories
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
