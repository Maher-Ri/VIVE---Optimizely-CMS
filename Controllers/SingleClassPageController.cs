// Controllers/SingleClassPageController.cs
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using VIVEcms.Models.Pages;
using VIVEcms.Models.ViewModels;
using VIVEcms.Services;

namespace VIVEcms.Controllers
{
    public class SingleClassPageController : PageController<SingleClassPage>
    {
        private readonly ILayoutService _layoutService;

        public SingleClassPageController(ILayoutService layoutService)
        {
            _layoutService = layoutService;
        }

        public IActionResult Index(SingleClassPage currentPage)
        {
            var model = new PageViewModel<SingleClassPage>(currentPage);
            model.Layout = _layoutService.GetLayoutModel();
            return View(model);
        }
    }
}
