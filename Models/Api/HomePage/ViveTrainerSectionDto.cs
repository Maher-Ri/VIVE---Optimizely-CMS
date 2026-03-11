// Models/Api/HomePage/ViveTrainerSectionDto.cs
namespace VIVEcms.Models.Api.HomePage
{
    public class ViveTrainerSectionDto
    {
        public bool IsVisible { get; set; }
        public string? Heading { get; set; }
        public List<GalleryItemDto>? GalleryItems { get; set; }
    }
}
