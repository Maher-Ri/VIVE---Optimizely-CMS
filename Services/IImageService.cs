// Services/IImageService.cs
public interface IImageService
{
    string GetAltText(ContentReference imageRef);
}

// Services/ImageService.cs
public class ImageService : IImageService
{
    private readonly IContentLoader _contentLoader;

    public ImageService(IContentLoader contentLoader)
    {
        _contentLoader = contentLoader;
    }

    public string GetAltText(ContentReference imageRef)
    {
        // Safety checks
        if (ContentReference.IsNullOrEmpty(imageRef))
            return string.Empty;

        // Try to load the image and get its alt text
        if (_contentLoader.TryGet<ImageFile>(imageRef, out var image))
            return image?.AltText ?? string.Empty;

        return string.Empty;
    }
}
