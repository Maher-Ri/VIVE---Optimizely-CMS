// Models/Pages/BlogPostPage/BlogPostPage.RelatedSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Pages
{
    public partial class BlogPostPage
    {
        [Display(
            Name = "Show Related Articles",
            Description = "Toggle to show or hide related articles",
            Order = 1,
            GroupName = Tabs.RelatedSection
        )]
        public virtual bool ShowRelatedSection { get; set; }

        [Display(
            Name = "Related Articles",
            Description = "Add up to 2 related blog posts",
            Order = 10,
            GroupName = Tabs.RelatedSection
        )]
        [AllowedTypes(typeof(BlogPostPage))]
        public virtual ContentArea? RelatedPosts { get; set; }
    }
}
