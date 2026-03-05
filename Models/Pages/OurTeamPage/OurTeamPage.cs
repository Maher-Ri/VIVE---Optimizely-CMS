// Models/Pages/OurTeamPage/OurTeamPage.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Pages
{
    [ContentType(
        DisplayName = "Our Team Page",
        GUID = "7957881d-97a9-4ad9-bd8c-829cb8e23317",
        Description = "The Our Team page"
    )]
    public partial class OurTeamPage : SitePageData
    {
        [ScaffoldColumn(false)]
        public override string PageCssFile => "post-3365.css";

        public static class Tabs
        {
            public const string HeaderSection = "Header";
            public const string TeamSection = "Team";
        }
    }
}
