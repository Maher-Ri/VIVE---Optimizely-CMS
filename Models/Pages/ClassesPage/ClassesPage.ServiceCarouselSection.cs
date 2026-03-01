// Models/Pages/ClassesPage/ClassesPage.ServiceCarouselSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using VIVEcms.Models.Blocks;

namespace VIVEcms.Models.Pages
{
    public partial class ClassesPage
    {
        [Display(
            Name = "Show Services Section",
            Description = "Toggle to show or hide this section",
            Order = 1,
            GroupName = Tabs.ServiceCarouselSection
        )]
        public virtual bool ShowServiceCarouselSection { get; set; }

        [Display(
            Name = "Service Items",
            Description = "Add, remove and reorder service cards",
            Order = 10,
            GroupName = Tabs.ServiceCarouselSection
        )]
        [AllowedTypes(typeof(ServiceItemBlock))]
        public virtual ContentArea? ServiceCarouselItems { get; set; }
    }
}
