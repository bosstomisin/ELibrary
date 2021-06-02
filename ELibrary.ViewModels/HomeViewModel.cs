using System.Collections.Generic;

namespace ELibrary.ViewModels
{
    public class HomeViewModel
    {
        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
        public List<BookViewModel> Books { get; set; } = new List<BookViewModel>();
        public SearchViewModel searchViewModel { get; set; } = new SearchViewModel();
        // public List<BookViewModel> MostPopularBooks { get; set; }
        // public List<BookViewModel> NewestBooks { get; set; } 
        // public NewReleaseViewModel NewRelease { get; set; } = new NewReleaseViewModel();
        // public MostPopularViewModel MostPopular { get; set; } = new MostPopularViewModel();
    }
}