// Models/Pages/ClassesPage/ClassesPage.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Pages
{
    [ContentType(
        DisplayName = "Classes Page",
        GUID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
        Description = "The Classes page"
    )]
    public partial class ClassesPage : SitePageData
    {
        [ScaffoldColumn(false)]
        public override string PageCssFile => "post-2952.css";

        // Tabs will be added here as we build sections
        public static class Tabs
        {
            public const string HeaderSection = "Header";
            public const string ServiceCarouselSection = "Services";
            public const string PricingSection = "Pricing";
            public const string FAQSection = "FAQ";
        }
    }
}
