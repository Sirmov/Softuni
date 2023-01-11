namespace Library.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ApplicationUserBook
    {
        [Required]
        public string ApplicationUserId { get; set; } = null!;

        [Required]
        public int BookId { get; set; }

        // Navigational properties
        [ForeignKey(nameof(ApplicationUserId))]
        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        [ForeignKey(nameof(BookId))]
        public virtual Book Book { get; set; } = null!;
    }
}
