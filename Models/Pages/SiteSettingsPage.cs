using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace VIVEcms.Models.Pages
{
    [ContentType(
        DisplayName = "Site Settings",
        GUID = "b495a633-8a6d-4ab0-ad61-73f04f3ab9d5",
        Description = "Global settings for Navbar and Footer. Create this page once under Root."
    )]
    public class SiteSettingsPage : PageData
    {
        public static class Tabs
        {
            public const string Footer = "Footer";
            public const string Navbar = "Navbar";
        }

        // =============================================
        // FOOTER — Visibility Toggle
        // =============================================

        [Display(
            Name = "Show Footer",
            Description = "Toggle to show or hide the footer across all pages",
            Order = 1,
            GroupName = Tabs.Footer
        )]
        public virtual bool ShowFooter { get; set; }

        // =============================================
        // FOOTER — Top Bar
        // =============================================

        [Display(Name = "Footer Logo", Order = 10, GroupName = Tabs.Footer)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? FooterLogo { get; set; }

        [Display(Name = "Address", Order = 20, GroupName = Tabs.Footer)]
        public virtual XhtmlString? FooterAddress { get; set; }

        [Display(Name = "Opening Hours", Order = 30, GroupName = Tabs.Footer)]
        public virtual XhtmlString? FooterOpeningHours { get; set; }

        [Display(Name = "Facebook URL", Order = 40, GroupName = Tabs.Footer)]
        public virtual string? FacebookUrl { get; set; }

        [Display(Name = "Twitter URL", Order = 50, GroupName = Tabs.Footer)]
        public virtual string? TwitterUrl { get; set; }

        [Display(Name = "YouTube URL", Order = 60, GroupName = Tabs.Footer)]
        public virtual string? YoutubeUrl { get; set; }

        [Display(Name = "Instagram URL", Order = 70, GroupName = Tabs.Footer)]
        public virtual string? InstagramUrl { get; set; }

        // =============================================
        // FOOTER — Bottom Bar
        // =============================================

        [Display(Name = "Copyright Text", Order = 80, GroupName = Tabs.Footer)]
        public virtual string? CopyrightText { get; set; }

        [Display(Name = "Footer Links", Order = 90, GroupName = Tabs.Footer)]
        public virtual LinkItemCollection? FooterLinks { get; set; }

        // =============================================
        // NAVBAR — placeholder for now
        // =============================================

        [Display(Name = "Navbar — Coming Soon", Order = 10, GroupName = Tabs.Navbar)]
        public virtual string? NavbarPlaceholder { get; set; }
    }
}
