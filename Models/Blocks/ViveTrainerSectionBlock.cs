// Models/Blocks/ViveTrainerSectionBlock.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Blocks
{
    [ContentType(
        DisplayName = "Vive Trainer",
        GUID = "437c5f3f-233e-4826-8046-c25d48e88143",
        Description = "Reusable gallery grid section — can be placed on any page"
    )]
    public class ViveTrainerSectionBlock : BlockData
    {
        [Display(Name = "Heading", Description = "e.g: @vivetrainer", Order = 10)]
        public virtual string? Heading { get; set; }

        [Display(
            Name = "Gallery Items",
            Description = "Add gallery images — recommended 5 items",
            Order = 20
        )]
        [AllowedTypes(typeof(GalleryItemBlock))]
        public virtual ContentArea? GalleryItems { get; set; }
    }
}
