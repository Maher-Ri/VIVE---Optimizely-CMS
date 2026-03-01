// Models/Pages/BlogPostPage/BlogPostPage.HeaderSection.cs
using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace VIVEcms.Models.Pages
{
    public partial class BlogPostPage
    {
        [Display(
            Name = "Post Date",
            Description = "Publication date e.g: October 9, 2021",
            Order = 10,
            GroupName = Tabs.HeaderSection
        )]
        public virtual DateTime PostDate { get; set; }

        [Display(
            Name = "Featured Image",
            Description = "Background image for the header",
            Order = 20,
            GroupName = Tabs.HeaderSection
        )]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? FeaturedImage { get; set; }

        [Display(
            Name = "Author Name",
            Description = "e.g: Jonathan Simmons",
            Order = 30,
            GroupName = Tabs.HeaderSection
        )]
        public virtual string? AuthorName { get; set; }

        [Display(
            Name = "Author Avatar",
            Description = "Author profile photo",
            Order = 40,
            GroupName = Tabs.HeaderSection
        )]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? AuthorAvatar { get; set; }

        [Display(
            Name = "Tags",
            Description = "Comma-separated e.g: Lifestyle,Training",
            Order = 50,
            GroupName = Tabs.HeaderSection
        )]
        public virtual string? Tags { get; set; }
    }
}
