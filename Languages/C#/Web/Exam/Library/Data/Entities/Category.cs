namespace Library.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    using static Library.Data.DataConstants.Category;

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        // Navigational properties
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
