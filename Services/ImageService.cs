// Services/ImageService.cs
using EPiServer;
using EPiServer.Core;
using VIVEcms.Models.Media;

namespace VIVEcms.Services
{
    public class ImageService : IImageService
    {
        private readonly IContentLoader _contentLoader;

        public ImageService(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public string GetAltText(ContentReference imageRef)
        {
            if (ContentReference.IsNullOrEmpty(imageRef))
                return string.Empty;

            if (_contentLoader.TryGet<ImageFile>(imageRef, out var image))
                return image?.AltText ?? string.Empty;

            return string.Empty;
        }
    }
}
