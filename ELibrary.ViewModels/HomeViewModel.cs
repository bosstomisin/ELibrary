using System.Collections.Generic;

namespace ELibrary.ViewModels
{
    public class HomeViewModel
    {
        public  IEnumerable<CategoryViewModel> Categories { get; set; }
        public IEnumerable<BookViewModel> MostPopularBooks { get; set; } = new BookViewModel[8];
        public IEnumerable<BookViewModel> NewestBooks { get; set; } = new BookViewModel[8];
        // public NewReleaseViewModel NewRelease { get; set; } = new NewReleaseViewModel();
        // public MostPopularViewModel MostPopular { get; set; } = new MostPopularViewModel();
    }
}