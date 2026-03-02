// Models/Pages/SingleClassPage/SingleClassPage.StatsSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Pages
{
    public partial class SingleClassPage
    {
        [Display(Name = "Show Stats Section", Order = 1, GroupName = Tabs.StatsSection)]
        public virtual bool ShowStatsSection { get; set; }

        // =============================================
        // STAT 1
        // =============================================
        [Display(
            Name = "Stat 1 Label",
            Order = 10,
            GroupName = Tabs.StatsSection,
            Description = "e.g: Intensity"
        )]
        public virtual string? Stat1Label { get; set; }

        [Display(
            Name = "Stat 1 Value",
            Order = 20,
            GroupName = Tabs.StatsSection,
            Description = "e.g: Medium & High"
        )]
        public virtual string? Stat1Value { get; set; }

        // =============================================
        // STAT 2
        // =============================================
        [Display(
            Name = "Stat 2 Label",
            Order = 30,
            GroupName = Tabs.StatsSection,
            Description = "e.g: Time"
        )]
        public virtual string? Stat2Label { get; set; }

        [Display(
            Name = "Stat 2 Value",
            Order = 40,
            GroupName = Tabs.StatsSection,
            Description = "e.g: 45 mins"
        )]
        public virtual string? Stat2Value { get; set; }

        // =============================================
        // STAT 3
        // =============================================
        [Display(
            Name = "Stat 3 Label",
            Order = 50,
            GroupName = Tabs.StatsSection,
            Description = "e.g: Maximize"
        )]
        public virtual string? Stat3Label { get; set; }

        [Display(
            Name = "Stat 3 Value",
            Order = 60,
            GroupName = Tabs.StatsSection,
            Description = "e.g: Cardio Stamina"
        )]
        public virtual string? Stat3Value { get; set; }

        // =============================================
        // STAT 4
        // =============================================
        [Display(
            Name = "Stat 4 Label",
            Order = 70,
            GroupName = Tabs.StatsSection,
            Description = "e.g: Dates"
        )]
        public virtual string? Stat4Label { get; set; }

        [Display(
            Name = "Stat 4 Value",
            Order = 80,
            GroupName = Tabs.StatsSection,
            Description = "e.g: Mon, Tue, Wed"
        )]
        public virtual string? Stat4Value { get; set; }
    }
}
