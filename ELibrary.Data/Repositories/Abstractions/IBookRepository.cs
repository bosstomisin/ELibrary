using ELibrary.Models;
using System.Linq;


namespace ELibrary.Data.Repositories.Abstractions
{
    public interface IBookRepository: IRepository<Book>
    {
        IQueryable<Book> GetByCategoryName(string categoryName);
    }
}
