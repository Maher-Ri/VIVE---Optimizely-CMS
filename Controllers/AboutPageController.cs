// Controllers/AboutPageController.cs
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using VIVEcms.Models.Pages;
using VIVEcms.Models.ViewModels;
using VIVEcms.Services;

namespace VIVEcms.Controllers
{
    public class AboutPageController : PageController<AboutPage>
    {
        private readonly ILayoutService _layoutService;

        public AboutPageController(ILayoutService layoutService)
        {
            _layoutService = layoutService;
        }

        public IActionResult Index(AboutPage currentPage)
        {
            var model = new PageViewModel<AboutPage>(currentPage);
            model.Layout = _layoutService.GetLayoutModel();
            return View(model);
        }
    }
}
