// Models/Media/ImageFile.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace VIVEcms.Models.Media // ← added
{
    [ContentType(
        DisplayName = "Image File",
        GUID = "a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d",
        Description = "Handles all image uploads in the CMS"
    )]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,png,gif,svg,webp,bmp")]
    public class ImageFile : ImageData
    {
        [Display(Name = "Alt Text", Order = 10)]
        [Required]
        public virtual string? AltText { get; set; } // ← removed required

        [Display(Name = "Caption", Order = 20)]
        public virtual string? Caption { get; set; } // ← removed
    }
}
