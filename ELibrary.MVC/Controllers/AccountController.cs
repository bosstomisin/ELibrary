using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
﻿using ELibrary.ViewModels;

namespace ELibrary.MVC.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
          
        [HttpGet] 
        public IActionResult Register() 
        {
            return View();
        }

        [HttpGet]
        public IActionResult ChangePassword() 
        {
            return View();
        }
       
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
