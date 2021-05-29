﻿using ELibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ELibrary.MVC.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            throw new Exception("New Exception"); //for testing purpose
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
