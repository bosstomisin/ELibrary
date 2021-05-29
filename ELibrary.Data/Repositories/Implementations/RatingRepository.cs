using ELibrary.Models;

namespace ELibrary.Data.Repositories.Implementations
{
    public class RatingRepository: GenericRepository<Book>
    {
        public RatingRepository(ELibraryDbContext context): base(context)
        { }
    }
}