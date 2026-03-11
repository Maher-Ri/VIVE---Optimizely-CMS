// Models/Api/HomePage/PricingCardDto.cs
namespace VIVEcms.Models.Api.HomePage
{
    public class PricingCardDto
    {
        public string? Title { get; set; }
        public string? Price { get; set; }
        public string? Validity { get; set; }
        public List<string>? Features { get; set; }
    }
}
