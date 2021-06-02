using ELibrary.Common.Helpers;
using ELibrary.Data.Repositories.Implementations;
using ELibrary.Dtos;
using ELibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ELibrary.MVC.Controllers
{
    public class BookController : Controller
    {
        public IActionResult BookDetail()
        {
            return View();
        }


        public async Task<IActionResult> AdminBookView()
        {
            
            var httpClient = new ApiHttpClient();
            var bookResponse = await httpClient.Client.GetAsync("https://localhost:44326/api/Book/GetAll");
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var deserializedBookResponseObject = JsonConvert.DeserializeObject<ResponseDto<Pagination<GetBookDto>>>(await bookResponse.Content.ReadAsStringAsync());
            var deserializedBookResponse = deserializedBookResponseObject.Data;
            var allbooks = new List<AllBooksViewModel>();
            foreach (var bookDto in deserializedBookResponse)
            {
               
                var book = new AllBooksViewModel
                {
                    Title = bookDto.Title,
                    Author = bookDto.Author,
                    PublishedDate = bookDto.PublishedDate,
                    ISBN=bookDto.ISBN,
                    Publisher=bookDto.Publisher,
                    Id=bookDto.Id,
                    PhotoUrl=bookDto.PhotoUrl

                    
                };
                allbooks.Add(book);
            }
            ViewData["books"] = allbooks;
            return View();
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookViewModel model) 
        {
            if (ModelState.IsValid)
            {
                var client = new HttpClient();
                var addBookDto = new AddBookDto
                {
                    Author = model.Author,
                    Copies = model.Copies,
                    ISBN = model.ISBN,
                    Availability = model.Availability,
                    Language = model.Language,
                    AvailableCopies = model.AvailableCopies,
                    PhotoFile = model.PhotoFile,
                    Pages = model.Pages,
                    Publisher = model.Publisher,
                    PublishedDate = model.PublishedDate,
                    Description = model.Description,
                    Title = model.Title,
                    AddedDate = model.AddedDate,
                    Category = model.Category

                };
                var postRequest = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44326/api/Book/AddBook")
                {
                    Content = JsonContent.Create(addBookDto)
                };
                var response = await client.SendAsync(postRequest);
                //response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var responseDto = JsonSerializer.Deserialize<AddBookViewModel>(content);
                return View(responseDto);
            }
            return View();
            
        }
    }
}
