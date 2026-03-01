// Models/Pages/BlogPostPage/BlogPostPage.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Pages
{
    [ContentType(
        DisplayName = "Blog Post Page",
        GUID = "146b3289-479e-4e09-94dc-a788e3cd6c81",
        Description = "A single blog post — create as child of Blog Page"
    )]
    public partial class BlogPostPage : SitePageData
    {
        [ScaffoldColumn(false)]
        public override string PageCssFile => "post-3599.css";

        public static class Tabs
        {
            public const string HeaderSection = "Header"; // ← add
            public const string PostContent = "Post Content";
            public const string RelatedSection = "Related Articles";
            public const string CommentSection = "Comments";
            public const string NavigationSection = "Navigation";
        }
    }
}
