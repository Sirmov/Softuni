using Microsoft.AspNetCore.Mvc;

namespace Watchlist.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (this.User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "Movies");
            }

            return View();
        }
    }
}