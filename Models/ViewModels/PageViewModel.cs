using VIVEcms.Models.Pages;
// This is a generic class. It will take any page type (like HomePage, AboutPage, etc.) and combine it with the LayoutModel.
namespace VIVEcms.Models.ViewModels
{
    // The <T> means this can accept ANY class that inherits from SitePageData
    public class PageViewModel<T> : IPageViewModel where T : SitePageData
    {
        public T CurrentPage { get; private set; }
        SitePageData IPageViewModel.CurrentPage => CurrentPage;
        public LayoutModel Layout { get; set; }

        public PageViewModel(T currentPage)
        {
            CurrentPage = currentPage;
            Layout = new LayoutModel();
        }
    }
}
