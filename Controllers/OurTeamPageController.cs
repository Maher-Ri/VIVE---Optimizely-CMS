// Controllers/OurTeamPageController.cs
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using VIVEcms.Models.Pages;
using VIVEcms.Models.ViewModels;
using VIVEcms.Services;

namespace VIVEcms.Controllers
{
    public class OurTeamPageController : PageController<OurTeamPage>
    {
        private readonly ILayoutService _layoutService;

        public OurTeamPageController(ILayoutService layoutService)
        {
            _layoutService = layoutService;
        }

        public IActionResult Index(OurTeamPage currentPage)
        {
            var model = new PageViewModel<OurTeamPage>(currentPage);
            model.Layout = _layoutService.GetLayoutModel();
            return View(model);
        }
    }
}
