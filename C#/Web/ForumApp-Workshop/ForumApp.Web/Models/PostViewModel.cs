namespace ForumApp.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using static ForumApp.Data.Common.DataConstants.Post;

    public class PostViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; }
    }
}
