// Models/Pages/SingleClassPage/SingleClassPage.ViveTrainerSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using VIVEcms.Models.Blocks;

namespace VIVEcms.Models.Pages
{
    public partial class SingleClassPage
    {
        [Display(
            Name = "Show Vive Trainer Section",
            Order = 1,
            GroupName = Tabs.ViveTrainerSection
        )]
        public virtual bool ShowViveTrainerSection { get; set; }

        [Display(
            Name = "Vive Trainer Section",
            Order = 10,
            GroupName = Tabs.ViveTrainerSection,
            Description = "⚠️ Add ONE ViveTrainerSectionBlock only"
        )]
        [AllowedTypes(typeof(ViveTrainerSectionBlock))]
        public virtual ContentArea? ViveTrainerSection { get; set; }
    }
}
