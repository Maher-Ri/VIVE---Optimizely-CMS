// Models/Pages/AboutPage/AboutPage.ViveTrainerSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using VIVEcms.Models.Blocks;

namespace VIVEcms.Models.Pages
{
    public partial class AboutPage
    {
        [Display(
            Name = "Show Vive Trainer Section",
            Description = "Toggle to show or hide this section on the page",
            Order = 1,
            GroupName = Tabs.ViveTrainerSection
        )]
        public virtual bool ShowViveTrainerSection { get; set; }

        [Display(
            Name = "Vive Trainer Section",
            Description = "⚠️ Add ONE ViveTrainerSectionBlock only",
            Order = 10,
            GroupName = Tabs.ViveTrainerSection
        )]
        [AllowedTypes(typeof(ViveTrainerSectionBlock))]
        public virtual ContentArea? ViveTrainerSection { get; set; }
    }
}
