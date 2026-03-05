// Models/Pages/SingleProductPage/SingleProductPage.RelatedSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Pages
{
    public partial class SingleProductPage
    {
        [Display(
            Name = "Show Related Products",
            Description = "Toggle to show or hide the related products section",
            Order = 1,
            GroupName = Tabs.RelatedSection
        )]
        public virtual bool ShowRelatedProducts { get; set; }

        [Display(
            Name = "Related Products",
            Description = "Add up to 4 related products",
            Order = 10,
            GroupName = Tabs.RelatedSection
        )]
        [AllowedTypes(typeof(SingleProductPage))]
        public virtual ContentArea? RelatedProducts { get; set; }
    }
}
