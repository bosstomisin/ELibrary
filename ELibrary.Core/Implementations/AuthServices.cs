using ELibrary.Core.Abstractions;
using ELibrary.Dtos;
using ELibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Core.Implementations
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailServices _mailService;
        private readonly string path = "../ELibrary.MVC/Controllers/ApiControllers";


        public AuthServices(UserManager<AppUser> userManager, IEmailServices mailService)
        {
            _userManager = userManager;
            _mailService = mailService;
        }

        public async Task<ResponseDto<string>> ForgetPasswordAsync(string email, IUrlHelper url, string requestScheme)
        {
            { 
            ResponseDto<string> response = new ResponseDto<string>();


                if (string.IsNullOrEmpty(email))
                {
                    response.Message = "Please provide an email";
                    return response;
                }


            var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    response.Message = "email does not exist";
                    return response;
                }


            var token = await EmailForgotPasswordToken(user);


                var passwordResetLink = url.Action("ResetPassword", "Auth", new { email, token }, requestScheme);


                var message = new Email
                {
                    Subject = "ResetPassword",
                    Body = "Reset Password" +
                    "<h1>Follow the instructions to reset your password</h1>" +
                $"<p>To reset your password <a href='{passwordResetLink}'>Click here</a></p>",
                    To = email
                };
                var mailSent =  _mailService.SendEmail(message);


                if (mailSent)
                {
                    response.Success = true;
                    response.Message = "Link sent to the email successfully";
                    return response;
                }


            response.Message = "Mail failed to send";
                return response;
            }

        }

        private async Task<string> EmailForgotPasswordToken(AppUser user)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);
            return validToken;
        }

  

        public async Task<ResponseDto<string>> ResetPasswordAsync(ResetPasswordDto model)
        {
            ResponseDto<string> response = new ResponseDto<string>();
            AppUser user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            { 
                response.Message = "No user associated with email";
                return response;
            }


            if (model.Password != model.ConfirmPassword)
            {
                response.Message = "Password doesn't match its confirmation";
                return response;
            }


            var decodedToken = WebEncoders.Base64UrlDecode(model.token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManager.ResetPasswordAsync(user, normalToken, model.Password);


            if (result.Succeeded)
            {
                response.Success = true;
                response.Message = "Password has been reset successfully!";
                return response;
            }


            response.Message = "Something went wrong";
            return response;

        }
    }
}
