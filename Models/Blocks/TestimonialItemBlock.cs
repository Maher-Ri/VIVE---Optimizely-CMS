// Models/Blocks/TestimonialItemBlock.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace VIVEcms.Models.Blocks
{
    [ContentType(
        DisplayName = "Testimonial Item",
        GUID = "5b87c21c-19f8-4b16-a118-e93a2095f23d",
        Description = "A single testimonial in the Our Customers section"
    )]
    public class TestimonialItemBlock : BlockData
    {
        [Display(Name = "Quote", Description = "The testimonial text", Order = 10)]
        public virtual string? Quote { get; set; }

        [Display(
            Name = "Thumbnail Image",
            Description = "Person's photo (recommended: 150x150)",
            Order = 20
        )]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? ThumbImage { get; set; }

        [Display(Name = "Name", Description = "e.g: Jonathan Smith", Order = 30)]
        public virtual string? Name { get; set; }

        [Display(Name = "Designation", Description = "e.g: Athlete", Order = 40)]
        public virtual string? Designation { get; set; }
    }
}
