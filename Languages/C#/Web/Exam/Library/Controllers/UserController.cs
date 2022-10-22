namespace Library.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using Library.Data.Entities;
    using Library.Models.User;

    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (this.User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "Books");
            }

            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (this.User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "Books");
            }

            var user = await userManager.FindByNameAsync(model.UserName);
            
            if (!ModelState.IsValid || user == null)
            {
                ModelState.AddModelError("", "Invalid login.");
                return View(model);
            }

            var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("All", "Books");
            }

            ModelState.AddModelError("", "Invalid login.");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (this.User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "Books");
            }

            var model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (this.User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "Books");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Login));
            }

            ModelState.AddModelError("", "Invalid register.");
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
