// Models/Api/AboutPage/ProcessSectionDto.cs
namespace VIVEcms.Models.Api.AboutPage
{
    public class ProcessSectionDto
    {
        public bool IsVisible { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageAlt { get; set; }
        public List<ProcessItemDto>? Items { get; set; }
        public string? ButtonText { get; set; }
        public string? ButtonUrl { get; set; }
    }
}
