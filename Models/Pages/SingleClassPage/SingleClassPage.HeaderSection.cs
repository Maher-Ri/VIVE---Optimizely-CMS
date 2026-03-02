// Models/Pages/SingleClassPage/SingleClassPage.HeaderSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Pages
{
    public partial class SingleClassPage
    {
        [Display(Name = "Show Header Section", Order = 1, GroupName = Tabs.HeaderSection)]
        public virtual bool ShowHeaderSection { get; set; }

        [Display(
            Name = "Heading Line 1",
            Order = 10,
            GroupName = Tabs.HeaderSection,
            Description = "e.g: High"
        )]
        public virtual string? HeaderHeading1 { get; set; }

        [Display(
            Name = "Heading Line 2",
            Order = 20,
            GroupName = Tabs.HeaderSection,
            Description = "e.g: Intensity (displayed in italic)"
        )]
        public virtual string? HeaderHeading2 { get; set; }

        [Display(
            Name = "Heading Line 3",
            Order = 30,
            GroupName = Tabs.HeaderSection,
            Description = "e.g: Training"
        )]
        public virtual string? HeaderHeading3 { get; set; }

        [Display(
            Name = "Button Text",
            Order = 40,
            GroupName = Tabs.HeaderSection,
            Description = "e.g: Schedule Workout"
        )]
        public virtual string? HeaderButtonText { get; set; }

        [Display(
            Name = "Button URL",
            Order = 50,
            GroupName = Tabs.HeaderSection,
            Description = "e.g: /schedule"
        )]
        public virtual string? HeaderButtonUrl { get; set; }

        [Display(
            Name = "Video Text",
            Order = 60,
            GroupName = Tabs.HeaderSection,
            Description = "e.g: See Sample Class"
        )]
        public virtual string? HeaderVideoText { get; set; }

        [Display(
            Name = "Video URL",
            Order = 70,
            GroupName = Tabs.HeaderSection,
            Description = "e.g: https://www.youtube.com/watch?v=XXXXX"
        )]
        public virtual string? HeaderVideoUrl { get; set; }
    }
}
