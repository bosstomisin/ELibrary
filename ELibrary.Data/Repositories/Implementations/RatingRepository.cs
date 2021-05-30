using ELibrary.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ELibrary.Data.Repositories.Implementations
{
    public class RatingRepository: GenericRepository<Book>
    {
        public RatingRepository(ELibraryDbContext context): base(context)
        { 
        }
    }
}