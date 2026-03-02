// Models/Pages/SingleClassPage/SingleClassPage.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Pages
{
    [ContentType(
        DisplayName = "Single Class Page",
        GUID = "1397e025-bc3e-487d-8e88-ccef0117032c",
        Description = "A single class detail page"
    )]
    public partial class SingleClassPage : SitePageData
    {
        [ScaffoldColumn(false)]
        public override string PageCssFile => "post-2984.css";
        public static class Tabs
        {
            public const string HeaderSection = "Header";
            public const string StatsSection = "Stats";
            public const string BenefitsSection = "Benefits";
            public const string TrainersSection = "Trainers";
            public const string PricingSection = "Pricing";
            public const string ViveTrainerSection = "Vive Trainer";
        }
    }
}
