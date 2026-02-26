// Models/Pages/HomePage/HomePage.ViveTrainerSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using VIVEcms.Models.Blocks;

namespace VIVEcms.Models.Pages
{
    public partial class HomePage
    {
        // ✅ Show/Hide toggle — same as all other sections
        [Display(
            Name = "Show Vive Trainer Section",
            Description = "Toggle to show or hide this section on the page",
            Order = 1,
            GroupName = "Vive Trainer"
        )]
        public virtual bool ShowViveTrainerSection { get; set; }

        // ✅ Only ONE block — description warns the editor
        [Display(
            Name = "Vive Trainer Section",
            Description = "⚠️ Add ONE ViveTrainerSectionBlock only",
            Order = 10,
            GroupName = "Vive Trainer"
        )]
        [AllowedTypes(typeof(ViveTrainerSectionBlock))]
        public virtual ContentArea? ViveTrainerSection { get; set; }
    }
}
