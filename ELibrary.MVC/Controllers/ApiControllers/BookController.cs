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
        private readonly IBookServices _bookService;

        public BookController(IBookServices bookService)
        {
            _bookService = bookService;
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
    }
}
