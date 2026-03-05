// Models/Pages/SingleProductPage/SingleProductPage.TabsSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Pages
{
    public partial class SingleProductPage
    {
        [Display(
            Name = "Description",
            Description = "Full product description shown in the Description tab",
            Order = 10,
            GroupName = Tabs.TabsSection
        )]
        public virtual XhtmlString? Description { get; set; }

        [Display(
            Name = "Additional Information",
            Description = "Extra details shown in the Additional Information tab (weight, dimensions, sizes)",
            Order = 20,
            GroupName = Tabs.TabsSection
        )]
        public virtual XhtmlString? AdditionalInformation { get; set; }

        [Display(
            Name = "Show Reviews Tab",
            Description = "Toggle to show or hide the Reviews tab",
            Order = 30,
            GroupName = Tabs.TabsSection
        )]
        public virtual bool ShowReviewsTab { get; set; }
    }
}
