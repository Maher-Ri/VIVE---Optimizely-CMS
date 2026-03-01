// Models/ViewModels/CommentFormModel.cs
using System.ComponentModel.DataAnnotations;

namespace VIVEcms.Models.ViewModels
{
    public class CommentFormModel
    {
        [Required]
        public string? Comment { get; set; }

        [Required]
        public string? Author { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public string? Url { get; set; }
        public bool SaveInfo { get; set; }
        public int PostId { get; set; }
    }
}
