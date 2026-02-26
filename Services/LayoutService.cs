// Services/LayoutService.cs
using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using VIVEcms.Models.Pages;
using VIVEcms.Models.ViewModels;

namespace VIVEcms.Services
{
    public class LayoutService : ILayoutService
    {
        private readonly IContentLoader _contentLoader;

        public LayoutService(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public LayoutModel GetLayoutModel()
        {
            try
            {
                var settings = GetSiteSettings();

                if (settings == null)
                    return new LayoutModel();

                return new LayoutModel
                {
                    // Footer — Visibility
                    ShowFooter = settings.ShowFooter,

                    // Footer — Top Bar
                    FooterLogo = settings.FooterLogo,
                    FooterAddress = settings.FooterAddress?.ToString(),
                    FooterOpeningHours = settings.FooterOpeningHours?.ToString(),
                    FacebookUrl = settings.FacebookUrl,
                    TwitterUrl = settings.TwitterUrl,
                    YoutubeUrl = settings.YoutubeUrl,
                    InstagramUrl = settings.InstagramUrl,

                    // Footer — Bottom Bar
                    CopyrightText = settings.CopyrightText,
                    FooterLinks = settings.FooterLinks,
                };
            }
            catch
            {
                return new LayoutModel();
            }
        }

        private SiteSettingsPage? GetSiteSettings()
        {
            var children = _contentLoader.GetChildren<SiteSettingsPage>(
                SiteDefinition.Current.RootPage
            );

            return children?.FirstOrDefault();
        }
    }
}
