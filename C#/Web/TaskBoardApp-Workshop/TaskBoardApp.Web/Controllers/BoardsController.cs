namespace TaskBoardApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TaskBoardApp.Web.Data;
    using TaskBoardApp.Web.Models;
    using TaskBoardApp.Web.Models.Task;

    public class BoardsController : Controller
    {
        private readonly ApplicationDbContext context;

        public BoardsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult All()
        {
            var boards = this.context.Boards
                .Select(b => new BoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b.Tasks.Select(t => new TaskViewModel()
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Description = t.Description,
                        Owner = t.Owner.UserName
                    })
                })
                .ToList();

            return View(boards);
        }
    }
}
