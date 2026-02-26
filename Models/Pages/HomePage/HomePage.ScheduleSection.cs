// Models/Pages/HomePage/HomePage.ScheduleSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using VIVEcms.Models.Blocks;

namespace VIVEcms.Models.Pages
{
    public partial class HomePage
    {
        [Display(
            Name = "Show Schedule Section",
            Description = "Toggle to show or hide this section on the page",
            Order = 1,
            GroupName = "Schedule"
        )]
        public virtual bool ShowScheduleSection { get; set; }

        [Display(
            Name = "Schedule Section",
            Description = "⚠️ Add ONE Schedule block only",
            Order = 10,
            GroupName = "Schedule"
        )]
        [AllowedTypes(typeof(ScheduleSectionBlock))]
        public virtual ContentArea? ScheduleSection { get; set; }
    }
}
