using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.Web;

namespace VIVEcms.Models.Pages
{
    public partial class HomePage // ← partial keyword, same class
    {
        [Display(Name = "Show Heading Section", Order = 1, GroupName = Tabs.HeadingSection)]
        public virtual bool ShowHeadingSection { get; set; }

        [Display(Name = "Left Image", Order = 10, GroupName = Tabs.HeadingSection)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? HeadingLeftImage { get; set; }

        [Display(Name = "Heading Line 1", Order = 20, GroupName = Tabs.HeadingSection)]
        public virtual string? HeadingLine1 { get; set; }

        [Display(Name = "Heading Line 2", Order = 30, GroupName = Tabs.HeadingSection)]
        public virtual string? HeadingLine2 { get; set; }

        [Display(Name = "Heading Line 3", Order = 40, GroupName = Tabs.HeadingSection)]
        public virtual string? HeadingLine3 { get; set; }

        [Display(Name = "Animated Words", Order = 50, GroupName = Tabs.HeadingSection)]
        public virtual string? HeadingAnimatedWords { get; set; }

        [Display(Name = "Description Text", Order = 60, GroupName = Tabs.HeadingSection)]
        public virtual string? HeadingDescription { get; set; }

        [Display(Name = "Right Image", Order = 70, GroupName = Tabs.HeadingSection)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? HeadingRightImage { get; set; }
    }
}
