// Models/Blocks/PricingCardBlock.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Blocks
{
    [ContentType(
        DisplayName = "Pricing Card",
        GUID = "f67a9da1-39f5-4a1f-9396-5ce738e62d2b",
        Description = "A single pricing card inside the Pricing section"
    )]
    public class PricingCardBlock : BlockData
    {
        [Display(
            Name = "Title",
            Description = "e.g: One Day Pass, Month Pass, Yearly Pass",
            Order = 10
        )]
        public virtual string? Title { get; set; }

        [Display(Name = "Price", Description = "e.g: $9.9/day", Order = 20)]
        public virtual string? Price { get; set; }

        [Display(Name = "Validity", Description = "e.g: Valid 90 days", Order = 30)]
        public virtual string? Validity { get; set; }

        [Display(
            Name = "Features",
            Description = "Comma-separated e.g: 24 hours access,Unlimited Classes,BMI Tracker",
            Order = 40
        )]
        public virtual string? Features { get; set; }
    }
}
