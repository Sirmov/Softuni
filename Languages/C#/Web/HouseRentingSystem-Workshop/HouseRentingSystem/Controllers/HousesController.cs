namespace HouseRentingSystem.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Authorization;

	using HouseRentingSystem.Web.Models.Houses;

	[Authorize]
	public class HousesController : Controller
	{
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> All()
		{
			var model = new HouseViewModel();

			return View(model);
		}

        [HttpGet]
		public async Task<IActionResult> Mine()
		{
			var model = new HouseViewModel();

			return View(model);
		}

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
		{
			var model = new HouseDetailsViewModel();

			return View(model);
		}

        [HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(HouseInputModel model)
		{
			return RedirectToAction(nameof(Details), new { id = "1" });
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var model = new HouseInputModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, HouseInputModel model)
		{
			return RedirectToAction(nameof(Details), new { id = "1" });
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			return RedirectToAction(nameof(All));
		}

		[HttpPost]
		public async Task<IActionResult> Rent(int id)
		{
			return RedirectToAction(nameof(Mine));
		}

		[HttpPost]
		public async Task<IActionResult> Leave(int id)
		{
            return RedirectToAction(nameof(Mine));
        }
	}
}
