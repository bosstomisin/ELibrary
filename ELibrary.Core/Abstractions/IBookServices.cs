using ELibrary.Data.Repositories.Implementations;
using ELibrary.Dtos;
using ELibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Core.Abstractions
{
    public interface IBookServices
    {
        Task<ResponseDto<AddBookResponseDto>> AddBook(AddBookDto model);
        Task<ResponseDto<UpdateBookResponseDto>> UpdateBook(UpdateBookDto model);
        Task<ResponseDto<Pagination<GetBookDto>>> GetBook(BookResourceParameters bookResource);

        public Task<ResponseDto<Pagination<GetBookDto>>> GetByCategory(string CategoryName, int pageNumber, int pageSize);

    }
}
