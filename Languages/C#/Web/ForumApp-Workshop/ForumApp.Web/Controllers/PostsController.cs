namespace ForumApp.Web.Controllers
{
    using ForumApp.Data;
    using ForumApp.Data.Entities;
    using ForumApp.Web.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class PostsController : Controller
    {
        private readonly ForumAppDbContext dbContext;

        public PostsController(ForumAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await this.dbContext.Posts
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                })
                .ToListAsync();

            return View(posts);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await this.dbContext.AddAsync(new Post()
            {
                Title = model.Title,
                Content = model.Content
            });

            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var post = await this.dbContext.Posts.FindAsync(id);

            if (post == null)
            {
                return BadRequest();
            }

            return View(new PostViewModel()
            {
                Title = post.Title,
                Content = post.Content,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostViewModel model)
        {
            var post = await this.dbContext.Posts.FindAsync(id);

            if (post == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            post.Title = model.Title;
            post.Content = model.Content;

            await this.dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await this.dbContext.Posts.FindAsync(id);

            if (post == null)
            {
                return BadRequest();
            }

            this.dbContext.Posts.Remove(post);
            await this.dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
