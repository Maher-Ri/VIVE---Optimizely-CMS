// Models/Pages/SingleClassPage/SingleClassPage.TrainersSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using VIVEcms.Models.Blocks;

namespace VIVEcms.Models.Pages
{
    public partial class SingleClassPage
    {
        [Display(Name = "Show Trainers Section", Order = 1, GroupName = Tabs.TrainersSection)]
        public virtual bool ShowTrainersSection { get; set; }

        [Display(
            Name = "Trainer Items",
            Order = 10,
            GroupName = Tabs.TrainersSection,
            Description = "Add, remove and reorder trainer cards"
        )]
        [AllowedTypes(typeof(TrainerItemBlock))]
        public virtual ContentArea? TrainerItems { get; set; }
    }
}
