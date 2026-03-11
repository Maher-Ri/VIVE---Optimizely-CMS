// Models/Api/AboutPage/AboutPageApiResponse.cs
using VIVEcms.Models.Api.Shared;

namespace VIVEcms.Models.Api.AboutPage
{
    public class AboutPageApiResponse
    {
        public SeoDto? Seo { get; set; }
        public HeaderSectionDto? HeaderSection { get; set; }
        public CheckoutSectionDto? CheckoutSection { get; set; }
        public ProcessSectionDto? ProcessSection { get; set; }
        public ScheduleSectionDto? ScheduleSection { get; set; }
        public ViveTrainerSectionDto? ViveTrainerSection { get; set; }
    }
}
