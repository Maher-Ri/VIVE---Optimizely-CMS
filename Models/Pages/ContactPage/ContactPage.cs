// Models/Pages/ContactPage/ContactPage.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Pages
{
    [ContentType(
        DisplayName = "Contact Page",
        GUID = "095fd80f-c8a1-4619-9fd9-d335d0bba7b3",
        Description = "The Contact page"
    )]
    public partial class ContactPage : SitePageData
    {
        [ScaffoldColumn(false)]
        public override string PageCssFile => "post-3374.css";

        public static class Tabs
        {
            public const string HeaderSection = "Header";
            public const string ContactFormSection = "Contact Form";
        }
    }
}
