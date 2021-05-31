using System.Threading.Tasks;
using ELibrary.Core.Abstractions;
using ELibrary.Data.Repositories.Abstractions;
using ELibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.MVC.Controllers.ApiControllers
{
    [AllowAnonymous]
    public class BookController: BaseApiController
    {
        private readonly IBookServices _bookServices;

        public BookController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]int pageIndex=1)
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
    }
}