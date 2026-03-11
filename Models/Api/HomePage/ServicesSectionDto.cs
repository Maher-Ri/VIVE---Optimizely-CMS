// Models/Api/HomePage/ServicesSectionDto.cs
namespace VIVEcms.Models.Api.HomePage
{
    public class ServicesSectionDto
    {
        public bool IsVisible { get; set; }
        public List<ServiceItemDto>? Items { get; set; }
    }
}
