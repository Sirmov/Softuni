namespace ForumApp.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using static ForumApp.Data.Common.DataConstants.Post;

    public class Post
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; }
    }
}
