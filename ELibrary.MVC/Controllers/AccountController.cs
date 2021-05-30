using ELibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.MVC.Controllers
{
    public class AccountController : Controller
    {
       
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
