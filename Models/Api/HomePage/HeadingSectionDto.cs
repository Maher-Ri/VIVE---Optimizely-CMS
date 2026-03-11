// Models/Api/HomePage/HeadingSectionDto.cs
namespace VIVEcms.Models.Api.HomePage
{
    public class HeadingSectionDto
    {
        public bool IsVisible { get; set; }
        public string? LeftImageUrl { get; set; }
        public string? LeftImageAlt { get; set; }
        public string? HeadingLine1 { get; set; }
        public string? HeadingLine2 { get; set; }
        public string? HeadingLine3 { get; set; }
        public List<string>? AnimatedWords { get; set; }
        public string? Description { get; set; }
        public string? RightImageUrl { get; set; }
        public string? RightImageAlt { get; set; }
    }
}
