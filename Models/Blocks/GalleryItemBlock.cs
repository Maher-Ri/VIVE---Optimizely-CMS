// Models/Blocks/GalleryItemBlock.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace VIVEcms.Models.Blocks
{
    [ContentType(
        DisplayName = "Gallery Item",
        GUID = "53cdd564-44d9-4bf7-b9be-368a4773aa46",
        Description = "A single image item in the gallery grid"
    )]
    public class GalleryItemBlock : BlockData
    {
        [Display(
            Name = "Image",
            Description = "Main display image (recommended: 610x610)",
            Order = 10
        )]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? Image { get; set; }

        [Display(
            Name = "Thumbnail Image",
            Description = "Small preview for lightbox (recommended: 300x300). If empty uses main image.",
            Order = 20
        )]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? ThumbnailImage { get; set; }
    }
}
