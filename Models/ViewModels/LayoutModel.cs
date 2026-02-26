// Models/ViewModels/LayoutModel.cs
using EPiServer.Core;
using EPiServer.SpecializedProperties;

namespace VIVEcms.Models.ViewModels
{
    // This class holds the data specifically for Navbar and Footer
    public class LayoutModel
    {
        // =============================================
        // NAVBAR
        // =============================================
        public string? CompanyName { get; set; } // ← your existing property kept

        // =============================================
        // FOOTER — Visibility
        // =============================================
        public bool ShowFooter { get; set; }

        // =============================================
        // FOOTER — Top Bar
        // =============================================
        public ContentReference? FooterLogo { get; set; }
        public string? FooterAddress { get; set; }
        public string? FooterOpeningHours { get; set; }
        public string? FacebookUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? YoutubeUrl { get; set; }
        public string? InstagramUrl { get; set; }

        // =============================================
        // FOOTER — Bottom Bar
        // =============================================
        public string? CopyrightText { get; set; }
        public LinkItemCollection? FooterLinks { get; set; }
    }
}
