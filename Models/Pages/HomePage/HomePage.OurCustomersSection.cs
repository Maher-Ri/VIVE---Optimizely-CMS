// Models/Pages/HomePage/HomePage.OurCustomersSection.cs
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using VIVEcms.Models.Blocks;

namespace VIVEcms.Models.Pages
{
    public partial class HomePage
    {
        [Display(
            Name = "Show Our Customers Section",
            Description = "Toggle to show or hide this section on the page",
            Order = 1,
            GroupName = "Our Customers Section"
        )]
        public virtual bool ShowOurCustomersSection { get; set; }

        [Display(Name = "Left Image", Order = 10, GroupName = "Our Customers Section")]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? OurCustomersLeftImage { get; set; }

        [Display(
            Name = "Heading Line 1",
            Description = "e.g: Trusted by",
            Order = 20,
            GroupName = "Our Customers Section"
        )]
        public virtual string? OurCustomersHeading1 { get; set; }

        [Display(
            Name = "Heading Line 2",
            Description = "e.g: Our Customers",
            Order = 30,
            GroupName = "Our Customers Section"
        )]
        public virtual string? OurCustomersHeading2 { get; set; }

        [Display(
            Name = "Testimonials",
            Description = "Add testimonial items for the carousel",
            Order = 40,
            GroupName = "Our Customers Section"
        )]
        [AllowedTypes(typeof(TestimonialItemBlock))]
        public virtual ContentArea? OurCustomersTestimonials { get; set; }
    }
}
