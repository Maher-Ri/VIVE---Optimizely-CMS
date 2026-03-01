// Controllers/BlogPostPageController.cs
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using VIVEcms.Models.Pages;
using VIVEcms.Models.ViewModels;
using VIVEcms.Services;

namespace VIVEcms.Controllers
{
    public class BlogPostPageController : PageController<BlogPostPage>
    {
        private readonly ILayoutService _layoutService;

        public BlogPostPageController(ILayoutService layoutService)
        {
            _layoutService = layoutService;
        }

        public IActionResult Index(BlogPostPage currentPage)
        {
            var model = new PageViewModel<BlogPostPage>(currentPage);
            model.Layout = _layoutService.GetLayoutModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult SubmitComment(BlogPostPage currentPage, CommentFormModel commentData)
        {
            if (!ModelState.IsValid)
            {
                var model = new PageViewModel<BlogPostPage>(currentPage);
                model.Layout = _layoutService.GetLayoutModel();
                return View("Index", model);
            }

            // =============================================
            // LOG COMMENT TO CONSOLE
            // =============================================
            Console.WriteLine("========================================");
            Console.WriteLine("📩 NEW COMMENT RECEIVED");
            Console.WriteLine("========================================");
            Console.WriteLine($"📄 Post    : {currentPage.Name}");
            Console.WriteLine($"👤 Author  : {commentData.Author}");
            Console.WriteLine($"📧 Email   : {commentData.Email}");
            Console.WriteLine($"🌐 Website : {commentData.Url}");
            Console.WriteLine($"💬 Comment : {commentData.Comment}");
            Console.WriteLine($"🕐 Time    : {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine("========================================");

            TempData["CommentSuccess"] = "Your comment has been submitted!";

            var referer = Request.Headers["Referer"].ToString();
            return Redirect(string.IsNullOrEmpty(referer) ? "/" : referer);
        }
    }
}
