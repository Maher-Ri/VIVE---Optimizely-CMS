// Models/Pages/OurTeamPage/OurTeamPage.HeaderSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Pages
{
    public partial class OurTeamPage
    {
        [Display(
            Name = "Show Header Section",
            Description = "Toggle to show or hide this section",
            Order = 1,
            GroupName = Tabs.HeaderSection
        )]
        public virtual bool ShowHeaderSection { get; set; }

        [Display(
            Name = "Heading Line 1",
            Description = "e.g: Our Trainers",
            Order = 10,
            GroupName = Tabs.HeaderSection
        )]
        public virtual string? HeaderHeading1 { get; set; }

        [Display(
            Name = "Heading Line 2",
            Description = "e.g: We Trained",
            Order = 20,
            GroupName = Tabs.HeaderSection
        )]
        public virtual string? HeaderHeading2 { get; set; }

        [Display(
            Name = "Heading Line 3",
            Description = "e.g: you to gain",
            Order = 30,
            GroupName = Tabs.HeaderSection
        )]
        public virtual string? HeaderHeading3 { get; set; }

        [Display(
            Name = "Description",
            Description = "Paragraph text on the right column",
            Order = 40,
            GroupName = Tabs.HeaderSection
        )]
        public virtual XhtmlString? HeaderDescription { get; set; }
    }
}
