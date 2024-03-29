﻿namespace TaskBoardApp.Web.Models
{
    using TaskBoardApp.Web.Models.Task;

    public class BoardViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<TaskViewModel> Tasks { get; set; }
    }
}
