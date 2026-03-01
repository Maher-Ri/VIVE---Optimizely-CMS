// Models/Pages/AboutPage/AboutPage.HeaderSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace VIVEcms.Models.Pages
{
    public partial class AboutPage
    {
        [Display(
            Name = "Show Header Section",
            Description = "Toggle to show or hide this section",
            Order = 1,
            GroupName = Tabs.HeaderSection
        )]
        public virtual bool ShowHeaderSection { get; set; }

        [Display(
            Name = "Background Image", // ← add this
            Description = "Header section background image",
            Order = 5,
            GroupName = Tabs.HeaderSection
        )]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? HeaderBackgroundImage { get; set; }

        [Display(
            Name = "Heading Line 1",
            Description = "e.g: Speak",
            Order = 10,
            GroupName = Tabs.HeaderSection
        )]
        public virtual string? HeaderHeading1 { get; set; }

        [Display(
            Name = "Heading Line 2",
            Description = "e.g: Fitness",
            Order = 20,
            GroupName = Tabs.HeaderSection
        )]
        public virtual string? HeaderHeading2 { get; set; }

        [Display(
            Name = "Heading Line 3",
            Description = "e.g: With Your",
            Order = 30,
            GroupName = Tabs.HeaderSection
        )]
        public virtual string? HeaderHeading3 { get; set; }

        [Display(
            Name = "Animated Words",
            Description = "Comma-separated e.g: Work,Wellbeing,Body",
            Order = 40,
            GroupName = Tabs.HeaderSection
        )]
        public virtual string? HeaderAnimatedWords { get; set; }
    }
}
