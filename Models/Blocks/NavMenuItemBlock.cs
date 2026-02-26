// Models/Blocks/NavMenuItemBlock.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Blocks
{
    [ContentType(
        DisplayName = "Nav Menu Item",
        GUID = "your-unique-guid-here",
        Description = "A top-level navigation item in the navbar"
    )]
    public class NavMenuItemBlock : BlockData
    {
        [Display(Name = "Label", Description = "e.g: Home, Pages, Classes", Order = 10)]
        public virtual string? Label { get; set; }

        [Display(Name = "URL", Description = "e.g: / or # if it has a dropdown only", Order = 20)]
        public virtual string? Url { get; set; }

        [Display(
            Name = "Has Mega Menu",
            Description = "Enable to show preview images dropdown",
            Order = 30
        )]
        public virtual bool HasMegaMenu { get; set; }

        [Display(Name = "Sub Items", Description = "Dropdown menu items", Order = 40)]
        [AllowedTypes(typeof(NavSubItemBlock))]
        public virtual ContentArea? SubItems { get; set; }

        [Display(
            Name = "Mega Menu Previews",
            Description = "Preview image cards — only used when Has Mega Menu is checked",
            Order = 50
        )]
        [AllowedTypes(typeof(NavMegaPreviewBlock))]
        public virtual ContentArea? MegaMenuPreviews { get; set; }
    }
}
