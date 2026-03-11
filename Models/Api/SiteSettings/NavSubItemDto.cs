// Models/Api/SiteSettings/NavSubItemDto.cs
namespace VIVEcms.Models.Api.SiteSettings
{
    public class NavSubItemDto
    {
        public string? Label { get; set; }
        public string? Url { get; set; }
        public List<NavSubItemDto> SubSubItems { get; set; } = new();
    }
}
