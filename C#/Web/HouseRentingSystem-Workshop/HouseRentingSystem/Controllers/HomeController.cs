namespace HouseRentingSystem.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;

    using HouseRentingSystem.Models;
    using HouseRentingSystem.Services.Contracts;
    using HouseRentingSystem.Web.Models.Houses;

    public class HomeController : Controller
    {
        private readonly IHousesService housesService;

        public HomeController(IHousesService housesService)
        {
            this.housesService = housesService;
        }

        public async Task<IActionResult> Index()
        {
            var houses = await housesService.GetLastThreeHousesAsync();

            var model = houses.Select(h => new HouseViewModel()
            {
                Id = h.Id,
                Title = h.Title,
                ImageUrl = h.ImageUrl,
            });

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}