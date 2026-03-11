// Models/Api/AboutPage/ViveTrainerSectionDto.cs
namespace VIVEcms.Models.Api.AboutPage
{
    public class ViveTrainerSectionDto
    {
        public bool IsVisible { get; set; }
        public string? Heading { get; set; }
        public List<GalleryItemDto>? GalleryItems { get; set; }
    }
}
