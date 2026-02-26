using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace VIVEcms.Models.Pages
{
    // The ContentType attribute registers this class in Optimizely so editors can create it.
    [ContentType(
        DisplayName = "Home Page",
        GUID = "12345678-1234-1234-1234-1234567890ab", // IMPORTANT: See note below about GUIDs
        Description = "The home page of the website.",
        GroupName = "Standard"
    )]
    public partial class HomePage : SitePageData // Inheriting our SEO properties!
    {
        /* ============================================================
         TAB NAMES - add new tabs here as we build each section
         ============================================================ */
        public static class Tabs
        {
            public const string HeadingSection = "Heading";

            public const string OurClassesSection = "Our Classes";

            public const string ServicesSection = "Services Section";
            // next sections will be added here...
        }
    }
}
