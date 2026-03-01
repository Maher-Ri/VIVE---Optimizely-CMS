using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using VIVEcms.Models.Blocks;

namespace VIVEcms.Models.Pages
{
    public partial class ClassesPage
    {
        [Display(Name = "Show FAQ Section", Order = 1, GroupName = Tabs.FAQSection)]
        public virtual bool ShowFaqSection { get; set; }

        [Display(Name = "Heading Line 1", Order = 10, GroupName = Tabs.FAQSection)]
        public virtual string? FaqHeading1 { get; set; }

        [Display(Name = "Heading Line 2", Order = 20, GroupName = Tabs.FAQSection)]
        public virtual string? FaqHeading2 { get; set; }

        [Display(Name = "FAQ Items", Order = 30, GroupName = Tabs.FAQSection)]
        [AllowedTypes(typeof(FaqItemBlock))]
        public virtual ContentArea? FaqItems { get; set; }
    }
}
