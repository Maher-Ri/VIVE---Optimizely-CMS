// Models/Pages/SingleProductPage/SingleProductPage.GallerySection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using VIVEcms.Models.Blocks;

namespace VIVEcms.Models.Pages
{
    public partial class SingleProductPage
    {
        [Display(
            Name = "Main Product Image",
            Description = "Primary large image shown in the gallery",
            Order = 10,
            GroupName = Tabs.GallerySection
        )]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? MainImage { get; set; }

        [Display(
            Name = "Gallery Thumbnails",
            Description = "Add additional product images as GalleryItemBlock entries",
            Order = 20,
            GroupName = Tabs.GallerySection
        )]
        [AllowedTypes(typeof(GalleryItemBlock))]
        public virtual ContentArea? GalleryThumbnails { get; set; }
    }
}
