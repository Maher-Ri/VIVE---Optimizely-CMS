// Controllers/ClassesPageController.cs
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using VIVEcms.Models.Pages;
using VIVEcms.Models.ViewModels;
using VIVEcms.Services;

namespace VIVEcms.Controllers
{
    public class ClassesPageController : PageController<ClassesPage>
    {
        private readonly ILayoutService _layoutService;

        public ClassesPageController(ILayoutService layoutService)
        {
            _layoutService = layoutService;
        }

        public IActionResult Index(ClassesPage currentPage)
        {
            var model = new PageViewModel<ClassesPage>(currentPage);
            model.Layout = _layoutService.GetLayoutModel();
            return View(model);
        }
    }
}
