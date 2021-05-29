using System.Linq;
using System.Threading.Tasks;
using ELibrary.Data.Repositories.Abstractions;
using ELibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Data.Repositories.Implementations
{
    public class BookRepository: GenericRepository<Book>
    {
        public BookRepository(ELibraryDbContext context): base(context)
        { }
    }
}