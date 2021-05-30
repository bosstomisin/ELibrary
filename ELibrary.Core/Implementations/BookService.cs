using ELibrary.Core.Abstractions;
using ELibrary.Data.Repositories.Implementations;
using ELibrary.Dtos;
using ELibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Core.Implementations
{
    class BookService : IBookService
    {
        private readonly BookRepository _bookRepo;
       

        public BookService(BookRepository BookRepo)
        {
            _bookRepo = BookRepo;
        }

        public async Task<ResponseDto<IQueryable<BookDto>>> GetByCategory(string CategoryName, int pageIndex, int pageSize)
        {
            ResponseDto<IQueryable<BookDto>> response = new ResponseDto<IQueryable<BookDto>>
            {
                Success = false,
            };

            if (string.IsNullOrEmpty(CategoryName))
            {
                response.Message = "Not found";
                response.StatusCode = 404;
                response.Success = false;
                return response;
            }


            var result = _bookRepo.GetByCategory(CategoryName);
            if (result != null)
            {
                var paginatedResult = await Pagination<Book>.CreateAsync(result, pageIndex, pageSize);
                paginatedResult.
            }
            return response;
        }
    }
}
