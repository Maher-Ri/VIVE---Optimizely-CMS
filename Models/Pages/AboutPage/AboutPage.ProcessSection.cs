// Models/Pages/AboutPage/AboutPage.ProcessSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace VIVEcms.Models.Pages
{
    public partial class AboutPage
    {
        [Display(
            Name = "Show Process Section",
            Description = "Toggle to show or hide this section",
            Order = 1,
            GroupName = Tabs.ProcessSection
        )]
        public virtual bool ShowProcessSection { get; set; }

        [Display(
            Name = "Left Image",
            Description = "Image displayed on the left side",
            Order = 5,
            GroupName = Tabs.ProcessSection
        )]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? ProcessImage { get; set; }

        // ===== PROCESS ITEM 1 =====
        [Display(
            Name = "Item 1 - Number",
            Description = "e.g: 1",
            Order = 10,
            GroupName = Tabs.ProcessSection
        )]
        public virtual string? ProcessItem1Number { get; set; }

        [Display(
            Name = "Item 1 - Heading",
            Description = "e.g: Motivate",
            Order = 15,
            GroupName = Tabs.ProcessSection
        )]
        public virtual string? ProcessItem1Heading { get; set; }

        [Display(
            Name = "Item 1 - Description",
            Description = "Short description text",
            Order = 20,
            GroupName = Tabs.ProcessSection
        )]
        [UIHint(UIHint.Textarea)]
        public virtual string? ProcessItem1Description { get; set; }

        // ===== PROCESS ITEM 2 =====
        [Display(
            Name = "Item 2 - Number",
            Description = "e.g: 2",
            Order = 25,
            GroupName = Tabs.ProcessSection
        )]
        public virtual string? ProcessItem2Number { get; set; }

        [Display(
            Name = "Item 2 - Heading",
            Description = "e.g: Inspire",
            Order = 30,
            GroupName = Tabs.ProcessSection
        )]
        public virtual string? ProcessItem2Heading { get; set; }

        [Display(
            Name = "Item 2 - Description",
            Description = "Short description text",
            Order = 35,
            GroupName = Tabs.ProcessSection
        )]
        [UIHint(UIHint.Textarea)]
        public virtual string? ProcessItem2Description { get; set; }

        // ===== PROCESS ITEM 3 =====
        [Display(
            Name = "Item 3 - Number",
            Description = "e.g: 3",
            Order = 40,
            GroupName = Tabs.ProcessSection
        )]
        public virtual string? ProcessItem3Number { get; set; }

        [Display(
            Name = "Item 3 - Heading",
            Description = "e.g: Get Started",
            Order = 45,
            GroupName = Tabs.ProcessSection
        )]
        public virtual string? ProcessItem3Heading { get; set; }

        [Display(
            Name = "Item 3 - Description",
            Description = "Short description text",
            Order = 50,
            GroupName = Tabs.ProcessSection
        )]
        [UIHint(UIHint.Textarea)]
        public virtual string? ProcessItem3Description { get; set; }

        // ===== BUTTON =====
        [Display(
            Name = "Button Text",
            Description = "e.g: Checkout Classes",
            Order = 55,
            GroupName = Tabs.ProcessSection
        )]
        public virtual string? ProcessButtonText { get; set; }

        [Display(
            Name = "Button URL",
            Description = "e.g: /classes",
            Order = 60,
            GroupName = Tabs.ProcessSection
        )]
        public virtual string? ProcessButtonUrl { get; set; }
    }
}
