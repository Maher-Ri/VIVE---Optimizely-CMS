// Models/Pages/BlogPostPage/BlogPostPage.CommentSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Pages
{
    public partial class BlogPostPage
    {
        [Display(
            Name = "Show Comments Section",
            Description = "Toggle to show or hide the comment form",
            Order = 1,
            GroupName = Tabs.CommentSection
        )]
        public virtual bool ShowCommentSection { get; set; }

        [Display(
            Name = "Form Title",
            Description = "e.g: Leave A Reply",
            Order = 10,
            GroupName = Tabs.CommentSection
        )]
        public virtual string? CommentFormTitle { get; set; }
    }
}
