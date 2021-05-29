using ELibrary.Models;

namespace ELibrary.Data.Repositories.Implementations
{
    public class BookRepository: GenericRepository<Book>
    {
        public BookRepository(ELibraryDbContext context): base(context)
        { }
    }
}