// Models/Pages/AboutPage/AboutPage.CheckoutSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace VIVEcms.Models.Pages
{
    public partial class AboutPage
    {
        [Display(
            Name = "Show Checkout Section",
            Description = "Toggle to show or hide this section",
            Order = 1,
            GroupName = Tabs.CheckoutSection
        )]
        public virtual bool ShowCheckoutSection { get; set; }

        [Display(
            Name = "Heading Line 1",
            Description = "e.g: About my professional work experience",
            Order = 10,
            GroupName = Tabs.CheckoutSection
        )]
        public virtual string? CheckoutHeading1 { get; set; }

        [Display(
            Name = "Heading Line 2",
            Description = "e.g: A New Art of",
            Order = 20,
            GroupName = Tabs.CheckoutSection
        )]
        public virtual string? CheckoutHeading2 { get; set; }

        [Display(
            Name = "Heading Line 3",
            Description = "e.g: Fitness in your town",
            Order = 30,
            GroupName = Tabs.CheckoutSection
        )]
        public virtual string? CheckoutHeading3 { get; set; }

        [Display(
            Name = "Button Text",
            Description = "e.g: Checkout Classes",
            Order = 40,
            GroupName = Tabs.CheckoutSection
        )]
        public virtual string? CheckoutButtonText { get; set; }

        [Display(
            Name = "Button URL",
            Description = "e.g: /classes",
            Order = 50,
            GroupName = Tabs.CheckoutSection
        )]
        public virtual string? CheckoutButtonUrl { get; set; }

        [Display(Name = "Right Image", Order = 60, GroupName = Tabs.CheckoutSection)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? CheckoutImage { get; set; }
    }
}
