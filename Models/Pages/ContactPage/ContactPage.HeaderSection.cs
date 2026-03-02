// Models/Pages/ContactPage/ContactPage.HeaderSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Pages
{
    public partial class ContactPage
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
            Description = "e.g: Contact US",
            Order = 100,
            GroupName = Tabs.HeaderSection
        )]
        public virtual string? HeaderHeading1 { get; set; }

        [Display(
            Name = "Heading Line 2",
            Description = "e.g: At Our Gym",
            Order = 200,
            GroupName = Tabs.HeaderSection
        )]
        public virtual string? HeaderHeading2 { get; set; }
    }
}
