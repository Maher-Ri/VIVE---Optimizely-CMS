// Controllers/SingleProductPageController.cs
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using VIVEcms.Models.Pages;
using VIVEcms.Models.ViewModels;
using VIVEcms.Services;

namespace VIVEcms.Controllers
{
    public class SingleProductPageController : PageController<SingleProductPage>
    {
        private readonly ILayoutService _layoutService;

        public SingleProductPageController(ILayoutService layoutService)
        {
            _layoutService = layoutService;
        }

        public IActionResult Index(SingleProductPage currentPage)
        {
            var model = new PageViewModel<SingleProductPage>(currentPage)
            {
                Layout = _layoutService.GetLayoutModel()
            };

            return View(model);
        }
    }
}
