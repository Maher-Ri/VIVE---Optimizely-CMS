// Models/Pages/AboutPage/AboutPage.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Pages
{
    [ContentType(
        DisplayName = "About Page",
        GUID = "30dce7ad-659e-43b1-b269-cc13fe62e362",
        Description = "The About Us page"
    )]
    public partial class AboutPage : SitePageData
    {
        [ScaffoldColumn(false)]
        public override string PageCssFile => "post-3202.css";

        // Tabs will be added here as we build sections
        public static class Tabs
        {
            public const string HeaderSection = "Header";
            public const string CheckoutSection = "Checkout";
            public const string ProcessSection = "Process";
            public const string ScheduleSection = "Schedule";
            public const string ViveTrainerSection = "Vive Trainer";
            // new section tabs will be added here...
        }
    }
}
