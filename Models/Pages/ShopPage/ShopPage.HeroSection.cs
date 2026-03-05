// Models/Pages/ShopPage/ShopPage.HeroSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace VIVEcms.Models.Pages
{
    public partial class ShopPage
    {
        [Display(
            Name = "Hero Sub-Title",
            Description = "Small heading above the main title e.g: Stay healthy",
            Order = 10,
            GroupName = Tabs.HeroSection
        )]
        public virtual string? HeroSubTitle { get; set; }

        [Display(
            Name = "Hero Title",
            Description = "Large main heading e.g: and weightless",
            Order = 20,
            GroupName = Tabs.HeroSection
        )]
        public virtual string? HeroTitle { get; set; }

        [Display(
            Name = "Hero Description",
            Description = "Short paragraph below the heading",
            Order = 30,
            GroupName = Tabs.HeroSection
        )]
        public virtual string? HeroDescription { get; set; }

        [Display(
            Name = "Hero Button Text",
            Description = "e.g: View Products",
            Order = 40,
            GroupName = Tabs.HeroSection
        )]
        public virtual string? HeroButtonText { get; set; }

        [Display(
            Name = "Hero Button URL",
            Description = "Destination link for the hero button",
            Order = 50,
            GroupName = Tabs.HeroSection
        )]
        public virtual Url? HeroButtonUrl { get; set; }

        [Display(
            Name = "Hero Background Image",
            Description = "Full-bleed background image for the hero section",
            Order = 60,
            GroupName = Tabs.HeroSection
        )]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? HeroBackgroundImage { get; set; }
    }
}
