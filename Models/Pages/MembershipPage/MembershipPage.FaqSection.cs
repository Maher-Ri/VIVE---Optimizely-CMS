// Models/Pages/MembershipPage/MembershipPage.FaqSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using VIVEcms.Models.Blocks;

namespace VIVEcms.Models.Pages
{
    public partial class MembershipPage
    {
        [Display(Name = "Show FAQ Section", Order = 1, GroupName = Tabs.FaqSection)]
        public virtual bool ShowFaqSection { get; set; }

        [Display(Name = "Heading Line 1", Order = 10, GroupName = Tabs.FaqSection)]
        public virtual string? FaqHeading1 { get; set; }

        [Display(Name = "Heading Line 2", Order = 20, GroupName = Tabs.FaqSection)]
        public virtual string? FaqHeading2 { get; set; }

        [Display(Name = "FAQ Items", Order = 30, GroupName = Tabs.FaqSection)]
        [AllowedTypes(typeof(FaqItemBlock))]
        public virtual ContentArea? FaqItems { get; set; }
    }
}
