using AutoMapper;
using ELibrary.Core.Abstractions;
using ELibrary.Data.Repositories.Abstractions;
using ELibrary.Data.Repositories.Implementations;
using ELibrary.Dtos;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.Core.Implementations
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepo;
       

        public BookService(IMapper mapper, IBookRepository BookRepo)
        {
            _mapper = mapper;
            _bookRepo = BookRepo;
        }

        public async Task<ResponseDto<Pagination<GetBookDto>>> GetByCategory(string CategoryName, int pageIndex, int pageSize)
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
