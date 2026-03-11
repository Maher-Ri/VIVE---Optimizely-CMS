// Controllers/Api/AboutPageApiController.cs
using EPiServer;
using EPiServer.Core;
using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Mvc;
using VIVEcms.Models.Api.AboutPage;
using VIVEcms.Models.Api.Shared;
using VIVEcms.Models.Blocks;
using VIVEcms.Models.Pages;
using VIVEcms.Services;

namespace VIVEcms.Controllers.Api
{
    [ApiController]
    [Route("api/vivecms/v1")]
    public class AboutPageApiController : ControllerBase
    {
        private readonly IContentLoader _contentLoader;
        private readonly IUrlResolver _urlResolver;
        private readonly IImageService _imageService;

        public AboutPageApiController(
            IContentLoader contentLoader,
            IUrlResolver urlResolver,
            IImageService imageService
        )
        {
            _contentLoader = contentLoader;
            _urlResolver = urlResolver;
            _imageService = imageService;
        }

        // =============================================
        // GET api/vivecms/v1/about
        // =============================================
        [HttpGet("about")]
        public IActionResult GetAboutPage()
        {
            // Find AboutPage from the CMS content tree
            var aboutPage = _contentLoader
                .GetChildren<AboutPage>(ContentReference.RootPage)
                .FirstOrDefault();

            // Try one level deeper if not found at root
            if (aboutPage == null)
            {
                var rootChildren = _contentLoader.GetChildren<IContent>(ContentReference.RootPage);

                foreach (var child in rootChildren)
                {
                    aboutPage = _contentLoader
                        .GetChildren<AboutPage>(child.ContentLink)
                        .FirstOrDefault();

                    if (aboutPage != null)
                        break;
                }
            }

            if (aboutPage == null)
                return NotFound(new { message = "AboutPage not found in CMS" });

            var response = new AboutPageApiResponse
            {
                // ===== SEO =====
                Seo = new SeoDto
                {
                    MetaTitle = aboutPage.MetaTitle,
                    MetaDescription = aboutPage.MetaDescription,
                    MetaKeywords = aboutPage.MetaKeywords,
                },

                // ===== HEADER SECTION =====
                HeaderSection = new HeaderSectionDto
                {
                    IsVisible = aboutPage.ShowHeaderSection,
                    BackgroundImageUrl = GetImageUrl(aboutPage.HeaderBackgroundImage),
                    BackgroundImageAlt = _imageService.GetAltText(aboutPage.HeaderBackgroundImage),
                    HeadingLine1 = aboutPage.HeaderHeading1,
                    HeadingLine2 = aboutPage.HeaderHeading2,
                    HeadingLine3 = aboutPage.HeaderHeading3,
                    AnimatedWords = ParseAnimatedWords(aboutPage.HeaderAnimatedWords),
                },

                // ===== CHECKOUT SECTION =====
                CheckoutSection = new CheckoutSectionDto
                {
                    IsVisible = aboutPage.ShowCheckoutSection,
                    HeadingLine1 = aboutPage.CheckoutHeading1,
                    HeadingLine2 = aboutPage.CheckoutHeading2,
                    HeadingLine3 = aboutPage.CheckoutHeading3,
                    ButtonText = aboutPage.CheckoutButtonText,
                    ButtonUrl = aboutPage.CheckoutButtonUrl,
                    ImageUrl = GetImageUrl(aboutPage.CheckoutImage),
                    ImageAlt = _imageService.GetAltText(aboutPage.CheckoutImage),
                },

                // ===== PROCESS SECTION =====
                ProcessSection = new ProcessSectionDto
                {
                    IsVisible = aboutPage.ShowProcessSection,
                    ImageUrl = GetImageUrl(aboutPage.ProcessImage),
                    ImageAlt = _imageService.GetAltText(aboutPage.ProcessImage),
                    ButtonText = aboutPage.ProcessButtonText,
                    ButtonUrl = aboutPage.ProcessButtonUrl,
                    Items = new List<ProcessItemDto>
                    {
                        new ProcessItemDto
                        {
                            Number = aboutPage.ProcessItem1Number,
                            Heading = aboutPage.ProcessItem1Heading,
                            Description = aboutPage.ProcessItem1Description,
                        },
                        new ProcessItemDto
                        {
                            Number = aboutPage.ProcessItem2Number,
                            Heading = aboutPage.ProcessItem2Heading,
                            Description = aboutPage.ProcessItem2Description,
                        },
                        new ProcessItemDto
                        {
                            Number = aboutPage.ProcessItem3Number,
                            Heading = aboutPage.ProcessItem3Heading,
                            Description = aboutPage.ProcessItem3Description,
                        },
                    },
                },

                // ===== SCHEDULE SECTION =====
                ScheduleSection = GetScheduleSection(aboutPage),

                // ===== VIVE TRAINER SECTION =====
                ViveTrainerSection = GetViveTrainerSection(aboutPage),
            };

            return Ok(response);
        }

        // =============================================
        // SCHEDULE SECTION — loads from ContentArea block
        // =============================================
        private ScheduleSectionDto GetScheduleSection(AboutPage page)
        {
            var dto = new ScheduleSectionDto { IsVisible = page.ShowScheduleSection };

            if (page.ScheduleSection == null)
                return dto;

            // Get the first (and only) ScheduleSectionBlock
            var blockRef = page.ScheduleSection.FilteredItems.FirstOrDefault();
            if (blockRef == null)
                return dto;

            var block = _contentLoader.Get<ScheduleSectionBlock>(blockRef.ContentLink);

            if (block == null)
                return dto;

            dto.HeadingLine1 = block.HeadingLine1;
            dto.HeadingLine2 = block.HeadingLine2;
            dto.HeadingLine3 = block.HeadingLine3;
            dto.HeadingLine4 = block.HeadingLine4;
            dto.HeadingLine5 = block.HeadingLine5;
            dto.Description = block.Description?.ToString();
            dto.ButtonText = block.ButtonText;
            dto.ButtonUrl = block.ButtonUrl;
            dto.ImageUrl = GetImageUrl(block.SectionImage);
            dto.ImageAlt = _imageService.GetAltText(block.SectionImage);

            return dto;
        }

        // =============================================
        // VIVE TRAINER SECTION — loads from ContentArea block
        // =============================================
        private ViveTrainerSectionDto GetViveTrainerSection(AboutPage page)
        {
            var dto = new ViveTrainerSectionDto
            {
                IsVisible = page.ShowViveTrainerSection,
                GalleryItems = new List<GalleryItemDto>(),
            };

            if (page.ViveTrainerSection == null)
                return dto;

            // Get the first (and only) ViveTrainerSectionBlock
            var blockRef = page.ViveTrainerSection.FilteredItems.FirstOrDefault();
            if (blockRef == null)
                return dto;

            var block = _contentLoader.Get<ViveTrainerSectionBlock>(blockRef.ContentLink);

            if (block == null)
                return dto;

            dto.Heading = block.Heading;

            // Load each GalleryItemBlock from the ContentArea
            if (block.GalleryItems != null)
            {
                dto.GalleryItems = block
                    .GalleryItems.FilteredItems.Select(item =>
                        _contentLoader.Get<GalleryItemBlock>(item.ContentLink)
                    )
                    .Where(galleryBlock => galleryBlock != null)
                    .Select(galleryBlock => new GalleryItemDto
                    {
                        ImageUrl = GetImageUrl(galleryBlock.Image),
                        ImageAlt = _imageService.GetAltText(galleryBlock.Image),

                        // Use main image as fallback if thumbnail is empty
                        ThumbnailUrl = !ContentReference.IsNullOrEmpty(galleryBlock.ThumbnailImage)
                            ? GetImageUrl(galleryBlock.ThumbnailImage)
                            : GetImageUrl(galleryBlock.Image),

                        ThumbnailAlt = !ContentReference.IsNullOrEmpty(galleryBlock.ThumbnailImage)
                            ? _imageService.GetAltText(galleryBlock.ThumbnailImage)
                            : _imageService.GetAltText(galleryBlock.Image),
                    })
                    .ToList();
            }

            return dto;
        }

        // =============================================
        // PRIVATE HELPERS
        // =============================================
        private string GetImageUrl(ContentReference imageRef)
        {
            if (ContentReference.IsNullOrEmpty(imageRef))
                return string.Empty;

            return _urlResolver.GetUrl(imageRef);
        }

        private List<string> ParseAnimatedWords(string words)
        {
            if (string.IsNullOrWhiteSpace(words))
                return new List<string>();

            return words
                .Split(',')
                .Select(w => w.Trim())
                .Where(w => !string.IsNullOrEmpty(w))
                .ToList();
        }
    }
}
