using ELibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ELibrary.Data.Repositories.Implementations
{
    public class BookRepository: GenericRepository<Book>
    {
        private ELibraryDbContext _context;
        public BookRepository(ELibraryDbContext context): base(context)
        {
        }
        public IQueryable<Book> GetByCategory(string CategoryName)
        {
            var booksReturned = _context.Books
                .Where(e => e.Category.Name == CategoryName)
                .Include(e => e.Category)
                .Include(e => e.Reviews)
                .Include(e => e.Rate);
            return booksReturned;
        }
    }
}