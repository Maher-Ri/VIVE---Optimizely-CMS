using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.Web;

namespace VIVEcms.Models.Pages
{
    public partial class HomePage
    {
        [Display(
            Name = "Show Our Classes Section",
            Description = "Toggle to show or hide this section on the page",
            Order = 1,
            GroupName = Tabs.OurClassesSection
        )]
        public virtual bool ShowOurClassesSection { get; set; }

        // --- Left Column ---
        [Display(
            Name = "Heading Line 1",
            Description = "e.g: Our Classes",
            Order = 10,
            GroupName = Tabs.OurClassesSection
        )]
        public virtual string? OurClassesHeading1 { get; set; }

        [Display(
            Name = "Heading Line 2",
            Description = "e.g: Health is a",
            Order = 20,
            GroupName = Tabs.OurClassesSection
        )]
        public virtual string? OurClassesHeading2 { get; set; }

        [Display(
            Name = "Heading Line 3",
            Description = "e.g: priority here",
            Order = 30,
            GroupName = Tabs.OurClassesSection
        )]
        public virtual string? OurClassesHeading3 { get; set; }

        // --- Right Column ---
        [Display(
            Name = "Description",
            Description = "Paragraph text displayed on the right column",
            Order = 40,
            GroupName = Tabs.OurClassesSection
        )]
        public virtual XhtmlString? OurClassesDescription { get; set; }
    }
}
