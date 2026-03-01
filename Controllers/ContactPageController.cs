// Controllers/ContactPageController.cs
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using VIVEcms.Models.Pages;
using VIVEcms.Models.ViewModels;
using VIVEcms.Services;

namespace VIVEcms.Controllers
{
public class ContactPageController : PageController<ContactPage>
{
    private readonly ILayoutService _layoutService;

    public ContactPageController(ILayoutService layoutService)
    {
        _layoutService = layoutService;
    }

    public IActionResult Index(ContactPage currentPage)
    {
        var model = new PageViewModel<ContactPage>(currentPage);
        model.Layout = _layoutService.GetLayoutModel();
        return View(model);
    }
}
}