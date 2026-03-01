// Models/Pages/BlogPage/BlogPage.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Pages
{
    [ContentType(
        DisplayName = "Blog Page",
        GUID = "38decdfe-977c-4b57-85a8-f03a9eac9a7b",
        Description = "The Blog listing page — add Blog Post Pages as children"
    )]
    public partial class BlogPage : SitePageData
    {
        [ScaffoldColumn(false)]
        public override string PageCssFile => "post-3810.css";
    }
}
