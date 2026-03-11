// Models/Api/HomePage/HomePageApiResponse.cs
using VIVEcms.Models.Api.Shared;

namespace VIVEcms.Models.Api.HomePage
{
    public class HomePageApiResponse
    {
        public SeoDto? Seo { get; set; }
        public HeadingSectionDto? HeadingSection { get; set; }
        public OurClassesSectionDto? OurClassesSection { get; set; }
        public ServicesSectionDto? ServicesSection { get; set; }
        public OurCustomersSectionDto? OurCustomersSection { get; set; }
        public PricingSectionDto? PricingSection { get; set; }
        public ScheduleSectionDto? ScheduleSection { get; set; }
        public ViveTrainerSectionDto? ViveTrainerSection { get; set; }
    }
}
