// Models/Pages/OurTeamPage/OurTeamPage.TeamSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using VIVEcms.Models.Blocks;

namespace VIVEcms.Models.Pages
{
    public partial class OurTeamPage
    {
        [Display(
            Name = "Show Team Section",
            Description = "Toggle to show or hide this section",
            Order = 1,
            GroupName = Tabs.TeamSection
        )]
        public virtual bool ShowTeamSection { get; set; }

        [Display(
            Name = "Carousel 1 — Trainers",
            Description = "First row of trainer cards",
            Order = 10,
            GroupName = Tabs.TeamSection
        )]
        [AllowedTypes(typeof(TrainerItemBlock))]
        public virtual ContentArea? Carousel1Members { get; set; }

        [Display(
            Name = "Carousel 2 — Trainers",
            Description = "Second row of trainer cards",
            Order = 20,
            GroupName = Tabs.TeamSection
        )]
        [AllowedTypes(typeof(TrainerItemBlock))]
        public virtual ContentArea? Carousel2Members { get; set; }
    }
}
