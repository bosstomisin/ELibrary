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
    public class AuthController : BaseApiController
    {
        private IAuthServices _authservices;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailServices _emailServices;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<AppUser> userManager,IAuthServices authServices, IEmailServices emailServices, IConfiguration configuration)
        {
            _authservices = authServices;
            _userManager = userManager;
            _emailServices = emailServices;
            _configuration = configuration;
        }


        // api/auth/forgetpassword
        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword([FromBody]ForgotPwdDto model)
        {
            if (string.IsNullOrEmpty(model.Email))
                return NotFound();

            var result = await _authservices.ForgetPasswordAsync(model.Email, Url, Request.Scheme);

            if (result.Success)
                return Ok(result); // 200

            return BadRequest(result); // 400
        }




        // api/auth/resetpassword
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
