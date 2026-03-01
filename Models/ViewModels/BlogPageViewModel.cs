// Models/ViewModels/BlogPageViewModel.cs
using System.Collections.Generic;
using VIVEcms.Models.Pages;

namespace VIVEcms.Models.ViewModels
{
    public class BlogPageViewModel(BlogPage currentPage) : PageViewModel<BlogPage>(currentPage)
    {
        public BlogPostPage? FeaturedPost { get; set; }
        public List<BlogPostPage> RegularPosts { get; set; } = new();
    }
}
