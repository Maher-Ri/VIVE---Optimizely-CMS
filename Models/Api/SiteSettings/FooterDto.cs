// Models/Api/SiteSettings/FooterDto.cs
namespace VIVEcms.Models.Api.SiteSettings
{
    public class FooterDto
    {
        public bool IsVisible { get; set; }
        public string? LogoImageUrl { get; set; }
        public string? LogoImageAlt { get; set; }
        public string? Address { get; set; }
        public string? OpeningHours { get; set; }
        public string? FacebookUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? YoutubeUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? CopyrightText { get; set; }
        public List<FooterLinkDto> Links { get; set; } = new();
    }
}
