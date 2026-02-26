using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace VIVEcms.Models.Pages
{
    // We make this abstract because we never want an editor to create a "SitePageData" directly.
    // They will create specific pages like "HomePage" that inherit from this.
    public abstract class SitePageData : PageData
    {
        [Display(
            Name = "Meta Title",
            Description = "The SEO title of the page.",
            GroupName = "SEO", // This creates a dedicated "SEO" tab in the CMS editor
            Order = 1
        )]
        public virtual required string MetaTitle { get; set; }

        [Display(
            Name = "Meta Description",
            Description = "The SEO description of the page.",
            GroupName = "SEO",
            Order = 2
        )]
        [UIHint(UIHint.Textarea)] // This tells Optimizely to render a multi-line text box
        public virtual required string MetaDescription { get; set; }

        [Display(Name = "Meta Keywords", GroupName = "SEO", Order = 3)]
        public virtual required string MetaKeywords { get; set; }
    }
}
