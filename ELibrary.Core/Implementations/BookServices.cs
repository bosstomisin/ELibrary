using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ELibrary.Core.Abstractions;
using ELibrary.Data.Repositories.Abstractions;
using ELibrary.Data.Repositories.Implementations;
using ELibrary.Dtos;
using ELibrary.Models;
using Microsoft.Extensions.Configuration;

namespace ELibrary.Core.Implementations
{
    public class BookServices: IBookServices
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Book> _bookRepository;
        private readonly IConfiguration _config;

        public BookServices(IMapper mapper, IRepository<Book> bookRepository, IConfiguration config)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _config = config;
        }

        public async Task<ResponseDto<Pagination<GetBookDto>>> GetAll(int pageIndex)
        {
            var books = _bookRepository.GetAll().Select(book => _mapper.Map<GetBookDto>(book));

            var pageSize = int.Parse(_config.GetSection("PageSize").Value);
            
            var paginatedBooks = await Pagination<GetBookDto>.CreateAsync(books, pageIndex, pageSize);
            
            var response = new ResponseDto<Pagination<GetBookDto>>
            {
                Data = paginatedBooks,
                Success = true,
                StatusCode = 200,
            };
            
            return response;
        }
        
        public async Task<ResponseDto<bool>> DeleteById(int bookId)
        {
            var response = new ResponseDto<bool>();
            
            var book = await _bookRepository.GetById(bookId);
            
            if (book == null)
            {
                response.Data = false;
                response.Message = "invalid id entered";
                response.Success = false;
                response.StatusCode = 404;
                
                return response;
            }
            
            var result = await _bookRepository.DeleteById(bookId);
            
            if (result)
            {
                response.Data = true;
                response.Message = "deleted successfully";
                response.StatusCode = 200;
                response.Success = true;
            }
            else
            {
                response.Data = false;
                response.Message = "delete unsuccessful";
                response.StatusCode = 200;
                response.Success = false;
            }

            return response;
        }
    }
}