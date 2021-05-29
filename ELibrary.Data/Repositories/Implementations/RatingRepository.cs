using System.Linq;
using System.Threading.Tasks;
using ELibrary.Data.Repositories.Abstractions;
using ELibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Data.Repositories.Implementations
{
    public class RatingRepository: GenericRepository<Book>
    {
        public RatingRepository(ELibraryDbContext context): base(context)
        { }
    }
}