// Models/Pages/ClassesPage/ClassesPage.HeaderSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Pages
{
    public partial class ClassesPage
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
            Description = "e.g: Focus on Your",
            Order = 10,
            GroupName = Tabs.HeaderSection
        )]
        public virtual string? HeaderHeading1 { get; set; }

        [Display(
            Name = "Heading Line 2",
            Description = "e.g: Fitness not",
            Order = 20,
            GroupName = Tabs.HeaderSection
        )]
        public virtual string? HeaderHeading2 { get; set; }

        [Display(
            Name = "Heading Line 3",
            Description = "e.g: your Loss",
            Order = 30,
            GroupName = Tabs.HeaderSection
        )]
        public virtual string? HeaderHeading3 { get; set; }
    }
}
