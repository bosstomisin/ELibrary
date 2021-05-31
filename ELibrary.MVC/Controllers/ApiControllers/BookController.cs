using ELibrary.Core.Abstractions;
using ELibrary.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.MVC.Controllers.ApiControllers
{  
    public class BookController : BaseApiController
    {
        private readonly IRateService _rateService;
        private readonly IBookServices _bookService;
        private readonly IBookService _bookRepo;

        public BookController(IBookService bookRepo, IBookServices bookService, IRateService rateService)
        {
            _bookService = bookService;
            _rateService = rateService;
            _bookRepo = bookRepo;
        }

        [HttpPatch("update/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateBooKPhoto(int id, [FromForm] AddPhotoDto photo)
        {
            var response = await _bookService.UpdatePhotoBook(id, photo);
            if (response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("get-book-by-category")]
        public async Task<IActionResult> GetBookByCategory([FromBody]GetBookByCategoryDto getBook)
        {
            var result =await  _bookRepo.GetByCategory(getBook.categoryName, getBook.pageIndex, getBook.pageSize);
            if(result != null)
            {
                return Ok(result); // 200
            }
            return NotFound(result); // 404
        }

        [HttpPost("rate-a-book")]
        public async Task<IActionResult> RateABook([FromBody]RateABookDto rateABook)
        {
            var result = await _rateService.RateBook(rateABook.BookId, rateABook.RatingValue, rateABook.UserId);
            if(result != null)
            {
                return Ok(result); // 200
            }
            return NotFound(); // 404
        }
    }
}
