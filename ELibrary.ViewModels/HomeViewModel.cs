namespace ELibrary.ViewModels
{
    public class HomeViewModel
    {
        public NewReleaseViewModel NewRelease { get; set; } = new NewReleaseViewModel();
        public MostPopularViewModel MostPopular { get; set; } = new MostPopularViewModel();
    }
}