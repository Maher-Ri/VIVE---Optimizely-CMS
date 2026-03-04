// Controllers/MembershipPageController.cs
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using VIVEcms.Models.Pages;
using VIVEcms.Models.ViewModels;
using VIVEcms.Services;

namespace VIVEcms.Controllers
{
    public class MembershipPageController : PageController<MembershipPage>
    {
        private readonly ILayoutService _layoutService;

        public MembershipPageController(ILayoutService layoutService)
        {
            _layoutService = layoutService;
        }

        public IActionResult Index(MembershipPage currentPage)
        {
            var model = new PageViewModel<MembershipPage>(currentPage);
            model.Layout = _layoutService.GetLayoutModel();
            return View(model);
        }
    }
}
