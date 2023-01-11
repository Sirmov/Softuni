namespace TaskBoardApp.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.Board;

    public class Board
    {
        public Board()
        {
            this.Tasks = new HashSet<Task>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; } = null!;

        public ICollection<Task> Tasks { get; set; }
    }
}
