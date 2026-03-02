// Models/Pages/SingleClassPage/SingleClassPage.PricingSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace VIVEcms.Models.Pages
{
    public partial class SingleClassPage
    {
        [Display(Name = "Show Pricing Section", Order = 1, GroupName = Tabs.PricingSection)]
        public virtual bool ShowPricingSection { get; set; }

        // =============================================
        // LEFT COLUMN
        // =============================================
        [Display(Name = "Left Image", Order = 10, GroupName = Tabs.PricingSection)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? PricingLeftImage { get; set; }

        // =============================================
        // RIGHT COLUMN — Headings
        // =============================================
        [Display(
            Name = "Heading Line 1",
            Order = 20,
            GroupName = Tabs.PricingSection,
            Description = "e.g: Unlimited"
        )]
        public virtual string? PricingHeading1 { get; set; }

        [Display(
            Name = "Heading Line 2",
            Order = 30,
            GroupName = Tabs.PricingSection,
            Description = "e.g: Classes"
        )]
        public virtual string? PricingHeading2 { get; set; }

        // =============================================
        // PRICING CARD
        // =============================================
        [Display(
            Name = "Card Title",
            Order = 40,
            GroupName = Tabs.PricingSection,
            Description = "e.g: One Day Pass"
        )]
        public virtual string? CardTitle { get; set; }

        [Display(
            Name = "Card Price",
            Order = 50,
            GroupName = Tabs.PricingSection,
            Description = "e.g: $9.9/day"
        )]
        public virtual string? CardPrice { get; set; }

        [Display(
            Name = "Card Validity",
            Order = 60,
            GroupName = Tabs.PricingSection,
            Description = "e.g: Valid 90 days"
        )]
        public virtual string? CardValidity { get; set; }

        [Display(
            Name = "Card Features",
            Order = 70,
            GroupName = Tabs.PricingSection,
            Description = "Comma-separated e.g: 24 hours access,Unlimited Classes,BMI Tracker"
        )]
        public virtual string? CardFeatures { get; set; }
    }
}
