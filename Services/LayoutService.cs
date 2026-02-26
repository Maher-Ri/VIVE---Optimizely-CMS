// Services/LayoutService.cs
using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using VIVEcms.Models.Blocks;
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
                    // Navbar
                    ShowNavbar = settings.ShowNavbar,
                    NavbarLogo = settings.NavbarLogo,
                    NavbarLogoUrl = settings.NavbarLogoUrl,
                    NavbarButtonText = settings.NavbarButtonText,
                    NavbarButtonUrl = settings.NavbarButtonUrl,
                    NavItems = GetNavItems(settings),

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

        // =============================================
        // PRIVATE — Fetch SiteSettingsPage
        // =============================================

        private SiteSettingsPage? GetSiteSettings()
        {
            var children = _contentLoader.GetChildren<SiteSettingsPage>(
                SiteDefinition.Current.RootPage
            );

            return children?.FirstOrDefault();
        }

        // =============================================
        // PRIVATE — Map Nav Items
        // =============================================

        private List<NavItemViewModel> GetNavItems(SiteSettingsPage settings)
        {
            if (settings.NavItems == null)
                return new List<NavItemViewModel>();

            return settings
                .NavItems.FilteredItems.Select(item =>
                    _contentLoader.Get<NavMenuItemBlock>(item.ContentLink)
                )
                .Where(block => block != null)
                .Select(block => new NavItemViewModel
                {
                    Label = block.Label,
                    Url = block.Url ?? "#",
                    HasMegaMenu = block.HasMegaMenu,
                    SubItems = GetSubItems(block.SubItems ?? new ContentArea()),
                    MegaMenuPreviews = GetMegaMenuPreviews(
                        block.MegaMenuPreviews ?? new ContentArea()
                    ),
                })
                .ToList();
        }

        private List<NavSubItemViewModel> GetSubItems(ContentArea subItemsArea)
        {
            if (subItemsArea == null)
                return new List<NavSubItemViewModel>();

            return subItemsArea
                .FilteredItems.Select(item => _contentLoader.Get<NavSubItemBlock>(item.ContentLink))
                .Where(block => block != null)
                .Select(block => new NavSubItemViewModel
                {
                    Label = block.Label,
                    Url = block.Url ?? "#",
                    SubSubItems = GetSubSubItems(block.SubSubItems ?? new ContentArea()),
                })
                .ToList();
        }

        private List<NavSubItemViewModel> GetSubSubItems(ContentArea subSubItemsArea)
        {
            if (subSubItemsArea == null)
                return new List<NavSubItemViewModel>();

            return subSubItemsArea
                .FilteredItems.Select(item => _contentLoader.Get<NavSubItemBlock>(item.ContentLink))
                .Where(block => block != null)
                .Select(block => new NavSubItemViewModel
                {
                    Label = block.Label,
                    Url = block.Url ?? "#",
                })
                .ToList();
        }

        private List<NavMegaPreviewViewModel> GetMegaMenuPreviews(ContentArea megaMenuArea)
        {
            if (megaMenuArea == null)
                return new List<NavMegaPreviewViewModel>();

            return megaMenuArea
                .FilteredItems.Select(item =>
                    _contentLoader.Get<NavMegaPreviewBlock>(item.ContentLink)
                )
                .Where(block => block != null)
                .Select(block => new NavMegaPreviewViewModel
                {
                    PreviewImage = block.PreviewImage,
                    Url = block.Url ?? "#",
                    Label = block.Label,
                })
                .ToList();
        }
    }
}
