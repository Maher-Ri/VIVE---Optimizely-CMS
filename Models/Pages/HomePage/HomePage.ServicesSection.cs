using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.Web;

namespace VIVEcms.Models.Pages
{
    public partial class HomePage
    {
        [Display(
            Name = "Show Services Section",
            Description = "Toggle to show or hide this section on the page",
            Order = 1,
            GroupName = Tabs.ServicesSection
        )]
        public virtual bool ShowServicesSection { get; set; }

        [Display(
            Name = "Service Items",
            Description = "Add, remove and reorder service cards",
            Order = 10,
            GroupName = Tabs.ServicesSection
        )]
        [AllowedTypes(typeof(ServiceItemBlock))] // ← only ServiceItemBlock can be added
        public virtual ContentArea? ServicesItems { get; set; }
    }
}
