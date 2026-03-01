// Models/Pages/ContactPage/ContactPage.cs
using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace VIVEcms.Models.Pages
{
[ContentType(
    DisplayName = "Contact Page",
    GUID        = "your-unique-guid-here",
    Description = "The Contact page")]
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