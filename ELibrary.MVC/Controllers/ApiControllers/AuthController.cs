using ELibrary.Core.Abstractions;
using ELibrary.Core.Implementations;
using ELibrary.Dtos;
using ELibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.MVC.Controllers.ApiControllers
{
    [AllowAnonymous]
    public class AuthController : BaseApiController
    {
        private IAuthServices _authservices;
     

        public AuthController(IAuthServices authServices)
        {
            _authservices = authServices;
          
        }



        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromForm] RegistrationDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authservices.RegisterUserAsync(model);
                return Ok(result);
            }
            return BadRequest("not successful!");
        }

        [HttpPost("/Login")]
        public async Task<IActionResult> Login([FromForm] LoginDetailDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authservices.LoginUserAsync(model);
                return Ok(result);
            }
            return BadRequest("Some properties are not valid");

        }

        [HttpPost("Logout")]
        public IActionResult LogOut()
        {
            var result = _authservices.Logout();
            return Ok(result);

        }


        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userid, string token)
        {
            if (string.IsNullOrWhiteSpace(userid) || string.IsNullOrWhiteSpace(token))
                return NotFound();

            var result = await _authservices.ConfirmEmailAsync(userid, token);

            return Ok(result);
        }
       
        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword([FromBody]ForgotPwdDto model)
        {
            if (string.IsNullOrEmpty(model.Email))
                return NotFound();

            var result = await _authservices.ForgetPasswordAsync(model.Email, Url, Request.Scheme);

            if (result.Success)
                return Ok(result);

            return BadRequest(result); 
        }




        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authservices.ResetPasswordAsync(model);

                if (result.Success)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }
    }
}
