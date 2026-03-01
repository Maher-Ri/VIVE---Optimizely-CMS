// Models/Blocks/FaqSectionBlock.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Blocks
{
    [ContentType(
        DisplayName = "FAQ Section",
        GUID = "a3f7c2d1-84e6-4b19-9f52-3c7d8e1a0b45",
        Description = "Reusable FAQ section — can be placed on any page"
    )]
    public class FaqSectionBlock : BlockData
    {
        [Display(Name = "Heading Line 1", Description = "e.g: In case you", Order = 10)]
        public virtual string? Heading1 { get; set; }

        [Display(Name = "Heading Line 2", Description = "e.g: missed anything.", Order = 20)]
        public virtual string? Heading2 { get; set; }

        [Display(Name = "FAQ Items", Description = "Add, remove and reorder FAQ items", Order = 30)]
        [AllowedTypes(typeof(FaqItemBlock))]
        public virtual ContentArea? FaqItems { get; set; }
    }
}
