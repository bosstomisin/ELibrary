using ELibrary.Models;

namespace ELibrary.Data.Repositories.Implementations
{
    public class ReviewRepository: GenericRepository<Book>
    {
        public ReviewRepository(ELibraryDbContext context): base(context)
        { }
    }
}