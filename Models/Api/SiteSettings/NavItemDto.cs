// Models/Api/SiteSettings/NavItemDto.cs
namespace VIVEcms.Models.Api.SiteSettings
{
    public class NavItemDto
    {
        public string? Label { get; set; }
        public string? Url { get; set; }
        public bool HasMegaMenu { get; set; }
        public List<NavSubItemDto> SubItems { get; set; } = new();
        public List<NavMegaPreviewDto> MegaMenuPreviews { get; set; } = new();
    }
}
