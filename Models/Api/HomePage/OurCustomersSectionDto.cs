// Models/Api/HomePage/OurCustomersSectionDto.cs
namespace VIVEcms.Models.Api.HomePage
{
    public class OurCustomersSectionDto
    {
        public bool IsVisible { get; set; }
        public string? LeftImageUrl { get; set; }
        public string? LeftImageAlt { get; set; }
        public string? HeadingLine1 { get; set; }
        public string? HeadingLine2 { get; set; }
        public List<TestimonialItemDto>? Testimonials { get; set; }
    }
}
