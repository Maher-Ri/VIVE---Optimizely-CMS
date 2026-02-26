// Services/IImageService.cs
using EPiServer.Core;

namespace VIVEcms.Services
{
    public interface IImageService
    {
        string GetAltText(ContentReference imageRef);
    }
}
