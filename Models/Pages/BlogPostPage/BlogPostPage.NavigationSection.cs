// Models/Pages/BlogPostPage/BlogPostPage.NavigationSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Pages
{
    public partial class BlogPostPage
    {
        [Display(
            Name = "Show Navigation",
            Description = "Toggle to show or hide previous article navigation",
            Order = 1,
            GroupName = Tabs.NavigationSection
        )]
        public virtual bool ShowNavigation { get; set; }
    }
}
