using ELibrary.Dtos;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.Core.Abstractions
{
   public interface IBookService
   {
        public Task<ResponseDto<IQueryable<BookDto>>> GetByCategory(string CategoryName, int pageNumber, int pageSize);
   }
}
