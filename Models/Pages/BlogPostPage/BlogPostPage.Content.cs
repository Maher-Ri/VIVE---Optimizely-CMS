// Models/Pages/BlogPostPage/BlogPostPage.Content.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using VIVEcms.Models.Blocks;

namespace VIVEcms.Models.Pages
{
    public partial class BlogPostPage
    {
        [Display(Name = "Intro Content", Order = 10, GroupName = Tabs.PostContent)]
        public virtual XhtmlString? IntroContent { get; set; }

        [Display(Name = "Quote Text", Order = 20, GroupName = Tabs.PostContent)]
        public virtual string? QuoteText { get; set; }

        [Display(Name = "Quote Author", Order = 30, GroupName = Tabs.PostContent)]
        public virtual string? QuoteAuthor { get; set; }

        [Display(Name = "Quote Side Text", Order = 40, GroupName = Tabs.PostContent)]
        public virtual XhtmlString? QuoteSideText { get; set; }

        [Display(Name = "Content Image 1", Order = 50, GroupName = Tabs.PostContent)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? ContentImage1 { get; set; }

        [Display(Name = "Content Image 2", Order = 60, GroupName = Tabs.PostContent)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? ContentImage2 { get; set; }

        [Display(Name = "Sub Heading", Order = 70, GroupName = Tabs.PostContent)]
        public virtual string? SubHeading { get; set; }

        [Display(Name = "Additional Content", Order = 80, GroupName = Tabs.PostContent)]
        public virtual XhtmlString? AdditionalContent { get; set; }

        [Display(
            Name = "Post Content",
            Order = 90,
            GroupName = Tabs.PostContent,
            Description = "Content shown after gallery"
        )]
        public virtual XhtmlString? PostContent { get; set; }

        // Add these after PostContent:

        [Display(
            Name = "Closing Heading",
            Description = "e.g: What hurts today makes you stronger tomorrow.",
            Order = 95,
            GroupName = Tabs.PostContent
        )]
        public virtual string? ClosingHeading { get; set; }

        [Display(
            Name = "Closing Content",
            Description = "Final paragraph after the closing heading",
            Order = 96,
            GroupName = Tabs.PostContent
        )]
        public virtual XhtmlString? ClosingContent { get; set; }

        [Display(Name = "Gallery Images", Order = 100, GroupName = Tabs.PostContent)]
        [AllowedTypes(typeof(GalleryItemBlock))]
        public virtual ContentArea? GalleryImages { get; set; }
    }
}
