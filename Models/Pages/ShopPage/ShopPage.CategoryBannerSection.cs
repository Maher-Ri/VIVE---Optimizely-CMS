// Models/Pages/ShopPage/ShopPage.CategoryBannerSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace VIVEcms.Models.Pages
{
    public partial class ShopPage
    {
        // ── Banner 1 (left, large) ──────────────────────────────────────────
        [Display(Name = "Banner 1 – Title", Order = 10, GroupName = Tabs.CategoryBanners)]
        public virtual string? Banner1Title { get; set; }

        [Display(Name = "Banner 1 – Button Text", Order = 20, GroupName = Tabs.CategoryBanners)]
        public virtual string? Banner1ButtonText { get; set; }

        [Display(Name = "Banner 1 – Button URL", Order = 30, GroupName = Tabs.CategoryBanners)]
        public virtual Url? Banner1ButtonUrl { get; set; }

        [Display(
            Name = "Banner 1 – Background Image",
            Order = 40,
            GroupName = Tabs.CategoryBanners
        )]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? Banner1BackgroundImage { get; set; }

        // ── Banner 2 (right-top) ────────────────────────────────────────────
        [Display(Name = "Banner 2 – Title", Order = 50, GroupName = Tabs.CategoryBanners)]
        public virtual string? Banner2Title { get; set; }

        [Display(Name = "Banner 2 – Button Text", Order = 60, GroupName = Tabs.CategoryBanners)]
        public virtual string? Banner2ButtonText { get; set; }

        [Display(Name = "Banner 2 – Button URL", Order = 70, GroupName = Tabs.CategoryBanners)]
        public virtual Url? Banner2ButtonUrl { get; set; }

        [Display(
            Name = "Banner 2 – Background Image",
            Order = 80,
            GroupName = Tabs.CategoryBanners
        )]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? Banner2BackgroundImage { get; set; }

        // ── Banner 3 (right-bottom) ─────────────────────────────────────────
        [Display(Name = "Banner 3 – Title", Order = 90, GroupName = Tabs.CategoryBanners)]
        public virtual string? Banner3Title { get; set; }

        [Display(Name = "Banner 3 – Button Text", Order = 100, GroupName = Tabs.CategoryBanners)]
        public virtual string? Banner3ButtonText { get; set; }

        [Display(Name = "Banner 3 – Button URL", Order = 110, GroupName = Tabs.CategoryBanners)]
        public virtual Url? Banner3ButtonUrl { get; set; }

        [Display(
            Name = "Banner 3 – Background Image",
            Order = 120,
            GroupName = Tabs.CategoryBanners
        )]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? Banner3BackgroundImage { get; set; }
    }
}
