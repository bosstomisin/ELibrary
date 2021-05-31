using ELibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Data.Repositories.Abstractions
{
    public interface IBookRepository
    {
        Task<IQueryable<Book>> GetBookByTitle(string bookTitle);
    }
}
