using ELibrary.Core.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ELibrary.MVC.Controllers.ApiControllers
{
 
    public class UserController : BaseApiController
    {
        
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("/User/{id}")]
        public async Task<IActionResult> GetUser(string userId)
        {
            var responseData = await _userService.GetUserByIdAsync(userId);
            if (responseData.StatusCode == 400)
                return BadRequest(responseData);
            if (responseData.StatusCode == 404)
                return NotFound(responseData);
            return Ok(responseData);
        }
        [HttpDelete("/User/{id}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var responseData = await _userService.DeleteUserAsync(userId);
            if (responseData.StatusCode == 400)
                return BadRequest(responseData);
            if (responseData.StatusCode == 404)
                return NotFound(responseData);
            return Ok(responseData);
        }
        [HttpGet("/User/all-user")]
        public async Task<IActionResult> GetUsers(int pageIndex)
        {
            var paginatedUsers = await _userService.GetUsersAsync(pageIndex);
            return Ok(paginatedUsers);
        }
    }
}
