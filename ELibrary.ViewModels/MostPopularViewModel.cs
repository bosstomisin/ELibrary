using System.Collections.Generic;

namespace ELibrary.ViewModels
{
    public class MostPopularViewModel
    {
        public int Total { get; set; }
        public IEnumerable<BookViewModel> Books { get; set; } = new BookViewModel[8];
    }
}