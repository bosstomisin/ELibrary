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
        private readonly IBookServices _bookRepo;
        private readonly IBookRepository _bookRepository;
        private readonly IRateService _rateService;

        public BookController(IBookServices bookServices, IBookRepository bookRepository, IRateService rateService)
        {
            _bookRepo = bookServices;
            _bookRepository = bookRepository;
            _rateService = rateService;
        }


        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] AddBookDto book)
        {
            if (book == null)
                return NotFound();

            var result = await _bookRepo.AddBook(book);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookDto book)
        {
            if (book == null)
                return NotFound();

            var result = await _bookRepo.UpdateBook(book);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetBook([FromQuery] BookResourceParameters bookResource)
        {
            if (bookResource == null)
                return NotFound();

            var result = await _bookRepo.GetBook(bookResource);

            return Ok(result);
        }

        [HttpGet("get-book-by-category")]
        public async Task<IActionResult> GetBookByCategory([FromBody] GetBookByCategoryDto getBook)
        {
            var result = await _bookRepo.GetByCategory(getBook.categoryName, getBook.pageIndex, getBook.pageSize);
            if (result != null)
            {
                return Ok(result); // 200
            }
            return NotFound(result); // 404
        }

        [HttpPost("rate-a-book")]
        public async Task<IActionResult> RateABook([FromBody] RateABookDto rateABook)
        {
            var result = await _rateService.RateBook(rateABook.BookId, rateABook.RatingValue, rateABook.UserId);
            if (result != null)
            {
                return Ok(result); // 200
            }
            return NotFound(); // 404
        }

    }
}