using System.Threading.Tasks;
using ELibrary.Data.Repositories.Implementations;
using ELibrary.Dtos;

namespace ELibrary.Core.Abstractions
{
    public interface IBookServices
    {
        Task<ResponseDto<Pagination<GetBookDto>>> GetAll(int pageIndex);
        Task<ResponseDto<bool>> DeleteById(int bookId);
        Task<ResponseDto<AddBookResponseDto>> AddBook(AddBookDto model);
        Task<ResponseDto<UpdateBookResponseDto>> UpdateBook(UpdateBookDto model);
        Task<ResponseDto<Pagination<GetBookDto>>> GetBook(BookResourceParameters bookResource);

        public Task<ResponseDto<GetBookDto>> UpdatePhotoBook(int bookId, AddPhotoDto photo);
        //public Task<ResponseDto<Pagination<GetBookDto>>> GetBookByCategory(string categoryName, int pageIndex);
        public Task<ResponseDto<Pagination<GetBookDto>>> GetBookBySearchTerm(string searchTerm, string searchproperty, int pageNumber);


    }
}
