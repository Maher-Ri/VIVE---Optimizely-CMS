// Models/Pages/ShopPage/ShopPage.TrendExplorerSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Pages
{
    public partial class ShopPage
    {
        [Display(
            Name = "Trend Explorer Heading",
            Description = "Section heading e.g: Trend Explorer",
            Order = 10,
            GroupName = Tabs.TrendExplorer
        )]
        public virtual string? TrendExplorerHeading { get; set; }
    }
}
