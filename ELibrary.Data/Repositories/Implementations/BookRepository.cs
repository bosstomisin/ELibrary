using ELibrary.Data.Repositories.Abstractions;
using ELibrary.Dtos;
using ELibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.Data.Repositories.Implementations
{
    public class BookRepository: GenericRepository<Book>, IBookRepository
    {
        
        public BookRepository(ELibraryDbContext context): base(context)
        {
            
        }

        public async Task<IQueryable<Book>> GetBookByTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return null;
            }

            title = title.Trim();;

            var bookCollection =  _context.Books.Where(book => book.Title.Contains(title));

            return bookCollection;
        }

    }
}