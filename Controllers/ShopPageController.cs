// Controllers/ShopPageController.cs
using EPiServer;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using VIVEcms.Models.Pages;
using VIVEcms.Models.ViewModels;
using VIVEcms.Services;

namespace VIVEcms.Controllers
{
    public class ShopPageController : PageController<ShopPage>
    {
        private readonly IContentLoader _contentLoader;
        private readonly ILayoutService _layoutService;

        public ShopPageController(IContentLoader contentLoader, ILayoutService layoutService)
        {
            _contentLoader = contentLoader;
            _layoutService = layoutService;
        }

        public IActionResult Index(ShopPage currentPage)
        {
            // Fetch all SingleProductPage children from the content tree
            var products = _contentLoader
                .GetChildren<SingleProductPage>(currentPage.ContentLink)
                .ToList();

            var model = new ShopPageViewModel(currentPage)
            {
                Products = products,
                Layout   = _layoutService.GetLayoutModel(),
            };

            return View(model);
        }
    }
}
