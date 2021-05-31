using AutoMapper;
using ELibrary.Core.Abstractions;
using ELibrary.Data.Repositories.Abstractions;
using ELibrary.Data.Repositories.Implementations;
using ELibrary.Dtos;
using ELibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.MVC.Controllers.ApiControllers
{

    [AllowAnonymous]
    public class BookController : BaseApiController
    {
        private readonly IBookServices _bookServices;
        private readonly IBookRepository _bookRepository;

        public BookController(IBookServices bookServices, IBookRepository bookRepository)
        {
            _bookServices = bookServices;
            _bookRepository = bookRepository;
        }

        
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] AddBookDto book)
        {
            if (book == null)
                return NotFound();

            var result = await _bookServices.AddBook(book);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookDto book)
        {
            if (book == null)
                return NotFound();
  
            var result = await _bookServices.UpdateBook(book);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetBook([FromQuery] BookResourceParameters bookResource)
        {
            if (bookResource == null)
                return NotFound();

            var result = await _bookServices.GetBook(bookResource);

            return Ok(result);
        }

    }
}
