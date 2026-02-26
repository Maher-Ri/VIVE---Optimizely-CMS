// Models/Blocks/NavMegaPreviewBlock.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace VIVEcms.Models.Blocks
{
    [ContentType(
        DisplayName = "Nav Mega Preview",
        GUID = "fdf3d6de-faee-4130-b74c-216d9ee34b57",
        Description = "A preview image card inside the mega menu dropdown"
    )]
    public class NavMegaPreviewBlock : BlockData
    {
        [Display(
            Name = "Preview Image",
            Description = "Thumbnail image shown in the mega menu",
            Order = 10
        )]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? PreviewImage { get; set; }

        [Display(
            Name = "URL",
            Description = "Where clicking the image goes e.g: /home",
            Order = 20
        )]
        public virtual string? Url { get; set; }

        [Display(
            Name = "Label",
            Description = "Text shown below the image e.g: Home 1",
            Order = 30
        )]
        public virtual string? Label { get; set; }
    }
}
