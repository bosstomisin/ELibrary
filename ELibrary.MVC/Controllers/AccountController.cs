using ELibrary.Common.Helpers;
using ELibrary.Dtos;
using ELibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ELibrary.MVC.Controllers
{
    public class AccountController : Controller
    {
        private const string BASE_URL = "https://localhost:44326/";
       
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var url = BASE_URL + "api/auth/login";
            var client = new ApiHttpClient();

            var userDto = new LoginDetailDto 
            { 
                Email = model.Email,
                Password = model.Password,
                RemeberMe = false,
            };
            var postRequest = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = JsonContent.Create(userDto)
            };
            
            var response = await client.Client.SendAsync(postRequest);
            //response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var responseDto = JsonSerializer.Deserialize<LoginViewModel>(content);

            return View(responseDto);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var url = BASE_URL + "api/auth/register";
            var client = new ApiHttpClient();
            var registerDto = new RegistrationDto()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword,
                Email = model.Email, 
            };
            var postRequest = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = JsonContent.Create(registerDto)
            };

            var response = await client.Client.SendAsync(postRequest);
            //response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var responseDto = JsonSerializer.Deserialize<RegisterViewModel>(content);
            return View(responseDto);
            
        }


    }
}
