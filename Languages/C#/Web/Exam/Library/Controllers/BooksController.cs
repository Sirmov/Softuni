namespace Library.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Library.Services.Contracts;
    using Library.Models.Book;

    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBooksService booksService;
        private readonly ICategoriesService categoriesService;

        public BooksController(IBooksService booksService, ICategoriesService categoriesService)
        {
            this.booksService = booksService;
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var books = await booksService.GetAllAsync();

            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = this.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
            var myBooks = await booksService.GetMineAsync(userId);

            return View(myBooks);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new BookInputModel()
            {
                Categories = await this.categoriesService.GetAllAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await this.booksService.AddAsync(model);
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("", "Operation was not successful.");
                model.Categories = await this.categoriesService.GetAllAsync();
                return View(model);
            }

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int bookId)
        {
            var userId = this.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";

            try
            {
                await this.booksService.AddToCollectionAsync(userId, bookId);
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException("Operation was not successful.");
                throw;
            }

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            var userId = this.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";

            try
            {
                await this.booksService.RemoveFromCollectionAsync(userId, bookId);
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException("Operation was not successful.");
                throw;
            }

            return RedirectToAction(nameof(Mine));
        }
    }
}
