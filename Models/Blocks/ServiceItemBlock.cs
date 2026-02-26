// Models/Blocks/ServiceItemBlock.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

[ContentType(
    DisplayName = "Service Item",
    GUID = "b1c2d3e4-f5a6-4b7c-8d9e-0f1a2b3c4d5e",
    Description = "A single service card used in the Services carousel",
    GroupName = "Blocks"
)]
public class ServiceItemBlock : BlockData
{
    [Display(Name = "Background Image", Description = "Card background image", Order = 10)]
    [UIHint(UIHint.Image)]
    public virtual ContentReference? BackgroundImage { get; set; }

    [Display(Name = "Title", Description = "e.g: Aerobic, Yoga, Cycling", Order = 20)]
    public virtual string? Title { get; set; }

    [Display(Name = "Description", Description = "Short description text on the card", Order = 30)]
    public virtual string? Description { get; set; }

    [Display(Name = "Button Text", Description = "e.g: Learn More", Order = 40)]
    public virtual string? ButtonText { get; set; }

    [Display(Name = "Button URL", Description = "Where the button links to", Order = 50)]
    public virtual Url? ButtonUrl { get; set; }
}
