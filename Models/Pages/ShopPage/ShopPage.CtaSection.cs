// Models/Pages/ShopPage/ShopPage.CtaSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace VIVEcms.Models.Pages
{
    public partial class ShopPage
    {
        [Display(
            Name = "CTA Sub-Title",
            Description = "Small heading above main title e.g: Join Today",
            Order = 10,
            GroupName = Tabs.CtaSection
        )]
        public virtual string? CtaSubTitle { get; set; }

        [Display(
            Name = "CTA Title",
            Description = "Large heading e.g: Money Back",
            Order = 20,
            GroupName = Tabs.CtaSection
        )]
        public virtual string? CtaTitle { get; set; }

        [Display(
            Name = "CTA Button Text",
            Description = "e.g: Checkout Classes",
            Order = 30,
            GroupName = Tabs.CtaSection
        )]
        public virtual string? CtaButtonText { get; set; }

        [Display(
            Name = "CTA Button URL",
            Description = "Destination link for the CTA button",
            Order = 40,
            GroupName = Tabs.CtaSection
        )]
        public virtual Url? CtaButtonUrl { get; set; }

        [Display(
            Name = "CTA Background Image",
            Description = "Full-bleed background image for the CTA section",
            Order = 50,
            GroupName = Tabs.CtaSection
        )]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? CtaBackgroundImage { get; set; }
    }
}
