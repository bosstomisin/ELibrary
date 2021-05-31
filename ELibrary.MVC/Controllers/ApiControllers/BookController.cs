using ELibrary.Core.Abstractions;
using ELibrary.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ELibrary.MVC.Controllers.ApiControllers
{
    [AllowAnonymous]
    public class BookController : BaseApiController
    {
        private readonly IBookService _bookRepo;
        private readonly IRateService _rateService;

        public BookController(IBookService bookService, IRateService rateService)
        {
            _bookRepo = bookService;
            _rateService = rateService;
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
