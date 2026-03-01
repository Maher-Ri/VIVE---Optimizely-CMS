// Controllers/BlogPageController.cs
using EPiServer;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using VIVEcms.Models.Pages;
using VIVEcms.Models.ViewModels;
using VIVEcms.Services;

namespace VIVEcms.Controllers
{
    public class BlogPageController : PageController<BlogPage>
    {
        private readonly IContentLoader _contentLoader;
        private readonly ILayoutService _layoutService;

        public BlogPageController(IContentLoader contentLoader, ILayoutService layoutService)
        {
            _contentLoader = contentLoader;
            _layoutService = layoutService;
        }

        public IActionResult Index(BlogPage currentPage)
        {
            // @* Fetch all BlogPostPage children from content tree *@
            var blogPosts = _contentLoader
                .GetChildren<BlogPostPage>(currentPage.ContentLink)
                .OrderByDescending(p => p.PostDate)
                .ToList();

            var model = new BlogPageViewModel(currentPage)
            {
                FeaturedPost = blogPosts.FirstOrDefault(),
                RegularPosts = blogPosts.Skip(1).ToList(),
                Layout = _layoutService.GetLayoutModel(),
            };

            return View(model);
        }
    }
}
