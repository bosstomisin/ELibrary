using System.Collections.Generic;
using System.Threading.Tasks;
using ELibrary.Data.Repositories.Implementations;
using ELibrary.Dtos;
using ELibrary.Models;

namespace ELibrary.Core.Abstractions
{
    public interface IBookServices
    {
        Task<ResponseDto<Pagination<GetBookDto>>> GetAll(int pageIndex);
        Task<ResponseDto<bool>> DeleteById(int bookId);
    }
}