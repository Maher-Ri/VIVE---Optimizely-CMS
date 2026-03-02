// Models/Pages/SingleClassPage/SingleClassPage.BenefitsSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Pages
{
    public partial class SingleClassPage
    {
        [Display(Name = "Show Benefits Section", Order = 1, GroupName = Tabs.BenefitsSection)]
        public virtual bool ShowBenefitsSection { get; set; }

        [Display(
            Name = "Benefits Heading",
            Order = 10,
            GroupName = Tabs.BenefitsSection,
            Description = "e.g: Class Benefits"
        )]
        public virtual string? BenefitsHeading { get; set; }

        [Display(Name = "Benefits Description", Order = 20, GroupName = Tabs.BenefitsSection)]
        public virtual XhtmlString? BenefitsDescription { get; set; }

        [Display(
            Name = "Trainers Heading",
            Order = 30,
            GroupName = Tabs.BenefitsSection,
            Description = "e.g: Meet The Trainers"
        )]
        public virtual string? TrainersHeading { get; set; }
    }
}
