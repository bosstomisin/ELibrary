using ELibrary.Core.Abstractions;
using ELibrary.Data;
using ELibrary.Data.Repositories.Abstractions;
using ELibrary.Dtos;
using ELibrary.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Core.Implementations
{
    public class RateService : IRateService
    {
        private readonly IRepository<Rating> _ratingRepository;
        private readonly IRepository<Book> _bookRepository;
        private readonly UserManager<AppUser> _userManager;

        public RateService(IRepository<Rating> ratingRepository, IRepository<Book> bookRepository, UserManager<AppUser> userManager)
        {
            _ratingRepository = ratingRepository;
            _bookRepository = bookRepository;
            _userManager = userManager;
        }

        public async Task<ResponseDto<bool>> RateBook(int bookId, int ratingValue, string userId)
        {
            var response = new ResponseDto<bool>
            {
                Success = false,
                Message = "Number out of range"
                
            };

            if (ratingValue >= 0 && ratingValue <= 5)
            {
                var book = await _bookRepository.GetById(bookId);
                var user = await _userManager.FindByIdAsync(userId);

                var Rate = new Rating
                {
                    Book = book,
                    AppUser = user,
                    AppUserId = userId,
                    Rate = ratingValue
                };
                var result = await _ratingRepository.Save(Rate);
                if (result == true)
                {
                    response.Success = true;
                    response.StatusCode = 200;
                    response.Message = "Success";
                    response.Data = true;
                    return response;
                }
            }
            return response;
        }
    }
}
