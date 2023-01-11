namespace HouseRentingSystem.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Authorization;

    using HouseRentingSystem.Services.Contracts;
    using HouseRentingSystem.Web.Extensions;
    using HouseRentingSystem.Web.Models.Agents;

    [Authorize]
	public class AgentsController : Controller
	{
		private readonly IAgentsService agentsService;

		public AgentsController(IAgentsService agentsService)
		{
			this.agentsService = agentsService;
		}

		[HttpGet]
		public async Task<IActionResult> Become()
		{
			if (await this.agentsService.ExistsByIdAsync(this.User.Id()))
			{
				ModelState.AddModelError("Error", "You are already an agent!");
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Become(AgentInputModel model)
		{
			string userId = this.User.Id();

            if (await this.agentsService.ExistsByIdAsync(userId))
            {
                ModelState.AddModelError("Error", "You are already an agent!");
            }

			if (await this.agentsService.UserWithPhoneNumberExistsAsync(model.PhoneNumber))
			{
				ModelState.AddModelError(nameof(model.PhoneNumber), "Phone number already exists. Enter another one.");
			}

			if (await this.agentsService.UserHasRentsAsync(userId))
			{
                ModelState.AddModelError("Error", "You should have no rents to become an agent!");
            }

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await this.agentsService.CreateAgentAsync(userId, model.PhoneNumber);

            return RedirectToAction(nameof(HousesController.All), "Houses");
		}
	}
}
