// Models/Pages/ContactPage/ContactPage.ContactFormSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace VIVEcms.Models.Pages
{
    public partial class ContactPage
    {
        [Display(
            Name = "Show Contact Form Section",
            Order = 1,
            GroupName = Tabs.ContactFormSection
        )]
        public virtual bool ShowContactFormSection { get; set; }

        // =============================================
        // LEFT COLUMN — Section Heading
        // =============================================
        [Display(
            Name = "Section Heading",
            Order = 10,
            GroupName = Tabs.ContactFormSection,
            Description = "e.g: Start easily today"
        )]
        public virtual string? ContactSectionHeading { get; set; }

        // =============================================
        // STEP 1
        // =============================================
        [Display(
            Name = "Step 1 Title",
            Order = 20,
            GroupName = Tabs.ContactFormSection,
            Description = "e.g: Motivate"
        )]
        public virtual string? Step1Title { get; set; }

        [Display(Name = "Step 1 Description", Order = 30, GroupName = Tabs.ContactFormSection)]
        public virtual XhtmlString? Step1Description { get; set; }

        // =============================================
        // STEP 2
        // =============================================
        [Display(
            Name = "Step 2 Title",
            Order = 40,
            GroupName = Tabs.ContactFormSection,
            Description = "e.g: Inspire"
        )]
        public virtual string? Step2Title { get; set; }

        [Display(Name = "Step 2 Description", Order = 50, GroupName = Tabs.ContactFormSection)]
        public virtual XhtmlString? Step2Description { get; set; }

        // =============================================
        // STEP 3
        // =============================================
        [Display(
            Name = "Step 3 Title",
            Order = 60,
            GroupName = Tabs.ContactFormSection,
            Description = "e.g: Get Started"
        )]
        public virtual string? Step3Title { get; set; }

        [Display(Name = "Step 3 Description", Order = 70, GroupName = Tabs.ContactFormSection)]
        public virtual XhtmlString? Step3Description { get; set; }

        [Display(
            Name = "Step 3 Button Text",
            Order = 80,
            GroupName = Tabs.ContactFormSection,
            Description = "e.g: Checkout Classes"
        )]
        public virtual string? Step3ButtonText { get; set; }

        [Display(
            Name = "Step 3 Button URL",
            Order = 90,
            GroupName = Tabs.ContactFormSection,
            Description = "e.g: /classes"
        )]
        public virtual string? Step3ButtonUrl { get; set; }
    }
}
