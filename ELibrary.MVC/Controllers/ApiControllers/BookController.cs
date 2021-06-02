using AutoMapper;
using ELibrary.Core.Abstractions;
using ELibrary.Data.Repositories.Abstractions;
using ELibrary.Data.Repositories.Implementations;
using ELibrary.Dtos;
using ELibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly IBookService _bookService;
        private readonly IRateService _rateService;

        public BookController(IBookServices bookServices, IBookService bookService, IRateService rateService)
        {
            _bookServices = bookServices;
            _bookService = bookService;
            _rateService = rateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageIndex = 1)
        {
            var response = await _bookServices.GetAll(pageIndex);
            if (response.Success)
                return Ok(response);

            return NotFound(response);
        }

        [HttpDelete("{id:int}/delete")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var response = await _bookServices.DeleteById(id);
            if (response.Success)
                return Ok(response);

            return Ok(response);
        }

        [HttpPatch("update/{id}")]
        public async Task<IActionResult> UpdateBooKPhoto(int id, [FromForm] AddPhotoDto photo)
        {
            var response = await _bookServices.UpdatePhotoBook(id, photo);
            if (response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
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

        [HttpGet("get-by-title")]
        public async Task<IActionResult> GetBook([FromQuery] BookResourceParameters bookResource)
        {
            if (bookResource == null)
                return NotFound();

            var result = await _bookServices.GetBook(bookResource);

            return Ok(result);
        }

        [HttpGet("get-book-by-category")]
        public async Task<IActionResult> GetBookByCategory([FromQuery] GetBookByCategoryDto getBook)
        {
            var result = await _bookService.GetByCategory(getBook.categoryName, getBook.pageIndex);
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

        [HttpGet("search-for-book")]
        public async Task<IActionResult> SearchForBook([FromQuery] SearchBookDto getBook)
        {
            var result = await _bookServices.GetBookBySearchTerm(getBook.SearchTerm, getBook.SearchProperty, getBook.PageIndex);
            if (result != null)
            {
                return Ok(result); // 200
            }
            return NotFound(result); // 404
        }

        //[HttpGet("get-book-by-category")]
        //public IActionResult GetBookByCategoryName(string categoryName, int pageIndex )
        //{

        //    var result = _bookService.GetByCategory(categoryName, pageIndex).Result;
        //    if (result != null) 
        //    {
        //        return Ok(result);
        //    }
        //    return NotFound(result); 
            
        //}

    }
}