using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.MVC.Controllers
{
    public class BookController : Controller
    {
        public IActionResult BookDetail()
        {
            return View();
        }


    }
}
