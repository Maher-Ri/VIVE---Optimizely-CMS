// Models/Blocks/PricingSectionBlock.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace VIVEcms.Models.Blocks
{
    [ContentType(
        DisplayName = "Pricing Section",
        GUID = "c0f878b4-553b-496f-8212-c1ee6f0cbc5e",
        Description = "Reusable pricing section — can be placed on any page"
    )]
    public class PricingSectionBlock : BlockData
    {
        // =============================================
        // TOP CONTENT
        // =============================================

        [Display(
            Name = "Section Icon",
            Description = "Small icon above the heading e.g: gym-icon.png",
            Order = 10
        )]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? SectionIcon { get; set; }

        [Display(Name = "Heading Line 1", Description = "e.g: Be physically fit", Order = 20)]
        public virtual string? HeadingLine1 { get; set; }

        [Display(Name = "Heading Line 2", Description = "e.g: Join Today", Order = 30)]
        public virtual string? HeadingLine2 { get; set; }

        [Display(Name = "Description", Order = 40)]
        public virtual XhtmlString? Description { get; set; }

        [Display(Name = "Button Text", Description = "e.g: Checkout Classes", Order = 50)]
        public virtual string? ButtonText { get; set; }

        [Display(Name = "Button URL", Description = "e.g: /classes", Order = 60)]
        public virtual string? ButtonUrl { get; set; }

        // =============================================
        // PRICING CARDS
        // =============================================

        [Display(
            Name = "Pricing Cards",
            Description = "Add pricing cards — recommended 3 cards",
            Order = 70
        )]
        [AllowedTypes(typeof(PricingCardBlock))]
        public virtual ContentArea? PricingCards { get; set; }
    }
}
