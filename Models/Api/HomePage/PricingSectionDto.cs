// Models/Api/HomePage/PricingSectionDto.cs
namespace VIVEcms.Models.Api.HomePage
{
    public class PricingSectionDto
    {
        public bool IsVisible { get; set; }
        public string? SectionIconUrl { get; set; }
        public string? SectionIconAlt { get; set; }
        public string? HeadingLine1 { get; set; }
        public string? HeadingLine2 { get; set; }
        public string? Description { get; set; }
        public string? ButtonText { get; set; }
        public string? ButtonUrl { get; set; }
        public List<PricingCardDto>? Cards { get; set; }
    }
}
