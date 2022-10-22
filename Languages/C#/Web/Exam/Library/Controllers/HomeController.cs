using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (this.User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "Books");
            }

            return View();
        }
    }
}