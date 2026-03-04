// Models/Pages/MembershipPage/MembershipPage.CtaSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.Web;

namespace VIVEcms.Models.Pages
{
    public partial class MembershipPage
    {
        [Display(
            Name = "Show CTA Section",
            Description = "Toggle to show or hide this section",
            Order = 1,
            GroupName = Tabs.CtaSection
        )]
        public virtual bool ShowCtaSection { get; set; }

        // ── Left column ──────────────────────────────────────────
        [Display(Name = "Left Background Image", Order = 5, GroupName = Tabs.CtaSection)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? CtaLeftBackgroundImage { get; set; }

        [Display(Name = "Left Heading", Order = 10, GroupName = Tabs.CtaSection)]
        public virtual string? CtaLeftHeading { get; set; }

        [Display(Name = "Left Button Text", Order = 20, GroupName = Tabs.CtaSection)]
        public virtual string? CtaLeftButtonText { get; set; }

        [Display(Name = "Left Button URL", Order = 30, GroupName = Tabs.CtaSection)]
        public virtual string? CtaLeftButtonUrl { get; set; }

        // ── Right column ─────────────────────────────────────────
        [Display(Name = "Right Background Image", Order = 35, GroupName = Tabs.CtaSection)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? CtaRightBackgroundImage { get; set; }

        [Display(Name = "Right Heading", Order = 40, GroupName = Tabs.CtaSection)]
        public virtual string? CtaRightHeading { get; set; }

        [Display(Name = "Right Button Text", Order = 50, GroupName = Tabs.CtaSection)]
        public virtual string? CtaRightButtonText { get; set; }

        [Display(Name = "Right Button URL", Order = 60, GroupName = Tabs.CtaSection)]
        public virtual string? CtaRightButtonUrl { get; set; }
    }
}
