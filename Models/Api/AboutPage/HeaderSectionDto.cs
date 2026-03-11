// Models/Api/AboutPage/HeaderSectionDto.cs
namespace VIVEcms.Models.Api.AboutPage
{
    public class HeaderSectionDto
    {
        public bool IsVisible { get; set; }
        public string? BackgroundImageUrl { get; set; }
        public string? BackgroundImageAlt { get; set; }
        public string? HeadingLine1 { get; set; }
        public string? HeadingLine2 { get; set; }
        public string? HeadingLine3 { get; set; }
        public List<string>? AnimatedWords { get; set; }
    }
}
