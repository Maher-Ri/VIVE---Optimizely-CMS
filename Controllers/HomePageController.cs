using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using VIVEcms.Models.Pages;
using VIVEcms.Models.ViewModels;

namespace VIVEcms.Controllers
{
    // Inheriting from PageController<HomePage> maps this controller to your HomePage model
    public class HomePageController : PageController<HomePage>
    {
        // Optimizely automatically passes the correct 'currentPage' data from the database 
        // into this action based on the URL the user visits.
        public IActionResult Index(HomePage currentPage)
        {
            // 1. Create our ViewModel and pass in the current page
            var model = new PageViewModel<HomePage>(currentPage);

            // 2. Populate the Layout Data (Navbar & Footer)
            // For now, we hardcode this. Later, we can fetch this from a real "Site Settings" page in Optimizely.
            model.Layout.CompanyName = "My Awesome Company";
            model.Layout.FooterCopyrightText = "© 2026 My Awesome Company. All rights reserved.";

            // 3. Send the ViewModel to the View
            return View(model);
        }
    }
}