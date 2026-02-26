using VIVEcms.Models.Pages;
//Because _Layout.cshtml is shared across all pages, it doesn't know if it's currently displaying a HomePage or an AboutPage.
//To make our Layout strongly-typed so it can read the SEO data and Layout data safely, we need a quick tiny interface.
namespace VIVEcms.Models.ViewModels
{
    // This allows our Layout to accept ANY page view model
    public interface IPageViewModel
    {
        SitePageData CurrentPage { get; }
        LayoutModel Layout { get; set; }
    }
}