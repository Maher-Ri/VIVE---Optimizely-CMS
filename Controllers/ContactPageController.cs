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

        // POST — handles contact form submission
        [HttpPost]
        public IActionResult SubmitContact(ContactPage currentPage, ContactFormModel form)
        {
            if (!ModelState.IsValid)
            {
                var model = new PageViewModel<ContactPage>(currentPage);
                model.Layout = _layoutService.GetLayoutModel();
                return View("Index", model);
            }

            // Log to console
            Console.WriteLine("========================================");
            Console.WriteLine("📩 NEW CONTACT MESSAGE RECEIVED");
            Console.WriteLine("========================================");
            Console.WriteLine($"👤 Name    : {form.Name}");
            Console.WriteLine($"📧 Email   : {form.Email}");
            Console.WriteLine($"📋 Subject : {form.Subject}");
            Console.WriteLine($"💬 Message : {form.Message}");
            Console.WriteLine($"🕐 Time    : {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine("========================================");

            TempData["ContactSuccess"] = "Thank you! Your message has been sent.";

            var referer = Request.Headers["Referer"].ToString();
            return Redirect(string.IsNullOrEmpty(referer) ? "/" : referer);
        }
    }
}
