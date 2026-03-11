// Controllers/Api/HomePageApiController.cs
using EPiServer;
using EPiServer.Core;
using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Mvc;
using VIVEcms.Models.Api.HomePage;
using VIVEcms.Models.Api.Shared;
using VIVEcms.Models.Blocks;
using VIVEcms.Models.Pages;
using VIVEcms.Services;

namespace VIVEcms.Controllers.Api
{
    [ApiController]
    [Route("api/vivecms/v1")]
    public class HomePageApiController : ControllerBase
    {
        private readonly IContentLoader _contentLoader;
        private readonly IUrlResolver _urlResolver;
        private readonly IImageService _imageService;

        public HomePageApiController(
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
        // GET api/vivecms/v1/home
        // =============================================
        [HttpGet("home")]
        public IActionResult GetHomePage()
        {
            // Find HomePage from the CMS content tree
            var homePage = _contentLoader
                .GetChildren<HomePage>(ContentReference.RootPage)
                .FirstOrDefault();

            // Try one level deeper if not found at root
            if (homePage == null)
            {
                var rootChildren = _contentLoader.GetChildren<IContent>(ContentReference.RootPage);

                foreach (var child in rootChildren)
                {
                    homePage = _contentLoader
                        .GetChildren<HomePage>(child.ContentLink)
                        .FirstOrDefault();

                    if (homePage != null)
                        break;
                }
            }

            if (homePage == null)
                return NotFound(new { message = "HomePage not found in CMS" });

            var response = new HomePageApiResponse
            {
                // ===== SEO =====
                Seo = new SeoDto
                {
                    MetaTitle = homePage.MetaTitle,
                    MetaDescription = homePage.MetaDescription,
                    MetaKeywords = homePage.MetaKeywords,
                },

                // ===== HEADING SECTION =====
                HeadingSection = new HeadingSectionDto
                {
                    IsVisible = homePage.ShowHeadingSection,
                    LeftImageUrl = GetImageUrl(homePage.HeadingLeftImage),
                    LeftImageAlt = _imageService.GetAltText(homePage.HeadingLeftImage),
                    HeadingLine1 = homePage.HeadingLine1,
                    HeadingLine2 = homePage.HeadingLine2,
                    HeadingLine3 = homePage.HeadingLine3,
                    AnimatedWords = ParseAnimatedWords(homePage.HeadingAnimatedWords),
                    Description = homePage.HeadingDescription,
                    RightImageUrl = GetImageUrl(homePage.HeadingRightImage),
                    RightImageAlt = _imageService.GetAltText(homePage.HeadingRightImage),
                },

                // ===== OUR CLASSES SECTION =====
                OurClassesSection = new OurClassesSectionDto
                {
                    IsVisible = homePage.ShowOurClassesSection,
                    HeadingLine1 = homePage.OurClassesHeading1,
                    HeadingLine2 = homePage.OurClassesHeading2,
                    HeadingLine3 = homePage.OurClassesHeading3,
                    Description = homePage.OurClassesDescription?.ToString(),
                },

                // ===== SERVICES SECTION =====
                ServicesSection = GetServicesSection(homePage),

                // ===== OUR CUSTOMERS SECTION =====
                OurCustomersSection = GetOurCustomersSection(homePage),

                // ===== PRICING SECTION =====
                PricingSection = GetPricingSection(homePage),

                // ===== SCHEDULE SECTION =====
                ScheduleSection = GetScheduleSection(homePage),

                // ===== VIVE TRAINER SECTION =====
                ViveTrainerSection = GetViveTrainerSection(homePage),
            };

            return Ok(response);
        }

        // =============================================
        // SERVICES SECTION — loads each ServiceItemBlock from ContentArea
        // =============================================
        private ServicesSectionDto GetServicesSection(HomePage page)
        {
            var dto = new ServicesSectionDto
            {
                IsVisible = page.ShowServicesSection,
                Items = new List<ServiceItemDto>(),
            };

            if (page.ServicesItems == null)
                return dto;

            dto.Items = page
                .ServicesItems.FilteredItems.Select(item =>
                    _contentLoader.Get<ServiceItemBlock>(item.ContentLink)
                )
                .Where(block => block != null)
                .Select(block => new ServiceItemDto
                {
                    BackgroundImageUrl = GetImageUrl(block.BackgroundImage),
                    BackgroundImageAlt = _imageService.GetAltText(block.BackgroundImage),
                    Title = block.Title,
                    Description = block.Description,
                    ButtonText = block.ButtonText,
                    ButtonUrl = block.ButtonUrl?.ToString(),
                })
                .ToList();

            return dto;
        }

        // =============================================
        // OUR CUSTOMERS SECTION — direct props + testimonial ContentArea
        // =============================================
        private OurCustomersSectionDto GetOurCustomersSection(HomePage page)
        {
            var dto = new OurCustomersSectionDto
            {
                IsVisible = page.ShowOurCustomersSection,
                LeftImageUrl = GetImageUrl(page.OurCustomersLeftImage),
                LeftImageAlt = _imageService.GetAltText(page.OurCustomersLeftImage),
                HeadingLine1 = page.OurCustomersHeading1,
                HeadingLine2 = page.OurCustomersHeading2,
                Testimonials = new List<TestimonialItemDto>(),
            };

            if (page.OurCustomersTestimonials == null)
                return dto;

            dto.Testimonials = page
                .OurCustomersTestimonials.FilteredItems.Select(item =>
                    _contentLoader.Get<TestimonialItemBlock>(item.ContentLink)
                )
                .Where(block => block != null)
                .Select(block => new TestimonialItemDto
                {
                    Quote = block.Quote,
                    ThumbImageUrl = GetImageUrl(block.ThumbImage),
                    ThumbImageAlt = _imageService.GetAltText(block.ThumbImage),
                    Name = block.Name,
                    Designation = block.Designation,
                })
                .ToList();

            return dto;
        }

        // =============================================
        // PRICING SECTION — loads from ContentArea block
        // =============================================
        private PricingSectionDto GetPricingSection(HomePage page)
        {
            var dto = new PricingSectionDto { IsVisible = page.ShowPricingSection };

            if (page.PricingSection == null)
                return dto;

            // Get the first (and only) PricingSectionBlock
            var blockRef = page.PricingSection.FilteredItems.FirstOrDefault();
            if (blockRef == null)
                return dto;

            var block = _contentLoader.Get<PricingSectionBlock>(blockRef.ContentLink);

            if (block == null)
                return dto;

            dto.SectionIconUrl = GetImageUrl(block.SectionIcon);
            dto.SectionIconAlt = _imageService.GetAltText(block.SectionIcon);
            dto.HeadingLine1 = block.HeadingLine1;
            dto.HeadingLine2 = block.HeadingLine2;
            dto.Description = block.Description?.ToString();
            dto.ButtonText = block.ButtonText;
            dto.ButtonUrl = block.ButtonUrl;
            dto.Cards = new List<PricingCardDto>();

            if (block.PricingCards != null)
            {
                dto.Cards = block
                    .PricingCards.FilteredItems.Select(item =>
                        _contentLoader.Get<PricingCardBlock>(item.ContentLink)
                    )
                    .Where(card => card != null)
                    .Select(card => new PricingCardDto
                    {
                        Title = card.Title,
                        Price = card.Price,
                        Validity = card.Validity,
                        Features = ParseCommaSeparated(card.Features),
                    })
                    .ToList();
            }

            return dto;
        }

        // =============================================
        // SCHEDULE SECTION — loads from ContentArea block
        // =============================================
        private ScheduleSectionDto GetScheduleSection(HomePage page)
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
        private ViveTrainerSectionDto GetViveTrainerSection(HomePage page)
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

        private List<string> ParseCommaSeparated(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new List<string>();

            return value
                .Split(',')
                .Select(v => v.Trim())
                .Where(v => !string.IsNullOrEmpty(v))
                .ToList();
        }
    }
}
