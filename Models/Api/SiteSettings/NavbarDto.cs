// Models/Api/SiteSettings/NavbarDto.cs
namespace VIVEcms.Models.Api.SiteSettings
{
    public class NavbarDto
    {
        public bool IsVisible { get; set; }
        public string? LogoImageUrl { get; set; }
        public string? LogoImageAlt { get; set; }
        public string? LogoLinkUrl { get; set; }
        public string? ButtonText { get; set; }
        public string? ButtonUrl { get; set; }
        public List<NavItemDto> Items { get; set; } = new();
    }
}
