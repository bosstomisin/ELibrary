using AutoMapper;
using ELibrary.Core.Abstractions;
using ELibrary.Data.Repositories.Abstractions;
using ELibrary.Data.Repositories.Implementations;
using ELibrary.Dtos;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.Core.Implementations
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepo;
        private readonly IConfiguration _config;

        public BookService(IMapper mapper, IBookRepository BookRepo, IConfiguration config)
        {
            _mapper = mapper;
            _bookRepo = BookRepo;
            _config = config;
        }

        public async Task<ResponseDto<Pagination<GetBookDto>>> GetByCategory(string CategoryName, int pageIndex=1)
        {

            //if (string.IsNullOrEmpty(CategoryName))
            //{
            //    var response = new ResponseDto<IQueryable<GetBookDto>>
            //    {
            //        Data = null,
            //        Message = "Not found",
            //        StatusCode = 404,
            //        Success = false
            //    };
            //    return response;
            //}

            var books = _bookRepo.GetByCategoryName(CategoryName);

            if (books == null)
            {
                return new ResponseDto<Pagination<GetBookDto>>
                {
                    Data = null,
                    Message = "Not found",
                    StatusCode = 404,
                    Success = false
                };
            }

            var bookDto = books.Select(book => _mapper.Map<GetBookDto>(book));
            var pageSize = int.Parse(_config.GetSection("PageSize:Default").Value);
            var paginatedResult = await Pagination<GetBookDto>.CreateAsync(bookDto, pageIndex, pageSize);

            var response = new ResponseDto<Pagination<GetBookDto>>
            {
                Data = paginatedResult,
                Message = "Not found",
                StatusCode = 404,
                Success = false
            };

            return response;
        }
    }
}
