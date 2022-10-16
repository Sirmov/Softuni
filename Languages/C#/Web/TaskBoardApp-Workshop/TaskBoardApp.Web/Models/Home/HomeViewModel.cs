namespace TaskBoardApp.Web.Models.Home
{
    public class HomeViewModel
    {
        public int AllTasksCount { get; set; }

        public List<HomeBoardModel> BoardsWithTasksCount { get; set; }

        public int UserTasksCount { get; set; }
    }
}
