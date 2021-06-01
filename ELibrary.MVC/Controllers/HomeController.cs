using ELibrary.Common.Helpers;
using ELibrary.Data.Repositories.Implementations;
using ELibrary.Dtos;
using ELibrary.Models;
using ELibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.MVC.Controllers
{
    public class HomeController : Controller
    {
        private const string BASE_URL = "https://localhost:44326/api/";

        public HomeController()
        {

        }

        public async Task<IActionResult> Index()
        {
            var bookUrl = BASE_URL + "book";
            var httpClient = new ApiHttpClient();
            var bookResponse = await httpClient.Client.GetAsync(bookUrl);

            var deserializedBookResponseObject = JsonConvert.DeserializeObject<ResponseDto<Pagination<GetBookDto>>>(await bookResponse.Content.ReadAsStringAsync());
            var deserializedBookResponse = deserializedBookResponseObject.Data;
            var homeViewModel = new HomeViewModel();

            foreach (var bookDto in deserializedBookResponse)
            {
                var count = bookDto.Rate.Count();
                var totalRate = 0;

                if(count != 0)
                {
                    totalRate = bookDto.Rate.Sum(rating => rating.Rate) / count;
                }

                var book = new BookViewModel
                {
                    Id = bookDto.Id,
                    Title = bookDto.Title,
                    Author = bookDto.Author,
                    Availability = bookDto.Availability,
                    PhotoUrl = bookDto.PhotoUrl,
                    Rating = totalRate
                };

                homeViewModel.Books.Add(book);
            }

            var categoryUrl = BASE_URL + "category";
            var categoryResponse = await httpClient.Client.GetAsync(categoryUrl);
            var DeserilizedCategoryResponse = JsonConvert.DeserializeObject<ResponseDto<IEnumerable<GetCategoryDto>>>(await categoryResponse.Content.ReadAsStringAsync());
            foreach (var categoryDto in DeserilizedCategoryResponse.Data)
            {
                var category = new CategoryViewModel
                {
                    Id = categoryDto.Id,
                    Name = categoryDto.Name
                };
                homeViewModel.Categories.Add(category);
            };
            return View(homeViewModel);
        }



        public async Task<IActionResult> GetByCategory([FromQuery] string categoryName, [FromQuery] int pageIndex=1)
        {
            var bookUrl = BASE_URL + $"Book/get-book-by-category?categoryName={categoryName}&pageIndex={pageIndex}";
            var httpClient = new ApiHttpClient();
            var homeViewModel = new HomeViewModel();
            var bookResponse = await httpClient.Client.GetAsync(bookUrl);
            var DeserilizedBookResponse = JsonConvert.DeserializeObject<ResponseDto<Pagination<GetBookDto>>>(await bookResponse.Content.ReadAsStringAsync());
            
            foreach (var bookDto in DeserilizedBookResponse.Data)
            {
                var count = bookDto.Rate.Count();
                var totalRate = 0;

                if (count != 0)
                {
                    totalRate = bookDto.Rate.Sum(rating => rating.Rate) / count;
                }
                var bookViewModel = new BookViewModel
                {
                    Id = bookDto.Id,
                    Title = bookDto.Title,
                    Author = bookDto.Author,
                    PhotoUrl = bookDto.PhotoUrl,
                    Rating = totalRate,
                    Availability = bookDto.Availability
                };
                homeViewModel.Books.Add(bookViewModel);
            };

            var categoryUrl = BASE_URL + "category";
            var categoryResponse = await httpClient.Client.GetAsync(categoryUrl);
            var DeserilizedCategoryResponse = JsonConvert.DeserializeObject<ResponseDto<IEnumerable<GetCategoryDto>>>(await categoryResponse.Content.ReadAsStringAsync());
            foreach (var categoryDto in DeserilizedCategoryResponse.Data)
            {
                var category = new CategoryViewModel
                {
                    Id = categoryDto.Id,
                    Name = categoryDto.Name
                };
                homeViewModel.Categories.Add(category);
            };

            return View(homeViewModel);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
