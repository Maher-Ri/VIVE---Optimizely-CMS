// Models/Blocks/ScheduleSectionBlock.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace VIVEcms.Models.Blocks
{
    [ContentType(
        DisplayName = "Schedule",
        GUID = "d5869e57-b6cf-4d69-8bcc-7f482ed751aa",
        Description = "Reusable schedule section — can be placed on any page"
    )]
    public class ScheduleSectionBlock : BlockData
    {
        // =============================================
        // LEFT COLUMN — Animated Heading Lines
        // =============================================

        [Display(Name = "Heading Line 1", Description = "e.g: Focus on", Order = 10)]
        public virtual string? HeadingLine1 { get; set; }

        [Display(Name = "Heading Line 2", Description = "e.g: Your", Order = 20)]
        public virtual string? HeadingLine2 { get; set; }

        [Display(Name = "Heading Line 3", Description = "e.g: Fitness", Order = 30)]
        public virtual string? HeadingLine3 { get; set; }

        [Display(Name = "Heading Line 4", Description = "e.g: not your", Order = 40)]
        public virtual string? HeadingLine4 { get; set; }

        [Display(Name = "Heading Line 5", Description = "e.g: Loss", Order = 50)]
        public virtual string? HeadingLine5 { get; set; }

        // =============================================
        // LEFT COLUMN — Description + Button
        // =============================================

        [Display(Name = "Description", Order = 60)]
        public virtual XhtmlString? Description { get; set; }

        [Display(Name = "Button Text", Description = "e.g: Schedule a Workout", Order = 70)]
        public virtual string? ButtonText { get; set; }

        [Display(Name = "Button URL", Description = "e.g: /schedule", Order = 80)]
        public virtual string? ButtonUrl { get; set; }

        // =============================================
        // RIGHT COLUMN — Image
        // =============================================

        [Display(Name = "Section Image", Order = 90)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? SectionImage { get; set; }
    }
}
