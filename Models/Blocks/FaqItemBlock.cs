// Models/Blocks/FaqItemBlock.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Blocks
{
    [ContentType(
        DisplayName = "FAQ Item",
        GUID = "5715f8de-00cf-4cfe-aff9-b55b6bd39688",
        Description = "A single FAQ question and answer"
    )]
    public class FaqItemBlock : BlockData
    {
        [Display(Name = "Question", Description = "e.g: What is Vive Fitness?", Order = 10)]
        public virtual string? Question { get; set; }

        [Display(Name = "Answer", Description = "The answer to the question", Order = 20)]
        public virtual XhtmlString? Answer { get; set; }
    }
}
