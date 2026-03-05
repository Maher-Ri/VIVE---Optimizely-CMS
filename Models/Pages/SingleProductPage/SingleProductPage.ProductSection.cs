// Models/Pages/SingleProductPage/SingleProductPage.ProductSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Pages
{
    public partial class SingleProductPage
    {
        [Display(
            Name = "Price",
            Description = "e.g: $59.00",
            Order = 10,
            GroupName = Tabs.ProductSection
        )]
        public virtual string? Price { get; set; }

        [Display(
            Name = "Short Description",
            Description = "One-line feature text shown below the price",
            Order = 20,
            GroupName = Tabs.ProductSection
        )]
        public virtual XhtmlString? ShortDescription { get; set; }

        [Display(
            Name = "SKU",
            Description = "Product stock-keeping unit e.g: SNK103",
            Order = 30,
            GroupName = Tabs.ProductSection
        )]
        public virtual string? Sku { get; set; }

        [Display(
            Name = "Categories",
            Description = "Comma-separated e.g: Sneakers,Sport",
            Order = 40,
            GroupName = Tabs.ProductSection
        )]
        public virtual string? Categories { get; set; }

        [Display(
            Name = "Tags",
            Description = "Comma-separated e.g: sneakers,sport",
            Order = 50,
            GroupName = Tabs.ProductSection
        )]
        public virtual string? Tags { get; set; }

        [Display(
            Name = "Size Options",
            Description = "Comma-separated size values e.g: EUR40,EUR41,EUR42,EUR43",
            Order = 60,
            GroupName = Tabs.ProductSection
        )]
        public virtual string? SizeOptions { get; set; }

        [Display(
            Name = "Weight",
            Description = "e.g: 1.5 kg",
            Order = 70,
            GroupName = Tabs.ProductSection
        )]
        public virtual string? Weight { get; set; }

        [Display(
            Name = "Dimensions",
            Description = "e.g: 8 × 8.7 × 1.2 cm",
            Order = 80,
            GroupName = Tabs.ProductSection
        )]
        public virtual string? Dimensions { get; set; }
    }
}
