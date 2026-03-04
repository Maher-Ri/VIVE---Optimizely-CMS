// Models/Pages/MembershipPage/MembershipPage.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Pages
{
    [ContentType(
        DisplayName = "Membership Page",
        GUID = "f6c3d808-04bf-47a4-93a9-9828f7bb4d73",
        Description = "The Membership page"
    )]
    public partial class MembershipPage : SitePageData
    {
        [ScaffoldColumn(false)]
        public override string PageCssFile => "post-4854.css";

        public static class Tabs
        {
            public const string PricingSection = "Pricing";
            public const string FaqSection = "FAQ";
            public const string CtaSection = "CTA";

            // new section tabs will be added here...
        }
    }
}
