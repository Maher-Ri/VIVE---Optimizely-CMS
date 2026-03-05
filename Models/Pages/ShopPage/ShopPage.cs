// Models/Pages/ShopPage/ShopPage.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Pages
{
    [ContentType(
        DisplayName = "Shop Page",
        GUID = "4bed9be7-7081-4ba7-a314-e62a55192e11",
        Description = "The Shop listing page — add Single Product Pages as children"
    )]
    public partial class ShopPage : SitePageData
    {
        [ScaffoldColumn(false)]
        public override string PageCssFile => "post-4019.css";

        public static class Tabs
        {
            public const string HeroSection = "Hero";
            public const string TrendExplorer = "Trend Explorer";
            public const string CategoryBanners = "Category Banners";
            public const string CtaSection = "CTA";
        }
    }
}
