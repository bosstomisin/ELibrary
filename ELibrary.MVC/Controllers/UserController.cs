using AutoMapper;
using ELibrary.Data.Repositories.Implementations;
using ELibrary.Dtos;
using ELibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ELibrary.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAllUsers()
        {
            var httpClient = new HttpClient();
            var userResponse = await httpClient.GetAsync("https://localhost:44326/api/User/all-user");
            var deserializedUserResponseObject = JsonConvert.DeserializeObject<ResponseDto<Pagination<GetUserDto>>>(await userResponse.Content.ReadAsStringAsync());
            var deserializedUserResponse = deserializedUserResponseObject.Data;
            var users = _mapper.Map<List<UserViewModel>>(deserializedUserResponse);

            return View(users);
        }
        public IActionResult GetUser(string userId = "bjgfugyfguw efyuegwyu frwuewu")
        {
            // perform fetch to api/User/id
            // construct a usertoUpdate viewModel
            var model = new UserToUpdateViewModel();
            return View(model);
        }
    }
}
