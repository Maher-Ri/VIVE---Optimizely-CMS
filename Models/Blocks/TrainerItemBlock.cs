// Models/Blocks/TrainerItemBlock.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace VIVEcms.Models.Blocks
{
    [ContentType(
        DisplayName = "Trainer Item",
        GUID = "3F8A9B2C-5D7E-4A1B-8C9D-F1E2A3B4C5D6",
        Description = "A single trainer card in the team carousel"
    )]
    public class TrainerItemBlock : BlockData
    {
        [Display(Name = "Background Image", Order = 10)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? BackgroundImage { get; set; }

        [Display(Name = "Name", Order = 20, Description = "e.g: Gregg Williams")]
        public virtual string? Name { get; set; }

        [Display(Name = "Subtitle", Order = 30, Description = "Optional subtitle")]
        public virtual string? Subtitle { get; set; }

        [Display(Name = "Link URL", Order = 40, Description = "Optional link URL")]
        public virtual string? LinkUrl { get; set; }
    }
}
