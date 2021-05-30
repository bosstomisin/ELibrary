using ELibrary.Data;
using ELibrary.Data.Repositories.Implementations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.MVC.Controllers.ApiControllers
{
    public class BookController : ControllerBase
    {
        private readonly BookRepository _bookRepo;

        public BookController(BookRepository BookRepo)
        {
            _bookRepo = BookRepo;
        }

        [HttpPost("GetBookByCategory")]
        public IActionResult GetBookByCategory(string CategoryName)
        {
            
                return Ok(result); // 200

            return BadRequest(result); // 400
        }
    }
}
