// Models/Pages/SingleProductPage/SingleProductPage.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Pages
{
    [ContentType(
        DisplayName = "Single Product Page",
        GUID = "b2c3d4e5-f6a7-8901-bcde-f12345678901",
        Description = "A single product page — create as child of Shop Page"
    )]
    public partial class SingleProductPage : SitePageData
    {
        [ScaffoldColumn(false)]
        public override string PageCssFile => "post-2594.css";

        public static class Tabs
        {
            public const string GallerySection = "Gallery";
            public const string ProductSection = "Product Info";
            public const string TabsSection = "Tabs";
            public const string RelatedSection = "Related Products";
        }
    }
}
