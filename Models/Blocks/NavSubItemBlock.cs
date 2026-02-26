// Models/Blocks/NavSubItemBlock.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Blocks
{
    [ContentType(
        DisplayName = "Nav Sub Item",
        GUID = "cf1dc1ed-9e2c-4ac3-8c4f-9d3885dedde4",
        Description = "A sub-menu item in the navbar navigation"
    )]
    public class NavSubItemBlock : BlockData
    {
        [Display(Name = "Label", Description = "e.g: About Us, All Classes", Order = 10)]
        public virtual string? Label { get; set; }

        [Display(Name = "URL", Description = "e.g: /about, /classes", Order = 20)]
        public virtual string? Url { get; set; }

        [Display(
            Name = "Sub Items (3rd level)",
            Description = "Optional — only if this item has a dropdown",
            Order = 30
        )]
        [AllowedTypes(typeof(NavSubItemBlock))]
        public virtual ContentArea? SubSubItems { get; set; }
    }
}
