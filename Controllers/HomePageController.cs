// Controllers/HomePageController.cs
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using VIVEcms.Models.Pages;
using VIVEcms.Models.ViewModels;
using VIVEcms.Services;

namespace VIVEcms.Controllers
{
    public class HomePageController : PageController<HomePage>
    {
        private readonly ILayoutService _layoutService;

        // ILayoutService is injected automatically via DI
        public HomePageController(ILayoutService layoutService)
        {
            _layoutService = layoutService;
        }

        public IActionResult Index(HomePage currentPage)
        {
            // 1. Create our ViewModel and pass in the current page
            var model = new PageViewModel<HomePage>(currentPage);

            // 2. Populate Layout from SiteSettingsPage via LayoutService
            //    No more hardcoded data — everything comes from CMS now
            model.Layout = _layoutService.GetLayoutModel();

            // 3. Send the ViewModel to the View
            return View(model);
        }
    }
}
