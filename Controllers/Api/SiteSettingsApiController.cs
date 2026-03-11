// Controllers/Api/SiteSettingsApiController.cs
using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Mvc;
using VIVEcms.Models.Api.SiteSettings;
using VIVEcms.Services;

namespace VIVEcms.Controllers.Api
{
    [ApiController]
    [Route("api/vivecms/v1")]
    public class SiteSettingsApiController : ControllerBase
    {
        private readonly ILayoutService _layoutService;
        private readonly IUrlResolver _urlResolver;
        private readonly IImageService _imageService;

        public SiteSettingsApiController(
            ILayoutService layoutService,
            IUrlResolver urlResolver,
            IImageService imageService
        )
        {
            _layoutService = layoutService;
            _urlResolver = urlResolver;
            _imageService = imageService;
        }

        // =============================================
        // GET api/vivecms/v1/settings
        // =============================================
        [HttpGet("settings")]
        public IActionResult GetSiteSettings()
        {
            // Reuse existing LayoutService — no duplicate logic
            var layout = _layoutService.GetLayoutModel();

            if (layout == null)
                return NotFound(new { message = "SiteSettings not found in CMS" });

            var response = new SiteSettingsApiResponse
            {
                // ===== NAVBAR =====
                Navbar = new NavbarDto
                {
                    IsVisible = layout.ShowNavbar,
                    LogoImageUrl = GetImageUrl(layout.NavbarLogo),
                    LogoImageAlt = _imageService.GetAltText(layout.NavbarLogo),
                    LogoLinkUrl = layout.NavbarLogoUrl,
                    ButtonText = layout.NavbarButtonText,
                    ButtonUrl = layout.NavbarButtonUrl,
                    Items = layout
                        .NavItems.Select(item => new NavItemDto
                        {
                            Label = item.Label,
                            Url = item.Url,
                            HasMegaMenu = item.HasMegaMenu,

                            SubItems = item
                                .SubItems.Select(sub => new NavSubItemDto
                                {
                                    Label = sub.Label,
                                    Url = sub.Url,
                                    SubSubItems = sub
                                        .SubSubItems.Select(subSub => new NavSubItemDto
                                        {
                                            Label = subSub.Label,
                                            Url = subSub.Url,
                                        })
                                        .ToList(),
                                })
                                .ToList(),

                            MegaMenuPreviews = item
                                .MegaMenuPreviews.Select(preview => new NavMegaPreviewDto
                                {
                                    PreviewImageUrl = GetImageUrl(preview.PreviewImage),
                                    PreviewImageAlt = _imageService.GetAltText(
                                        preview.PreviewImage
                                    ),
                                    Url = preview.Url,
                                    Label = preview.Label,
                                })
                                .ToList(),
                        })
                        .ToList(),
                },

                // ===== FOOTER =====
                Footer = new FooterDto
                {
                    IsVisible = layout.ShowFooter,
                    LogoImageUrl = GetImageUrl(layout.FooterLogo),
                    LogoImageAlt = _imageService.GetAltText(layout.FooterLogo),
                    Address = layout.FooterAddress,
                    OpeningHours = layout.FooterOpeningHours,
                    FacebookUrl = layout.FacebookUrl,
                    TwitterUrl = layout.TwitterUrl,
                    YoutubeUrl = layout.YoutubeUrl,
                    InstagramUrl = layout.InstagramUrl,
                    CopyrightText = layout.CopyrightText,
                    Links =
                        layout
                            .FooterLinks?.Select(link => new FooterLinkDto
                            {
                                Text = link.Text,
                                Url = link.Href,
                                Target = link.Target,
                            })
                            .ToList()
                        ?? new List<FooterLinkDto>(),
                },
            };

            return Ok(response);
        }

        // =============================================
        // PRIVATE HELPERS
        // =============================================
        private string GetImageUrl(EPiServer.Core.ContentReference imageRef)
        {
            if (EPiServer.Core.ContentReference.IsNullOrEmpty(imageRef))
                return string.Empty;

            return _urlResolver.GetUrl(imageRef);
        }
    }
}
