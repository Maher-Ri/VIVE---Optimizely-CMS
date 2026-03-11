// Models/Api/AboutPage/CheckoutSectionDto.cs
namespace VIVEcms.Models.Api.AboutPage
{
    public class CheckoutSectionDto
    {
        public bool IsVisible { get; set; }
        public string? HeadingLine1 { get; set; }
        public string? HeadingLine2 { get; set; }
        public string? HeadingLine3 { get; set; }
        public string? ButtonText { get; set; }
        public string? ButtonUrl { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageAlt { get; set; }
    }
}
