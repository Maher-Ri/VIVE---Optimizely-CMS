// Models/Pages/MembershipPage/MembershipPage.PricingSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using VIVEcms.Models.Blocks;

namespace VIVEcms.Models.Pages
{
    public partial class MembershipPage
    {
        [Display(
            Name = "Show Pricing Section",
            Description = "Toggle to show or hide this section",
            Order = 1,
            GroupName = Tabs.PricingSection
        )]
        public virtual bool ShowPricingSection { get; set; }

        [Display(
            Name = "Pricing Section",
            Description = "⚠️ Add ONE PricingSectionBlock only",
            Order = 10,
            GroupName = Tabs.PricingSection
        )]
        [AllowedTypes(typeof(PricingSectionBlock))]
        public virtual ContentArea? PricingSection { get; set; }
    }
}
